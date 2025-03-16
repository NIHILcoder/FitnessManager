using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace FitnessManager
{
    public partial class ModernClientsForm : Form
    {
        private string connectionString = DBConnection.ConnectionString;
        private readonly Dictionary<string, string> columnHeaders;
        private readonly string userRole;

        // ID выбранного клиента для просмотра абонементов
        private int selectedClientId = 0;

        public ModernClientsForm(string userRole)
        {
            InitializeComponent();
            this.userRole = userRole;

            // Инициализация заголовков столбцов
            columnHeaders = new Dictionary<string, string>
            {
                {"ClientID", "ID"}, {"LastName", "Фамилия"}, {"FirstName", "Имя"},
                {"MiddleName", "Отчество"}, {"BirthDate", "Дата рождения"},
                {"Phone", "Телефон"}, {"Email", "Email"}, {"RegistrationDate", "Дата регистрации"},
                {"ActivityLevel", "Уровень активности"}
            };

            // Настройка элементов управления в зависимости от роли
            ConfigureAccessRights();

            // Заполняем фильтр активности
            cmbActivityFilter.Items.Clear();
            cmbActivityFilter.Items.Add("Все уровни");
            foreach (var level in Enum.GetValues(typeof(AddClientForm.ActivityLevel)))
            {
                cmbActivityFilter.Items.Add(level.ToString());
            }
            cmbActivityFilter.SelectedIndex = 0;

            // Загружаем клиентов
            LoadClients();
        }

        private void ConfigureAccessRights()
        {
            // В зависимости от роли можно ограничить доступ к кнопкам
            if (userRole != "Администратор")
            {
                btnEditClient.Visible = false;
            }
        }

        // Загрузка клиентов с возможностью фильтрации
        private void LoadClients(string activityFilter = null)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT c.ClientID, c.LastName, c.FirstName, c.MiddleName, 
                                    c.BirthDate, c.Phone, c.Email, c.RegistrationDate, c.ActivityLevel
                                    FROM Clients c
                                    {0}
                                    ORDER BY c.LastName, c.FirstName";

                    string whereClause = string.IsNullOrEmpty(activityFilter) ?
                        "" : "WHERE c.ActivityLevel = @ActivityLevel";

                    query = string.Format(query, whereClause);

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(activityFilter))
                        {
                            command.Parameters.AddWithValue("@ActivityLevel", activityFilter);
                        }

                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvClients.DataSource = dt;

                        // Настройка отображения заголовков
                        foreach (var pair in columnHeaders)
                        {
                            if (dgvClients.Columns.Contains(pair.Key))
                                dgvClients.Columns[pair.Key].HeaderText = pair.Value;
                        }

                        // Скрытие ID
                        if (dgvClients.Columns.Contains("ClientID"))
                            dgvClients.Columns["ClientID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных клиентов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузка абонементов выбранного клиента
        private void LoadClientSubscriptions(int clientId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT s.SubscriptionID, t.Name as TypeName, 
                                    s.StartDate, s.EndDate, s.IsActive, s.AutoRenew
                                    FROM Subscriptions s
                                    JOIN SubscriptionTypes t ON s.TypeID = t.TypeID
                                    WHERE s.ClientID = @ClientID ORDER BY s.EndDate DESC";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClientID", clientId);

                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvClientSubscriptions.DataSource = dt;

                        // Настройка отображения заголовков
                        if (dgvClientSubscriptions.Columns.Contains("TypeName"))
                            dgvClientSubscriptions.Columns["TypeName"].HeaderText = "Тип абонемента";
                        if (dgvClientSubscriptions.Columns.Contains("StartDate"))
                            dgvClientSubscriptions.Columns["StartDate"].HeaderText = "Дата начала";
                        if (dgvClientSubscriptions.Columns.Contains("EndDate"))
                            dgvClientSubscriptions.Columns["EndDate"].HeaderText = "Дата окончания";
                        if (dgvClientSubscriptions.Columns.Contains("IsActive"))
                            dgvClientSubscriptions.Columns["IsActive"].HeaderText = "Активен";
                        if (dgvClientSubscriptions.Columns.Contains("AutoRenew"))
                            dgvClientSubscriptions.Columns["AutoRenew"].HeaderText = "Автопродление";

                        // Скрытие ID
                        if (dgvClientSubscriptions.Columns.Contains("SubscriptionID"))
                            dgvClientSubscriptions.Columns["SubscriptionID"].Visible = false;
                    }
                }

                // Загружаем заметки о клиенте
                LoadClientNotes(clientId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке абонементов клиента: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузка заметок о клиенте
        private void LoadClientNotes(int clientId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Notes FROM Clients WHERE ClientID = @ClientID";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClientID", clientId);

                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            rtbNotes.Text = result.ToString();
                        }
                        else
                        {
                            rtbNotes.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке заметок клиента: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузка истории изменений клиента
        private void LoadClientHistory(int clientId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT ch.change_date, ch.change_type, 
                                    COALESCE(u.Login, 'Система') as changed_by
                                    FROM client_history ch
                                    LEFT JOIN Users u ON ch.changed_by = u.UserID
                                    WHERE ch.client_id = @ClientID
                                    ORDER BY ch.change_date DESC";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClientID", clientId);

                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvHistory.DataSource = dt;

                        // Настройка отображения
                        if (dgvHistory.Columns.Contains("change_date"))
                            dgvHistory.Columns["change_date"].HeaderText = "Дата изменения";
                        if (dgvHistory.Columns.Contains("change_type"))
                            dgvHistory.Columns["change_type"].HeaderText = "Тип изменения";
                        if (dgvHistory.Columns.Contains("changed_by"))
                            dgvHistory.Columns["changed_by"].HeaderText = "Кем изменено";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке истории клиента: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            AddClientForm form = new AddClientForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadClients(cmbActivityFilter.SelectedIndex == 0 ? null : cmbActivityFilter.SelectedItem.ToString());
            }
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента для редактирования", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clientId = Convert.ToInt32(dgvClients.SelectedRows[0].Cells["ClientID"].Value);

            AddClientForm form = new AddClientForm(clientId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadClients(cmbActivityFilter.SelectedIndex == 0 ? null : cmbActivityFilter.SelectedItem.ToString());

                // Если это был клиент, детали которого отображаются
                if (clientId == selectedClientId)
                {
                    LoadClientSubscriptions(selectedClientId);
                    LoadClientHistory(selectedClientId);
                }
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента для просмотра деталей", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedClientId = Convert.ToInt32(dgvClients.SelectedRows[0].Cells["ClientID"].Value);
            string clientName =
                $"{dgvClients.SelectedRows[0].Cells["LastName"].Value} {dgvClients.SelectedRows[0].Cells["FirstName"].Value}";

            // Обновляем заголовок вкладки с деталями
            tabDetails.Text = $"Детали: {clientName}";

            LoadClientSubscriptions(selectedClientId);
            LoadClientHistory(selectedClientId);

            // Переключаемся на вкладку с деталями
            tabClients.SelectedTab = tabDetails;
        }

        private void cmbActivityFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbActivityFilter.SelectedIndex == 0)
            {
                // "Все уровни"
                LoadClients();
            }
            else
            {
                // Конкретный уровень активности
                LoadClients(cmbActivityFilter.SelectedItem.ToString());
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadClients(cmbActivityFilter.SelectedIndex == 0 ? null : cmbActivityFilter.SelectedItem.ToString());
                return;
            }

            try
            {
                // Получаем исходную таблицу
                DataTable dt = dgvClients.DataSource as DataTable;
                if (dt == null) return;

                // Создаем новую отфильтрованную представление данных
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("LastName LIKE '%{0}%' OR FirstName LIKE '%{0}%' OR Phone LIKE '%{0}%'",
                    txtSearch.Text.Replace("'", "''"));

                dgvClients.DataSource = dv.ToTable();

                // Восстанавливаем заголовки
                foreach (var pair in columnHeaders)
                {
                    if (dgvClients.Columns.Contains(pair.Key))
                        dgvClients.Columns[pair.Key].HeaderText = pair.Value;
                }

                // Скрытие ID
                if (dgvClients.Columns.Contains("ClientID"))
                    dgvClients.Columns["ClientID"].Visible = false;
            }
            catch (Exception ex)
            {
                // Ошибки в фильтрации игнорируем
                Console.WriteLine($"Error filtering clients: {ex.Message}");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Возвращаемся к списку клиентов
            tabClients.SelectedTab = tabList;
        }
    }
}