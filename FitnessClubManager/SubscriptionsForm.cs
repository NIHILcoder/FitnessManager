using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace FitnessManager
{
    public partial class SubscriptionsForm : Form
    {
        private string connectionString = DBConnection.ConnectionString;
        private string userRole;

        public SubscriptionsForm(string userRole)
        {
            InitializeComponent();
            this.userRole = userRole;

            // Настройка доступа в зависимости от роли пользователя
            ConfigureAccessRights();

            // Загрузка данных
            LoadSubscriptions();
            LoadSubscriptionTypes();
        }

        private void ConfigureAccessRights()
        {
            // Настройка видимости элементов управления в зависимости от роли
            if (userRole != "Администратор")
            {
                btnAddSubscriptionType.Visible = false;
                btnEditSubscriptionType.Visible = false;
            }

            if (userRole == "Клиент")
            {
                btnAddSubscription.Visible = false;
                btnEditSubscription.Visible = false;
            }
        }

        private void LoadSubscriptions()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT s.SubscriptionID, c.LastName || ' ' || c.FirstName as ClientName, 
                                   t.Name as TypeName, s.StartDate, s.EndDate, s.IsActive, s.AutoRenew
                                   FROM Subscriptions s
                                   JOIN Clients c ON s.ClientID = c.ClientID
                                   JOIN SubscriptionTypes t ON s.TypeID = t.TypeID
                                   ORDER BY s.EndDate DESC";

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvSubscriptions.DataSource = dt;

                    // Настройка отображения заголовков
                    if (dgvSubscriptions.Columns.Contains("SubscriptionID"))
                        dgvSubscriptions.Columns["SubscriptionID"].Visible = false;
                    if (dgvSubscriptions.Columns.Contains("ClientName"))
                        dgvSubscriptions.Columns["ClientName"].HeaderText = "Клиент";
                    if (dgvSubscriptions.Columns.Contains("TypeName"))
                        dgvSubscriptions.Columns["TypeName"].HeaderText = "Тип абонемента";
                    if (dgvSubscriptions.Columns.Contains("StartDate"))
                        dgvSubscriptions.Columns["StartDate"].HeaderText = "Дата начала";
                    if (dgvSubscriptions.Columns.Contains("EndDate"))
                        dgvSubscriptions.Columns["EndDate"].HeaderText = "Дата окончания";
                    if (dgvSubscriptions.Columns.Contains("IsActive"))
                        dgvSubscriptions.Columns["IsActive"].HeaderText = "Активен";
                    if (dgvSubscriptions.Columns.Contains("AutoRenew"))
                        dgvSubscriptions.Columns["AutoRenew"].HeaderText = "Автопродление";

                    // Раскрашивание строк в зависимости от статуса
                    foreach (DataGridViewRow row in dgvSubscriptions.Rows)
                    {
                        bool isActive = (bool)row.Cells["IsActive"].Value;
                        DateTime endDate = (DateTime)row.Cells["EndDate"].Value;

                        if (!isActive)
                        {
                            // Неактивные абонементы - серые
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                        }
                        else if (endDate < DateTime.Now)
                        {
                            // Истекшие активные абонементы - светло-красные
                            row.DefaultCellStyle.BackColor = Color.MistyRose;
                        }
                        else if (endDate < DateTime.Now.AddDays(7))
                        {
                            // Активные абонементы, которые истекают в течение недели - светло-желтые
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке абонементов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSubscriptionTypes()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT TypeID, Name, Description, Duration, Price
                                   FROM SubscriptionTypes ORDER BY Price";

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvSubscriptionTypes.DataSource = dt;

                    // Настройка отображения заголовков
                    if (dgvSubscriptionTypes.Columns.Contains("TypeID"))
                        dgvSubscriptionTypes.Columns["TypeID"].Visible = false;
                    if (dgvSubscriptionTypes.Columns.Contains("Name"))
                        dgvSubscriptionTypes.Columns["Name"].HeaderText = "Название";
                    if (dgvSubscriptionTypes.Columns.Contains("Description"))
                        dgvSubscriptionTypes.Columns["Description"].HeaderText = "Описание";
                    if (dgvSubscriptionTypes.Columns.Contains("Duration"))
                        dgvSubscriptionTypes.Columns["Duration"].HeaderText = "Срок (дни)";
                    if (dgvSubscriptionTypes.Columns.Contains("Price"))
                        dgvSubscriptionTypes.Columns["Price"].HeaderText = "Цена";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке типов абонементов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddSubscription_Click(object sender, EventArgs e)
        {
            // Создание нового абонемента
            AddSubscriptionForm form = new AddSubscriptionForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadSubscriptions();
            }
        }

        private void btnEditSubscription_Click(object sender, EventArgs e)
        {
            // Редактирование абонемента
            if (dgvSubscriptions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите абонемент для редактирования", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int subscriptionId = Convert.ToInt32(dgvSubscriptions.SelectedRows[0].Cells["SubscriptionID"].Value);

            AddSubscriptionForm form = new AddSubscriptionForm(subscriptionId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadSubscriptions();
            }
        }

        private void btnExtendSubscription_Click(object sender, EventArgs e)
        {
            // Продление абонемента
            if (dgvSubscriptions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите абонемент для продления", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int subscriptionId = Convert.ToInt32(dgvSubscriptions.SelectedRows[0].Cells["SubscriptionID"].Value);

            AddSubscriptionForm form = new AddSubscriptionForm(subscriptionId, true);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadSubscriptions();
            }
        }

        private void btnToggleAutoRenew_Click(object sender, EventArgs e)
        {
            // Включение/выключение автопродления
            if (dgvSubscriptions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите абонемент для изменения автопродления", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int subscriptionId = Convert.ToInt32(dgvSubscriptions.SelectedRows[0].Cells["SubscriptionID"].Value);
                bool currentAutoRenew = (bool)dgvSubscriptions.SelectedRows[0].Cells["AutoRenew"].Value;
                bool newAutoRenew = !currentAutoRenew;

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"UPDATE Subscriptions 
                                   SET AutoRenew = @AutoRenew
                                   WHERE SubscriptionID = @SubscriptionID";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SubscriptionID", subscriptionId);
                        command.Parameters.AddWithValue("@AutoRenew", newAutoRenew);
                        command.ExecuteNonQuery();
                    }
                }

                LoadSubscriptions();

                MessageBox.Show(
                    newAutoRenew
                        ? "Автопродление успешно включено"
                        : "Автопродление успешно отключено",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении статуса автопродления: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddSubscriptionType_Click(object sender, EventArgs e)
        {
            // Добавление нового типа абонемента
            AddSubscriptionTypeForm form = new AddSubscriptionTypeForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadSubscriptionTypes();
            }
        }

        private void btnEditSubscriptionType_Click(object sender, EventArgs e)
        {
            // Редактирование типа абонемента
            if (dgvSubscriptionTypes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите тип абонемента для редактирования", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int typeId = Convert.ToInt32(dgvSubscriptionTypes.SelectedRows[0].Cells["TypeID"].Value);

            AddSubscriptionTypeForm form = new AddSubscriptionTypeForm(typeId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadSubscriptionTypes();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Фильтрация абонементов по введенному тексту
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadSubscriptions();
                return;
            }

            try
            {
                // Получаем исходную таблицу
                DataTable dt = dgvSubscriptions.DataSource as DataTable;
                if (dt == null) return;

                // Создаем новую отфильтрованную представление данных
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("ClientName LIKE '%{0}%' OR TypeName LIKE '%{0}%'",
                    txtSearch.Text.Replace("'", "''"));

                dgvSubscriptions.DataSource = dv.ToTable();

                // Сохраняем форматирование
                foreach (DataGridViewRow row in dgvSubscriptions.Rows)
                {
                    bool isActive = (bool)row.Cells["IsActive"].Value;
                    DateTime endDate = (DateTime)row.Cells["EndDate"].Value;

                    if (!isActive)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else if (endDate < DateTime.Now)
                    {
                        row.DefaultCellStyle.BackColor = Color.MistyRose;
                    }
                    else if (endDate < DateTime.Now.AddDays(7))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                }
            }
            catch (Exception ex)
            {
                // Ошибки в фильтрации игнорируем
                Console.WriteLine($"Error filtering subscriptions: {ex.Message}");
            }
        }

        private void btnRunAutoRenewal_Click(object sender, EventArgs e)
        {
            // Запуск процесса автоматического продления абонементов
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Вызов функции автопродления
                    string query = "SELECT auto_renew_subscriptions()";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                LoadSubscriptions();
                MessageBox.Show("Процесс автопродления абонементов выполнен успешно",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении автопродления: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}