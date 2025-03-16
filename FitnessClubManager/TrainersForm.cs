using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace FitnessManager
{
    public partial class TrainersForm : Form
    {
        private string connectionString = DBConnection.ConnectionString;
        private string userRole;
        private int clientId = 0; // ID клиента для оценки тренера (если текущий пользователь - клиент)

        public TrainersForm(string userRole)
        {
            InitializeComponent();
            this.userRole = userRole;

            // Проверяем, является ли текущий пользователь клиентом
            if (userRole == "Клиент")
            {
                GetCurrentClientId();
            }

            // Настройка элементов управления в зависимости от роли
            ConfigureAccessRights();

            // Загружаем список тренеров
            LoadTrainers();
        }

        private void GetCurrentClientId()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ClientID FROM Clients WHERE UserID = @UserID";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", ModernMainForm.CurrentUserID);

                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            clientId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting client ID: {ex.Message}");
            }
        }

        private void ConfigureAccessRights()
        {
            // Настраиваем доступность элементов управления в зависимости от роли
            if (userRole != "Администратор")
            {
                btnAddTrainer.Visible = false;
                btnEditTrainer.Visible = false;
                btnDeleteTrainer.Visible = false;
            }

            // Кнопка оценки тренера доступна только клиентам
            btnRateTrainer.Visible = (userRole == "Клиент" && clientId > 0);
        }

        private void LoadTrainers()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            t.TrainerID,
                            t.LastName, 
                            t.FirstName, 
                            t.MiddleName,
                            t.Phone,
                            t.Email,
                            t.HireDate,
                            t.Specialty,
                            COALESCE((SELECT AVG(rating_value)::numeric(10,1) FROM trainer_ratings WHERE trainer_id = t.TrainerID), 0) as AverageRating
                        FROM 
                            Trainers t
                        ORDER BY 
                            t.LastName, t.FirstName";

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvTrainers.DataSource = dt;

                    // Настройка отображения заголовков
                    if (dgvTrainers.Columns.Contains("TrainerID"))
                        dgvTrainers.Columns["TrainerID"].Visible = false;

                    if (dgvTrainers.Columns.Contains("LastName"))
                        dgvTrainers.Columns["LastName"].HeaderText = "Фамилия";

                    if (dgvTrainers.Columns.Contains("FirstName"))
                        dgvTrainers.Columns["FirstName"].HeaderText = "Имя";

                    if (dgvTrainers.Columns.Contains("MiddleName"))
                        dgvTrainers.Columns["MiddleName"].HeaderText = "Отчество";

                    if (dgvTrainers.Columns.Contains("Phone"))
                        dgvTrainers.Columns["Phone"].HeaderText = "Телефон";

                    if (dgvTrainers.Columns.Contains("Email"))
                        dgvTrainers.Columns["Email"].HeaderText = "Email";

                    if (dgvTrainers.Columns.Contains("HireDate"))
                        dgvTrainers.Columns["HireDate"].HeaderText = "Дата найма";

                    if (dgvTrainers.Columns.Contains("Specialty"))
                        dgvTrainers.Columns["Specialty"].HeaderText = "Специализация";

                    if (dgvTrainers.Columns.Contains("AverageRating"))
                        dgvTrainers.Columns["AverageRating"].HeaderText = "Рейтинг";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка тренеров: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    LoadTrainers();
                    return;
                }

                DataTable dt = dgvTrainers.DataSource as DataTable;
                if (dt == null) return;

                // Фильтрация по ФИО и специализации
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format(
                    "LastName LIKE '%{0}%' OR FirstName LIKE '%{0}%' OR MiddleName LIKE '%{0}%' OR Specialty LIKE '%{0}%'",
                    txtSearch.Text.Replace("'", "''"));

                dgvTrainers.DataSource = dv.ToTable();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error filtering trainers: {ex.Message}");
            }
        }

        private void btnAddTrainer_Click(object sender, EventArgs e)
        {
            AddTrainerForm form = new AddTrainerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadTrainers();
            }
        }

        private void btnEditTrainer_Click(object sender, EventArgs e)
        {
            if (dgvTrainers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите тренера для редактирования", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int trainerId = Convert.ToInt32(dgvTrainers.SelectedRows[0].Cells["TrainerID"].Value);

            AddTrainerForm form = new AddTrainerForm(trainerId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadTrainers();
            }
        }

        private void btnDeleteTrainer_Click(object sender, EventArgs e)
        {
            if (dgvTrainers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите тренера для удаления", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int trainerId = Convert.ToInt32(dgvTrainers.SelectedRows[0].Cells["TrainerID"].Value);
            string trainerName = $"{dgvTrainers.SelectedRows[0].Cells["LastName"].Value} {dgvTrainers.SelectedRows[0].Cells["FirstName"].Value}";

            // Запрашиваем подтверждение
            if (MessageBox.Show($"Вы действительно хотите удалить тренера {trainerName}?",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Проверяем, есть ли связанные записи в расписании
                    string checkQuery = "SELECT COUNT(*) FROM Schedule WHERE TrainerID = @TrainerID";

                    using (NpgsqlCommand command = new NpgsqlCommand(checkQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TrainerID", trainerId);
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show($"Невозможно удалить тренера, так как с ним связано {count} записей в расписании.",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Удаляем рейтинги тренера
                    string deleteRatingsQuery = "DELETE FROM trainer_ratings WHERE trainer_id = @TrainerID";

                    using (NpgsqlCommand command = new NpgsqlCommand(deleteRatingsQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TrainerID", trainerId);
                        command.ExecuteNonQuery();
                    }

                    // Получаем UserID тренера для последующего удаления
                    int userId = 0;
                    string getUserIdQuery = "SELECT UserID FROM Trainers WHERE TrainerID = @TrainerID";

                    using (NpgsqlCommand command = new NpgsqlCommand(getUserIdQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TrainerID", trainerId);
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            userId = Convert.ToInt32(result);
                        }
                    }

                    // Удаляем тренера
                    string deleteTrainerQuery = "DELETE FROM Trainers WHERE TrainerID = @TrainerID";

                    using (NpgsqlCommand command = new NpgsqlCommand(deleteTrainerQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TrainerID", trainerId);
                        command.ExecuteNonQuery();
                    }

                    // Удаляем пользователя
                    if (userId > 0)
                    {
                        string deleteUserQuery = "DELETE FROM Users WHERE UserID = @UserID";

                        using (NpgsqlCommand command = new NpgsqlCommand(deleteUserQuery, connection))
                        {
                            command.Parameters.AddWithValue("@UserID", userId);
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Тренер успешно удален", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadTrainers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении тренера: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewSchedule_Click(object sender, EventArgs e)
        {
            if (dgvTrainers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите тренера для просмотра расписания", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int trainerId = Convert.ToInt32(dgvTrainers.SelectedRows[0].Cells["TrainerID"].Value);
            string trainerName = $"{dgvTrainers.SelectedRows[0].Cells["LastName"].Value} {dgvTrainers.SelectedRows[0].Cells["FirstName"].Value}";

            TrainerCalendarForm calendarForm = new TrainerCalendarForm(trainerId, trainerName, userRole == "Администратор");
            calendarForm.ShowDialog();
        }

        private void btnRateTrainer_Click(object sender, EventArgs e)
        {
            if (dgvTrainers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите тренера для оценки", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int trainerId = Convert.ToInt32(dgvTrainers.SelectedRows[0].Cells["TrainerID"].Value);
            string trainerName = $"{dgvTrainers.SelectedRows[0].Cells["LastName"].Value} {dgvTrainers.SelectedRows[0].Cells["FirstName"].Value}";

            TrainerRatingForm ratingForm = new TrainerRatingForm(trainerId, trainerName, clientId);
            if (ratingForm.ShowDialog() == DialogResult.OK)
            {
                LoadTrainers();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTrainers();
        }
    }
}