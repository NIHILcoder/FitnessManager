using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace FitnessManager
{
    public partial class ReportsForm : Form
    {
        private string connectionString = DBConnection.ConnectionString;
        private string userRole;
        private bool paymentsTableInitialized = false;

        public ReportsForm(string userRole)
        {
            InitializeComponent();
            this.userRole = userRole;

            // Проверка прав доступа и настройка интерфейса
            ConfigureAccessRights();

            // Проверяем наличие таблицы платежей при загрузке формы
            CheckPaymentsTable();
        }

        private void ConfigureAccessRights()
        {
            // Отчеты могут просматривать только администраторы
            if (userRole != "Администратор")
            {
                MessageBox.Show("У вас нет прав для просмотра отчетов",
                    "Ограничение доступа", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Скрываем все кнопки отчетов
                btnVisitStatistics.Visible = false;
                btnClientsExpired.Visible = false;
                btnIncomeReport.Visible = false;
            }
        }

        private void CheckPaymentsTable()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = @"
                        SELECT EXISTS (
                            SELECT FROM information_schema.tables 
                            WHERE table_name = 'payments'
                        );
                    ";

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        paymentsTableInitialized = (bool)command.ExecuteScalar();
                    }
                }

                // Если таблица не существует, предложим создать её
                if (!paymentsTableInitialized && userRole == "Администратор")
                {
                    if (MessageBox.Show("Таблица платежей (payments) не существует в базе данных. Хотите создать её сейчас?",
                            "Таблица не найдена", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        paymentsTableInitialized = DatabaseInitializer.InitializePaymentsTable();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при проверке таблицы платежей: {ex.Message}");
            }
        }

        private void btnVisitStatistics_Click(object sender, EventArgs e)
        {
            // Открываем форму статистики посещений
            VisitStatisticsForm visitStatistics = new VisitStatisticsForm();
            visitStatistics.ShowDialog();
        }

        private void btnClientsExpired_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Формируем запрос для получения клиентов с истекшими абонементами
                    string query = @"
                        SELECT 
                            c.ClientID,
                            c.LastName || ' ' || c.FirstName as ClientName,
                            c.Phone,
                            c.Email,
                            s.EndDate,
                            t.Name as SubscriptionType,
                            CURRENT_DATE - s.EndDate as DaysExpired
                        FROM 
                            Clients c
                            JOIN Subscriptions s ON c.ClientID = s.ClientID
                            JOIN SubscriptionTypes t ON s.TypeID = t.TypeID
                        WHERE 
                            s.EndDate < CURRENT_DATE
                            AND s.IsActive = true
                        ORDER BY 
                            s.EndDate DESC";

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Открываем форму просмотра отчета
                    ReportViewerForm reportViewer = new ReportViewerForm("Клиенты с истекшими абонементами", dt);
                    reportViewer.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIncomeReport_Click(object sender, EventArgs e)
        {
            // Если таблица платежей не инициализирована, предложим создать её
            if (!paymentsTableInitialized)
            {
                if (MessageBox.Show("Таблица платежей (payments) не существует в базе данных. Хотите создать её сейчас?",
                        "Таблица не найдена", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    paymentsTableInitialized = DatabaseInitializer.InitializePaymentsTable();
                    if (!paymentsTableInitialized)
                    {
                        // Если не удалось создать таблицу, выходим
                        return;
                    }
                }
                else
                {
                    // Если пользователь отказался создавать таблицу, выходим
                    return;
                }
            }

            try
            {
                // Создаем форму для выбора периода
                Form periodForm = new Form();
                periodForm.Text = "Выбор периода отчета";
                periodForm.Size = new System.Drawing.Size(400, 200);
                periodForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                periodForm.StartPosition = FormStartPosition.CenterParent;
                periodForm.MaximizeBox = false;
                periodForm.MinimizeBox = false;

                // Добавляем элементы управления
                Label lblPeriod = new Label();
                lblPeriod.Text = "Выберите период:";
                lblPeriod.Location = new System.Drawing.Point(20, 20);
                lblPeriod.Size = new System.Drawing.Size(150, 25);

                ComboBox cmbPeriod = new ComboBox();
                cmbPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbPeriod.Items.AddRange(new object[] {
                    "Текущий месяц",
                    "Предыдущий месяц",
                    "Текущий квартал",
                    "Текущий год"
                });
                cmbPeriod.Location = new System.Drawing.Point(180, 20);
                cmbPeriod.Size = new System.Drawing.Size(180, 25);
                cmbPeriod.SelectedIndex = 0;

                Button btnOk = new Button();
                btnOk.Text = "Сформировать";
                btnOk.DialogResult = DialogResult.OK;
                btnOk.Location = new System.Drawing.Point(150, 100);
                btnOk.Size = new System.Drawing.Size(100, 30);

                // Добавляем элементы на форму
                periodForm.Controls.Add(lblPeriod);
                periodForm.Controls.Add(cmbPeriod);
                periodForm.Controls.Add(btnOk);

                if (periodForm.ShowDialog() == DialogResult.OK)
                {
                    // Определяем параметры периода
                    string periodCondition = "";
                    string periodTitle = "";

                    switch (cmbPeriod.SelectedIndex)
                    {
                        case 0: // Текущий месяц
                            periodCondition = "AND date_trunc('month', p.PaymentDate) = date_trunc('month', CURRENT_DATE)";
                            periodTitle = $"за {DateTime.Now:MMMM yyyy}";
                            break;
                        case 1: // Предыдущий месяц
                            periodCondition = "AND date_trunc('month', p.PaymentDate) = date_trunc('month', CURRENT_DATE - INTERVAL '1 month')";
                            periodTitle = $"за {DateTime.Now.AddMonths(-1):MMMM yyyy}";
                            break;
                        case 2: // Текущий квартал
                            periodCondition = "AND date_trunc('quarter', p.PaymentDate) = date_trunc('quarter', CURRENT_DATE)";
                            periodTitle = $"за {GetQuarterTitle(DateTime.Now)}";
                            break;
                        case 3: // Текущий год
                            periodCondition = "AND date_part('year', p.PaymentDate) = date_part('year', CURRENT_DATE)";
                            periodTitle = $"за {DateTime.Now.Year} год";
                            break;
                    }

                    // Формируем запрос для отчета
                    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = $@"
                            SELECT 
                                p.PaymentDate::date as Date,
                                t.Name as SubscriptionType,
                                COUNT(*) as Quantity,
                                SUM(p.Amount) as TotalAmount
                            FROM 
                                Payments p
                                JOIN Subscriptions s ON p.SubscriptionID = s.SubscriptionID
                                JOIN SubscriptionTypes t ON s.TypeID = t.TypeID
                            WHERE 
                                p.PaymentDate IS NOT NULL
                                {periodCondition}
                            GROUP BY 
                                p.PaymentDate::date, t.Name
                            ORDER BY 
                                p.PaymentDate::date DESC, t.Name";

                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Открываем форму просмотра отчета
                        ReportViewerForm reportViewer = new ReportViewerForm($"Отчет по доходам {periodTitle}", dt);
                        reportViewer.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetQuarterTitle(DateTime date)
        {
            int quarter = (date.Month - 1) / 3 + 1;
            return $"{quarter} квартал {date.Year} года";
        }
    }
}