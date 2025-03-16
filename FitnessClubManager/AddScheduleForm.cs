using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace FitnessManager
{
    public partial class AddScheduleForm : Form
    {
        private string connectionString = DBConnection.ConnectionString;
        private int scheduleId = 0;

        public AddScheduleForm()
        {
            InitializeComponent();
            LoadClasses();
            LoadTrainers();
        }

        public AddScheduleForm(int scheduleId)
        {
            InitializeComponent();
            this.scheduleId = scheduleId;
            LoadClasses();
            LoadTrainers();
            LoadScheduleData();
            this.Text = "Редактирование расписания";
            btnSave.Text = "Сохранить изменения";
        }

        private void LoadClasses()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT ClassID, Name || ' (' || Duration || ' мин)' AS ClassInfo
                                    FROM Classes
                                    ORDER BY Name";

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbClass.DataSource = dt;
                    cmbClass.DisplayMember = "ClassInfo";
                    cmbClass.ValueMember = "ClassID";
                    cmbClass.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка занятий: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTrainers()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT TrainerID, LastName || ' ' || FirstName AS FullName
                                    FROM Trainers
                                    ORDER BY LastName, FirstName";

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbTrainer.DataSource = dt;
                    cmbTrainer.DisplayMember = "FullName";
                    cmbTrainer.ValueMember = "TrainerID";
                    cmbTrainer.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка тренеров: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadScheduleData()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT ClassID, TrainerID, Date, StartTime, MaxParticipants
                                    FROM Schedule
                                    WHERE ScheduleID = @ScheduleID";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ScheduleID", scheduleId);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cmbClass.SelectedValue = reader.GetInt32(0);
                                cmbTrainer.SelectedValue = reader.GetInt32(1);
                                dtpDate.Value = reader.GetDateTime(2);
                                dtpTime.Value = DateTime.Today.Add(reader.GetTimeSpan(3));
                                nudMaxParticipants.Value = reader.GetInt32(4);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных расписания: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверка заполнения обязательных полей
            if (cmbClass.SelectedIndex == -1 || cmbTrainer.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите занятие и тренера",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int classId = Convert.ToInt32(cmbClass.SelectedValue);
            int trainerId = Convert.ToInt32(cmbTrainer.SelectedValue);
            DateTime date = dtpDate.Value.Date;
            TimeSpan time = dtpTime.Value.TimeOfDay;
            int maxParticipants = Convert.ToInt32(nudMaxParticipants.Value);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Проверка, не занят ли тренер в это время
                    string checkQuery = @"SELECT COUNT(*) FROM Schedule 
                                        WHERE TrainerID = @TrainerID AND Date = @Date 
                                        AND StartTime = @StartTime AND ScheduleID != @ScheduleID";

                    using (NpgsqlCommand checkCommand = new NpgsqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@TrainerID", trainerId);
                        checkCommand.Parameters.AddWithValue("@Date", date);
                        checkCommand.Parameters.AddWithValue("@StartTime", time);
                        checkCommand.Parameters.AddWithValue("@ScheduleID", scheduleId); // При добавлении нового будет 0

                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Тренер уже занят в это время.",
                                "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string query;
                    if (scheduleId > 0)
                    {
                        // Обновляем расписание
                        query = @"UPDATE Schedule 
                                SET ClassID = @ClassID, TrainerID = @TrainerID, Date = @Date, 
                                StartTime = @StartTime, MaxParticipants = @MaxParticipants
                                WHERE ScheduleID = @ScheduleID";
                    }
                    else
                    {
                        // Добавляем новое расписание
                        query = @"INSERT INTO Schedule 
                                (ClassID, TrainerID, Date, StartTime, MaxParticipants)
                                VALUES (@ClassID, @TrainerID, @Date, @StartTime, @MaxParticipants)";
                    }

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        if (scheduleId > 0)
                        {
                            command.Parameters.AddWithValue("@ScheduleID", scheduleId);
                        }
                        command.Parameters.AddWithValue("@ClassID", classId);
                        command.Parameters.AddWithValue("@TrainerID", trainerId);
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@StartTime", time);
                        command.Parameters.AddWithValue("@MaxParticipants", maxParticipants);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Данные успешно сохранены", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
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
    }
}