using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace FitnessManager
{
    public partial class MainForm : Form
    {
        private int userId;
        private string userRole;
        private string connectionString = DBConnection.ConnectionString;

        // Словари для заголовков столбцов
        private readonly Dictionary<string, Dictionary<string, string>> columnHeaders = new Dictionary<string, Dictionary<string, string>>();

        public MainForm(int userId, string userRole)
        {
            InitializeComponent();
            this.userId = userId;
            this.userRole = userRole;

            lblUserInfo.Text = $"Роль: {userRole}";
            ConfigureAccessRights();
            InitializeColumnHeaders();

            // Установка обработчиков событий
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
        }

        private void InitializeColumnHeaders()
        {
            // Клиенты
            columnHeaders["Clients"] = new Dictionary<string, string>
            {
                {"ClientID", "ID"}, {"LastName", "Фамилия"}, {"FirstName", "Имя"},
                {"MiddleName", "Отчество"}, {"BirthDate", "Дата рождения"},
                {"Phone", "Телефон"}, {"Email", "Email"}, {"RegistrationDate", "Дата регистрации"}
            };

            // Абонементы
            columnHeaders["Subscriptions"] = new Dictionary<string, string>
            {
                {"SubscriptionID", "ID"}, {"ClientName", "Клиент"}, {"TypeName", "Тип абонемента"},
                {"StartDate", "Дата начала"}, {"EndDate", "Дата окончания"}, {"IsActive", "Активен"}
            };

            // Типы абонементов
            columnHeaders["SubscriptionTypes"] = new Dictionary<string, string>
            {
                {"TypeID", "ID"}, {"Name", "Название"}, {"Description", "Описание"},
                {"Duration", "Срок (дни)"}, {"Price", "Цена"}
            };

            // Занятия
            columnHeaders["Classes"] = new Dictionary<string, string>
            {
                {"ClassID", "ID"}, {"Name", "Название"},
                {"Description", "Описание"}, {"Duration", "Длительность (мин)"}
            };

            // Расписание
            columnHeaders["Schedule"] = new Dictionary<string, string>
            {
                {"ScheduleID", "ID"}, {"ClassName", "Занятие"}, {"TrainerName", "Тренер"},
                {"Date", "Дата"}, {"StartTime", "Время начала"}, {"MaxParticipants", "Макс. участников"}
            };

            // Тренеры
            columnHeaders["Trainers"] = new Dictionary<string, string>
            {
                {"TrainerID", "ID"}, {"LastName", "Фамилия"}, {"FirstName", "Имя"},
                {"MiddleName", "Отчество"}, {"Phone", "Телефон"}, {"Email", "Email"},
                {"HireDate", "Дата найма"}, {"Specialty", "Специализация"}
            };
        }

        private void ConfigureAccessRights()
        {
            switch (userRole)
            {
                case "Администратор": break; // Администратор имеет доступ ко всем вкладкам
                case "Тренер":
                    tabReports.Parent = null;
                    btnAddSubscriptionType.Visible = btnEditSubscriptionType.Visible = false;
                    break;
                case "Клиент":
                    tabClients.Parent = tabTrainers.Parent = tabReports.Parent = null;
                    btnAddSubscription.Visible = btnEditSubscription.Visible =
                    btnAddClass.Visible = btnEditClass.Visible = false;
                    break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e) => LoadTabData(tabControl.SelectedTab.Name);

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e) => LoadTabData(tabControl.SelectedTab.Name);

        private void LoadTabData(string tabName)
        {
            switch (tabName)
            {
                case "tabClients": LoadClients(); break;
                case "tabSubscriptions": LoadSubscriptions(); LoadSubscriptionTypes(); break;
                case "tabSchedule": LoadClasses(); LoadSchedule(); break;
                case "tabTrainers": LoadTrainers(); break;
            }
        }

        // Универсальный метод для выполнения запросов и настройки DataGridView
        private void ExecuteQuery(string query, DataGridView dgv, string headersKey,
            List<string> hideColumns = null, params NpgsqlParameter[] parameters)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);

                    if (parameters != null)
                        foreach (var param in parameters)
                            adapter.SelectCommand.Parameters.Add(param);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv.DataSource = dt;

                    // Настройка заголовков столбцов
                    if (columnHeaders.ContainsKey(headersKey))
                        foreach (var pair in columnHeaders[headersKey])
                            if (dgv.Columns.Contains(pair.Key))
                                dgv.Columns[pair.Key].HeaderText = pair.Value;

                    // Скрытие указанных столбцов
                    if (hideColumns != null)
                        foreach (var column in hideColumns)
                            if (dgv.Columns.Contains(column))
                                dgv.Columns[column].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Универсальный метод для проверки выбора строки в DataGridView
        private bool TryGetSelectedId(DataGridView dgv, string idColumn, out int id, string entityName = "запись")
        {
            id = 0;
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show($"Выберите {entityName} для действия", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            id = Convert.ToInt32(dgv.SelectedRows[0].Cells[idColumn].Value);
            return true;
        }

        // Универсальный метод для отображения форм
        private void ShowForm<T>(T form, Action onSuccess = null) where T : Form
        {
            if (form.ShowDialog() == DialogResult.OK)
                onSuccess?.Invoke();
        }

        #region Клиенты
        private void LoadClients() => ExecuteQuery(
            @"SELECT c.ClientID, c.LastName, c.FirstName, c.MiddleName, 
            c.BirthDate, c.Phone, c.Email, c.RegistrationDate
            FROM Clients c ORDER BY c.LastName, c.FirstName",
            dgvClients, "Clients", new List<string> { "ClientID" });

        private void btnAddClient_Click(object sender, EventArgs e) =>
            ShowForm(new AddClientForm(), LoadClients);

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedId(dgvClients, "ClientID", out int clientId, "клиента"))
                ShowForm(new AddClientForm(clientId), LoadClients);
        }

        private void btnViewClientSubscriptions_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedId(dgvClients, "ClientID", out int clientId, "клиента"))
                LoadClientSubscriptions(clientId);
        }

        private void LoadClientSubscriptions(int clientId) => ExecuteQuery(
            @"SELECT s.SubscriptionID, t.Name as TypeName, s.StartDate, s.EndDate, s.IsActive
            FROM Subscriptions s
            JOIN SubscriptionTypes t ON s.TypeID = t.TypeID
            WHERE s.ClientID = @ClientID ORDER BY s.EndDate DESC",
            dgvClientSubscriptions, "Subscriptions", new List<string> { "SubscriptionID" },
            new NpgsqlParameter("@ClientID", clientId));
        #endregion

        #region Абонементы
        private void LoadSubscriptions() => ExecuteQuery(
            @"SELECT s.SubscriptionID, c.LastName || ' ' || c.FirstName as ClientName, 
            t.Name as TypeName, s.StartDate, s.EndDate, s.IsActive
            FROM Subscriptions s
            JOIN Clients c ON s.ClientID = c.ClientID
            JOIN SubscriptionTypes t ON s.TypeID = t.TypeID
            ORDER BY s.EndDate DESC",
            dgvSubscriptions, "Subscriptions", new List<string> { "SubscriptionID" });

        private void LoadSubscriptionTypes() => ExecuteQuery(
            @"SELECT TypeID, Name, Description, Duration, Price
            FROM SubscriptionTypes ORDER BY Price",
            dgvSubscriptionTypes, "SubscriptionTypes", new List<string> { "TypeID" });

        private void btnAddSubscription_Click(object sender, EventArgs e) =>
            ShowForm(new AddSubscriptionForm(), LoadSubscriptions);

        private void btnEditSubscription_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedId(dgvSubscriptions, "SubscriptionID", out int id, "абонемент"))
                ShowForm(new AddSubscriptionForm(id), LoadSubscriptions);
        }

        private void btnExtendSubscription_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedId(dgvSubscriptions, "SubscriptionID", out int id, "абонемент"))
                ShowForm(new AddSubscriptionForm(id, true), LoadSubscriptions);
        }

        private void btnAddSubscriptionType_Click(object sender, EventArgs e) =>
            ShowForm(new AddSubscriptionTypeForm(), LoadSubscriptionTypes);

        private void btnEditSubscriptionType_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedId(dgvSubscriptionTypes, "TypeID", out int id, "тип абонемента"))
                ShowForm(new AddSubscriptionTypeForm(id), LoadSubscriptionTypes);
        }
        #endregion

        #region Расписание и занятия
        private void LoadClasses() => ExecuteQuery(
            @"SELECT ClassID, Name, Description, Duration
            FROM Classes ORDER BY Name",
            dgvClasses, "Classes", new List<string> { "ClassID" });

        private void LoadSchedule() => ExecuteQuery(
            @"SELECT s.ScheduleID, c.Name as ClassName, 
            t.LastName || ' ' || t.FirstName as TrainerName, 
            s.Date, s.StartTime, s.MaxParticipants
            FROM Schedule s
            JOIN Classes c ON s.ClassID = c.ClassID
            JOIN Trainers t ON s.TrainerID = t.TrainerID
            WHERE s.Date >= CURRENT_DATE
            ORDER BY s.Date, s.StartTime",
            dgvSchedule, "Schedule", new List<string> { "ScheduleID" });

        private void btnAddClass_Click(object sender, EventArgs e) =>
            ShowForm(new AddClassForm(), LoadClasses);

        private void btnEditClass_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedId(dgvClasses, "ClassID", out int id, "занятие"))
                ShowForm(new AddClassForm(id), LoadClasses);
        }

        private void btnAddScheduleItem_Click(object sender, EventArgs e) =>
            ShowForm(new AddScheduleForm(), LoadSchedule);

        private void btnEditScheduleItem_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedId(dgvSchedule, "ScheduleID", out int id, "запись в расписании"))
                ShowForm(new AddScheduleForm(id), LoadSchedule);
        }

        private void dtpScheduleDate_ValueChanged(object sender, EventArgs e) => ExecuteQuery(
            @"SELECT s.ScheduleID, c.Name as ClassName, 
            t.LastName || ' ' || t.FirstName as TrainerName, 
            s.Date, s.StartTime, s.MaxParticipants
            FROM Schedule s
            JOIN Classes c ON s.ClassID = c.ClassID
            JOIN Trainers t ON s.TrainerID = t.TrainerID
            WHERE s.Date = @Date ORDER BY s.StartTime",
            dgvSchedule, "Schedule", new List<string> { "ScheduleID" },
            new NpgsqlParameter("@Date", dtpScheduleDate.Value.Date));
        #endregion

        #region Тренеры
        private void LoadTrainers() => ExecuteQuery(
            @"SELECT TrainerID, LastName, FirstName, MiddleName, 
            Phone, Email, HireDate, Specialty
            FROM Trainers ORDER BY LastName, FirstName",
            dgvTrainers, "Trainers", new List<string> { "TrainerID" });

        private void btnAddTrainer_Click(object sender, EventArgs e) =>
            ShowForm(new AddTrainerForm(), LoadTrainers);

        private void btnEditTrainer_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedId(dgvTrainers, "TrainerID", out int id, "тренера"))
                ShowForm(new AddTrainerForm(id), LoadTrainers);
        }

        private void btnViewTrainerSchedule_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedId(dgvTrainers, "TrainerID", out int id, "тренера"))
                LoadTrainerSchedule(id);
        }

        private void LoadTrainerSchedule(int trainerId) => ExecuteQuery(
            @"SELECT s.ScheduleID, c.Name as ClassName, 
            s.Date, s.StartTime, s.MaxParticipants
            FROM Schedule s
            JOIN Classes c ON s.ClassID = c.ClassID
            WHERE s.TrainerID = @TrainerID AND s.Date >= CURRENT_DATE
            ORDER BY s.Date, s.StartTime",
            dgvTrainerSchedule, "Schedule", new List<string> { "ScheduleID" },
            new NpgsqlParameter("@TrainerID", trainerId));
        #endregion

        #region Отчеты
        private void GenerateReport(string title, string query)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ShowForm(new ReportViewerForm(title, dt));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVisitReport_Click(object sender, EventArgs e) => GenerateReport(
            "Статистика посещаемости за 30 дней",
            @"SELECT c.Name AS ClassName, COUNT(v.VisitID) AS VisitCount
            FROM Visits v
            JOIN Schedule s ON v.ScheduleID = s.ScheduleID
            JOIN Classes c ON s.ClassID = c.ClassID
            WHERE v.VisitDate >= CURRENT_DATE - INTERVAL '30 days'
            GROUP BY c.Name ORDER BY VisitCount DESC");

        private void btnIncomeReport_Click(object sender, EventArgs e) => GenerateReport(
            "Отчет по доходам за 30 дней",
            @"SELECT st.Name AS SubscriptionType, COUNT(s.SubscriptionID) AS SubscriptionCount,
            SUM(st.Price) AS TotalIncome
            FROM Subscriptions s
            JOIN SubscriptionTypes st ON s.TypeID = st.TypeID
            WHERE s.StartDate >= CURRENT_DATE - INTERVAL '30 days'
            GROUP BY st.Name ORDER BY TotalIncome DESC");

        private void btnExpiredSubscriptionsReport_Click(object sender, EventArgs e) => GenerateReport(
            "Список клиентов с истекшими абонементами",
            @"SELECT c.LastName || ' ' || c.FirstName AS ClientName, c.Phone,
            st.Name AS SubscriptionType, s.EndDate
            FROM Subscriptions s
            JOIN Clients c ON s.ClientID = c.ClientID
            JOIN SubscriptionTypes st ON s.TypeID = st.TypeID
            WHERE s.EndDate < CURRENT_DATE AND s.IsActive = true
            ORDER BY s.EndDate");
        #endregion

        // Обработчики меню
        private void выходToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            Hide();
            loginForm.FormClosed += (s, args) => Close();
            loginForm.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e) => MessageBox.Show(
            "Фитнес-клуб \"ActiveLife\"\nВерсия 1.0\n\nРазработано: FitTech",
            "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}