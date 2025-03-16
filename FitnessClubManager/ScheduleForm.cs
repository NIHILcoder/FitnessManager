using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace FitnessManager
{
    public partial class ScheduleForm : Form
    {
        private string connectionString = DBConnection.ConnectionString;
        private string userRole;

        // Текущая выбранная дата
        private DateTime currentDate = DateTime.Today;

        public ScheduleForm(string userRole)
        {
            InitializeComponent();
            this.userRole = userRole;

            // Настройка элементов управления в зависимости от роли
            ConfigureAccessRights();

            // Заполняем фильтр времени дня
            cmbTimeFilter.Items.Clear();
            cmbTimeFilter.Items.Add("Все часы");
            cmbTimeFilter.Items.Add("Утро (6:00-12:00)");
            cmbTimeFilter.Items.Add("День (12:00-18:00)");
            cmbTimeFilter.Items.Add("Вечер (18:00-23:00)");
            cmbTimeFilter.SelectedIndex = 0;

            // Устанавливаем заголовок с текущей датой
            UpdateDateHeader();

            // Загружаем данные расписания
            LoadScheduleData();
        }

        private void ConfigureAccessRights()
        {
            // Если не администратор, скрываем кнопки добавления/редактирования расписания
            if (userRole != "Администратор")
            {
                btnAddClass.Visible = false;
                btnEditClass.Visible = false;
                btnDeleteClass.Visible = false;
            }
        }

        private void UpdateDateHeader()
        {
            lblSelectedDate.Text = $"Расписание на {currentDate:dd MMMM yyyy}";
        }

        private void LoadScheduleData()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string timeFilter = "";
                    if (cmbTimeFilter.SelectedIndex == 1)
                    {
                        timeFilter = " AND s.StartTime BETWEEN '06:00:00' AND '12:00:00'"; // Утро
                    }
                    else if (cmbTimeFilter.SelectedIndex == 2)
                    {
                        timeFilter = " AND s.StartTime BETWEEN '12:00:00' AND '18:00:00'"; // День
                    }
                    else if (cmbTimeFilter.SelectedIndex == 3)
                    {
                        timeFilter = " AND s.StartTime BETWEEN '18:00:00' AND '23:00:00'"; // Вечер
                    }

                    string query = @"
                        SELECT 
                            s.ScheduleID,
                            c.Name as ClassName,
                            t.LastName || ' ' || t.FirstName as TrainerName,
                            s.StartTime,
                            s.MaxParticipants,
                            (SELECT COUNT(*) FROM Visits v WHERE v.ScheduleID = s.ScheduleID) as CurrentParticipants
                        FROM 
                            Schedule s
                            JOIN Classes c ON s.ClassID = c.ClassID
                            JOIN Trainers t ON s.TrainerID = t.TrainerID
                        WHERE 
                            s.Date = @Date" + timeFilter + @"
                        ORDER BY 
                            s.StartTime";

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                    adapter.SelectCommand = new NpgsqlCommand(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@Date", currentDate.Date);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    scheduleGrid.DataSource = dt;

                    // Настройка отображения столбцов
                    if (scheduleGrid.Columns.Contains("ScheduleID"))
                        scheduleGrid.Columns["ScheduleID"].Visible = false;

                    if (scheduleGrid.Columns.Contains("ClassName"))
                        scheduleGrid.Columns["ClassName"].HeaderText = "Название занятия";

                    if (scheduleGrid.Columns.Contains("TrainerName"))
                        scheduleGrid.Columns["TrainerName"].HeaderText = "Тренер";

                    if (scheduleGrid.Columns.Contains("StartTime"))
                        scheduleGrid.Columns["StartTime"].HeaderText = "Время начала";

                    if (scheduleGrid.Columns.Contains("MaxParticipants"))
                        scheduleGrid.Columns["MaxParticipants"].HeaderText = "Макс. участников";

                    if (scheduleGrid.Columns.Contains("CurrentParticipants"))
                        scheduleGrid.Columns["CurrentParticipants"].HeaderText = "Текущее кол-во";

                    // Раскрашиваем строки в зависимости от загруженности
                    foreach (DataGridViewRow row in scheduleGrid.Rows)
                    {
                        if (row.Cells["CurrentParticipants"].Value != DBNull.Value &&
                            row.Cells["MaxParticipants"].Value != DBNull.Value)
                        {
                            int current = Convert.ToInt32(row.Cells["CurrentParticipants"].Value);
                            int max = Convert.ToInt32(row.Cells["MaxParticipants"].Value);

                            // Вычисляем процент заполненности
                            double fillPercent = (double)current / max * 100;

                            // Раскрашиваем в зависимости от заполненности
                            if (fillPercent >= 90)
                                row.DefaultCellStyle.BackColor = Color.MistyRose; // Почти полный
                            else if (fillPercent >= 70)
                                row.DefaultCellStyle.BackColor = Color.LightYellow; // Больше половины
                            else if (fillPercent >= 30)
                                row.DefaultCellStyle.BackColor = Color.LightGreen; // Нормальная заполненность
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке расписания: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            currentDate = e.Start.Date;
            UpdateDateHeader();
            LoadScheduleData();
        }

        private void cmbTimeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadScheduleData();
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            AddScheduleForm form = new AddScheduleForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadScheduleData();
            }
        }

        private void btnEditClass_Click(object sender, EventArgs e)
        {
            if (scheduleGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите занятие для редактирования",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int scheduleId = Convert.ToInt32(scheduleGrid.SelectedRows[0].Cells["ScheduleID"].Value);

            AddScheduleForm form = new AddScheduleForm(scheduleId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadScheduleData();
            }
        }

        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            if (scheduleGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите занятие для удаления",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Вы действительно хотите удалить выбранное занятие?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int scheduleId = Convert.ToInt32(scheduleGrid.SelectedRows[0].Cells["ScheduleID"].Value);

                    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                    {
                        connection.Open();

                        // Сначала удаляем связанные записи в таблице посещений
                        string deleteVisitsQuery = "DELETE FROM Visits WHERE ScheduleID = @ScheduleID";
                        using (NpgsqlCommand command = new NpgsqlCommand(deleteVisitsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ScheduleID", scheduleId);
                            command.ExecuteNonQuery();
                        }

                        // Затем удаляем само расписание
                        string deleteScheduleQuery = "DELETE FROM Schedule WHERE ScheduleID = @ScheduleID";
                        using (NpgsqlCommand command = new NpgsqlCommand(deleteScheduleQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ScheduleID", scheduleId);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Занятие успешно удалено",
                            "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadScheduleData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении занятия: {ex.Message}",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRegisterClient_Click(object sender, EventArgs e)
        {
            if (scheduleGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите занятие для записи клиента",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Здесь должна быть форма для выбора клиента и регистрации его на занятие
            MessageBox.Show("Функция записи клиента будет доступна в следующей версии",
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadScheduleData();
        }
    }
}