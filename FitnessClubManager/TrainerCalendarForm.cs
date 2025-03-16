using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace FitnessManager
{
    /// <summary>
    /// Форма для отображения календаря занятий тренера
    /// </summary>
    public partial class TrainerCalendarForm : Form
    {
        private int trainerId;
        private DateTime selectedDate;
        private bool isAdmin;
        private string connectionString = DBConnection.ConnectionString;
        private string trainerName;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="trainerId">ID тренера</param>
        /// <param name="trainerName">Имя тренера</param>
        /// <param name="isAdmin">Права администратора</param>
        public TrainerCalendarForm(int trainerId, string trainerName, bool isAdmin = false)
        {
            this.trainerId = trainerId;
            this.trainerName = trainerName;
            this.isAdmin = isAdmin;
            this.selectedDate = DateTime.Today;

            InitializeComponent();

            // Настройка заголовка
            lblTitle.Text = $"КАЛЕНДАРЬ ЗАНЯТИЙ: {trainerName.ToUpper()}";
            this.Text = $"Календарь занятий: {trainerName}";
        }

        /// <summary>
        /// Обработчик загрузки формы
        /// </summary>
        private void TrainerCalendarForm_Load(object sender, EventArgs e)
        {
            // Установка доступности кнопок в зависимости от прав
            btnAddSchedule.Visible = isAdmin;
            btnEditSchedule.Visible = isAdmin;
            btnDeleteSchedule.Visible = isAdmin;

            // Обновление заголовка с текущей датой
            lblSelectedDate.Text = $"Расписание на {selectedDate:dd MMMM yyyy}";

            // По умолчанию выбираем "Все часы"
            cmbTimeFilter.SelectedIndex = 0;

            // Загружаем расписание на выбранную дату
            LoadTrainerScheduleForDate(selectedDate);
        }

        /// <summary>
        /// Загрузка данных о занятиях тренера на выбранную дату
        /// </summary>
        /// <param name="date">Дата для загрузки расписания</param>
        private void LoadTrainerScheduleForDate(DateTime date)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Базовый запрос для получения занятий тренера на дату
                    string query = @"
                        SELECT 
                            s.ScheduleID,
                            c.Name as ClassName,
                            s.StartTime,
                            s.MaxParticipants,
                            (SELECT COUNT(*) FROM Visits v WHERE v.ScheduleID = s.ScheduleID) as CurrentParticipants
                        FROM 
                            Schedule s
                            JOIN Classes c ON s.ClassID = c.ClassID
                        WHERE 
                            s.TrainerID = @TrainerID
                            AND s.Date = @Date";

                    // Фильтр по времени дня, если выбран
                    string timeFilter = cmbTimeFilter.SelectedIndex switch
                    {
                        1 => " AND s.StartTime BETWEEN '06:00:00' AND '12:00:00'", // Утро
                        2 => " AND s.StartTime BETWEEN '12:00:00' AND '18:00:00'", // День
                        3 => " AND s.StartTime BETWEEN '18:00:00' AND '23:00:00'", // Вечер
                        _ => "" // Все часы
                    };

                    query += timeFilter + " ORDER BY s.StartTime";

                    // Создаем адаптер и заполняем DataTable
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrainerID", trainerId);
                        command.Parameters.AddWithValue("@Date", date);

                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Устанавливаем данные в DataGridView
                        scheduleGrid.DataSource = dt;

                        // Настройка отображения столбцов
                        if (scheduleGrid.Columns.Contains("ScheduleID"))
                            scheduleGrid.Columns["ScheduleID"].Visible = false;

                        if (scheduleGrid.Columns.Contains("ClassName"))
                            scheduleGrid.Columns["ClassName"].HeaderText = "Название занятия";

                        if (scheduleGrid.Columns.Contains("StartTime"))
                            scheduleGrid.Columns["StartTime"].HeaderText = "Время начала";

                        if (scheduleGrid.Columns.Contains("MaxParticipants"))
                            scheduleGrid.Columns["MaxParticipants"].HeaderText = "Макс. участников";

                        if (scheduleGrid.Columns.Contains("CurrentParticipants"))
                            scheduleGrid.Columns["CurrentParticipants"].HeaderText = "Текущее кол-во";

                        // Раскрашиваем строки в зависимости от загруженности
                        foreach (DataGridViewRow row in scheduleGrid.Rows)
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
                MessageBox.Show($"Ошибка при загрузке расписания: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик изменения даты в календаре
        /// </summary>
        private void Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            selectedDate = e.Start.Date;
            lblSelectedDate.Text = $"Расписание на {selectedDate:dd MMMM yyyy}";
            LoadTrainerScheduleForDate(selectedDate);
        }

        /// <summary>
        /// Обработчик изменения фильтра времени
        /// </summary>
        private void CmbTimeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTrainerScheduleForDate(selectedDate);
        }

        /// <summary>
        /// Обработчик кнопки добавления расписания
        /// </summary>
        private void BtnAddSchedule_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                MessageBox.Show("У вас нет прав для добавления занятий", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем форму для добавления занятия
            AddScheduleForm form = new AddScheduleForm();

            // Если форма будет закрыта с результатом OK, обновляем расписание
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadTrainerScheduleForDate(selectedDate);
            }
        }

        /// <summary>
        /// Обработчик кнопки редактирования расписания
        /// </summary>
        private void BtnEditSchedule_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                MessageBox.Show("У вас нет прав для редактирования занятий", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем, выбрана ли строка
            if (scheduleGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите занятие для редактирования", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем ID выбранного расписания
            int scheduleId = Convert.ToInt32(scheduleGrid.SelectedRows[0].Cells["ScheduleID"].Value);

            // Создаем форму для редактирования занятия
            AddScheduleForm form = new AddScheduleForm(scheduleId);

            // Если форма будет закрыта с результатом OK, обновляем расписание
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadTrainerScheduleForDate(selectedDate);
            }
        }

        /// <summary>
        /// Обработчик кнопки удаления расписания
        /// </summary>
        private void BtnDeleteSchedule_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                MessageBox.Show("У вас нет прав для удаления занятий", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем, выбрана ли строка
            if (scheduleGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите занятие для удаления", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Подтверждение удаления
            if (MessageBox.Show("Вы действительно хотите удалить выбранное занятие?", "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            // Получаем ID выбранного расписания
            int scheduleId = Convert.ToInt32(scheduleGrid.SelectedRows[0].Cells["ScheduleID"].Value);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Удаляем связанные записи из посещений
                    string deleteVisitsQuery = "DELETE FROM Visits WHERE ScheduleID = @ScheduleID";
                    using (NpgsqlCommand command = new NpgsqlCommand(deleteVisitsQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ScheduleID", scheduleId);
                        command.ExecuteNonQuery();
                    }

                    // Удаляем запись расписания
                    string deleteScheduleQuery = "DELETE FROM Schedule WHERE ScheduleID = @ScheduleID";
                    using (NpgsqlCommand command = new NpgsqlCommand(deleteScheduleQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ScheduleID", scheduleId);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Занятие успешно удалено", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Обновляем расписание
                    LoadTrainerScheduleForDate(selectedDate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении занятия: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик кнопки обновления данных
        /// </summary>
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadTrainerScheduleForDate(selectedDate);
        }

        /// <summary>
        /// Обработчик кнопки закрытия
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}