using System;
using System.Windows.Forms;
using Npgsql;

namespace FitnessManager
{
    public partial class AddTrainerForm : Form
    {
        private string connectionString = DBConnection.ConnectionString;
        private int userId = 0; // 0 означает, что это новый тренер
        private int trainerId = 0;

        public AddTrainerForm()
        {
            InitializeComponent();
        }

        // Конструктор для редактирования тренера
        public AddTrainerForm(int trainerId)
        {
            InitializeComponent();
            this.trainerId = trainerId;
            LoadTrainerData();
        }

        private void LoadTrainerData()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT t.LastName, t.FirstName, t.MiddleName, t.Phone, 
                                    t.Email, t.HireDate, t.Specialty, t.UserID
                                    FROM Trainers t
                                    WHERE t.TrainerID = @TrainerID";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrainerID", trainerId);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtLastName.Text = reader["LastName"].ToString();
                                txtFirstName.Text = reader["FirstName"].ToString();
                                txtMiddleName.Text = reader["MiddleName"].ToString();
                                txtPhone.Text = reader["Phone"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                dtpHireDate.Value = Convert.ToDateTime(reader["HireDate"]);
                                txtSpecialty.Text = reader["Specialty"].ToString();
                                userId = Convert.ToInt32(reader["UserID"]);

                                this.Text = "Редактирование тренера";
                                btnSave.Text = "Сохранить изменения";
                                chkCreateAccount.Enabled = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных тренера: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверка заполнения обязательных полей
            if (string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля (отмечены *)",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Если это новый тренер и нужно создать пользователя
                            if (userId == 0 && chkCreateAccount.Checked)
                            {
                                // Создаем пользователя
                                string login = txtLogin.Text.Trim();
                                string password = txtPassword.Text.Trim();

                                if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                                {
                                    MessageBox.Show("Для создания учетной записи необходимо указать логин и пароль",
                                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                // Проверяем, что логин уникален
                                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Login = @Login";
                                using (NpgsqlCommand checkCommand = new NpgsqlCommand(checkQuery, connection))
                                {
                                    checkCommand.Transaction = transaction;
                                    checkCommand.Parameters.AddWithValue("@Login", login);
                                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                                    if (count > 0)
                                    {
                                        MessageBox.Show("Пользователь с таким логином уже существует",
                                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }

                                // Создаем пользователя
                                string userQuery = "INSERT INTO Users (Login, Password, Role) VALUES (@Login, @Password, 'Тренер') RETURNING UserID";
                                using (NpgsqlCommand userCommand = new NpgsqlCommand(userQuery, connection))
                                {
                                    userCommand.Transaction = transaction;
                                    userCommand.Parameters.AddWithValue("@Login", login);
                                    userCommand.Parameters.AddWithValue("@Password", password);
                                    userId = Convert.ToInt32(userCommand.ExecuteScalar());
                                }
                            }

                            // Если userId все еще 0 и это не запрос на создание учетной записи,
                            // создаем пользователя без логина (для системных целей)
                            if (userId == 0 && !chkCreateAccount.Checked)
                            {
                                string sysLogin = "system_" + Guid.NewGuid().ToString("N").Substring(0, 8);
                                string sysPassword = Guid.NewGuid().ToString("N");

                                string userQuery = "INSERT INTO Users (Login, Password, Role) VALUES (@Login, @Password, 'Тренер') RETURNING UserID";
                                using (NpgsqlCommand userCommand = new NpgsqlCommand(userQuery, connection))
                                {
                                    userCommand.Transaction = transaction;
                                    userCommand.Parameters.AddWithValue("@Login", sysLogin);
                                    userCommand.Parameters.AddWithValue("@Password", sysPassword);
                                    userId = Convert.ToInt32(userCommand.ExecuteScalar());
                                }
                            }

                            // Добавляем или обновляем тренера
                            string query;
                            if (trainerId > 0)
                            {
                                // Обновляем данные тренера
                                query = @"UPDATE Trainers 
                                        SET LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName,
                                        Phone = @Phone, Email = @Email, HireDate = @HireDate, Specialty = @Specialty
                                        WHERE TrainerID = @TrainerID";
                            }
                            else
                            {
                                // Добавляем нового тренера
                                query = @"INSERT INTO Trainers 
                                        (UserID, LastName, FirstName, MiddleName, Phone, Email, HireDate, Specialty)
                                        VALUES (@UserID, @LastName, @FirstName, @MiddleName, @Phone, @Email, @HireDate, @Specialty)";
                            }

                            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                            {
                                command.Transaction = transaction;
                                if (trainerId > 0)
                                {
                                    command.Parameters.AddWithValue("@TrainerID", trainerId);
                                }
                                command.Parameters.AddWithValue("@UserID", userId);
                                command.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                                command.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text.Trim());
                                command.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                                command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                                command.Parameters.AddWithValue("@HireDate", dtpHireDate.Value);
                                command.Parameters.AddWithValue("@Specialty", txtSpecialty.Text.Trim());

                                command.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            MessageBox.Show("Данные успешно сохранены", "Информация",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkCreateAccount_CheckedChanged(object sender, EventArgs e)
        {
            // Показываем или скрываем панель создания учетной записи
            panelAccount.Visible = chkCreateAccount.Checked;
        }
    }
}