using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace FitnessManager
{
    public partial class AddSubscriptionForm : Form
    {
        private string connectionString = DBConnection.ConnectionString;
        private int subscriptionId = 0;
        private bool isExtending = false;

        public AddSubscriptionForm()
        {
            InitializeComponent();
            LoadClients();
            LoadSubscriptionTypes();
        }

        // Конструктор для редактирования
        public AddSubscriptionForm(int subscriptionId)
        {
            InitializeComponent();
            this.subscriptionId = subscriptionId;
            LoadClients();
            LoadSubscriptionTypes();
            LoadSubscriptionData();
            this.Text = "Редактирование абонемента";
            btnSave.Text = "Сохранить изменения";
        }

        // Конструктор для продления
        public AddSubscriptionForm(int subscriptionId, bool isExtending)
        {
            InitializeComponent();
            this.subscriptionId = subscriptionId;
            this.isExtending = isExtending;
            LoadClients();
            LoadSubscriptionTypes();
            LoadSubscriptionData();
            this.Text = "Продление абонемента";
            btnSave.Text = "Продлить";

            // Для продления клиента менять нельзя
            cmbClient.Enabled = false;
        }

        private void LoadClients()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT ClientID, LastName || ' ' || FirstName AS FullName
                                    FROM Clients
                                    ORDER BY LastName, FirstName";

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbClient.DataSource = dt;
                    cmbClient.DisplayMember = "FullName";
                    cmbClient.ValueMember = "ClientID";
                    cmbClient.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка клиентов: {ex.Message}", "Ошибка",
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
                    string query = @"SELECT TypeID, Name || ' (' || Duration || ' дней, ' || Price || ' руб.)' AS TypeInfo
                                    FROM SubscriptionTypes
                                    ORDER BY Price";

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbSubscriptionType.DataSource = dt;
                    cmbSubscriptionType.DisplayMember = "TypeInfo";
                    cmbSubscriptionType.ValueMember = "TypeID";
                    cmbSubscriptionType.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке типов абонементов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSubscriptionData()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT s.ClientID, s.TypeID, s.StartDate, s.EndDate, s.IsActive
                                    FROM Subscriptions s
                                    WHERE s.SubscriptionID = @SubscriptionID";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SubscriptionID", subscriptionId);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int clientId = reader.GetInt32(0);
                                int typeId = reader.GetInt32(1);
                                DateTime startDate = reader.GetDateTime(2);
                                DateTime endDate = reader.GetDateTime(3);
                                bool isActive = reader.GetBoolean(4);

                                cmbClient.SelectedValue = clientId;
                                cmbSubscriptionType.SelectedValue = typeId;

                                if (isExtending)
                                {
                                    // Для продления начинаем с текущей даты или даты окончания, если она в будущем
                                    DateTime now = DateTime.Now.Date;
                                    dtpStartDate.Value = endDate > now ? endDate : now;

                                    // Конечная дата будет установлена при выборе типа абонемента
                                }
                                else
                                {
                                    dtpStartDate.Value = startDate;
                                    dtpEndDate.Value = endDate;
                                }

                                chkIsActive.Checked = isActive;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных абонемента: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверка заполнения обязательных полей
            if (cmbClient.SelectedIndex == -1 || cmbSubscriptionType.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите клиента и тип абонемента",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clientId = Convert.ToInt32(cmbClient.SelectedValue);
            int typeId = Convert.ToInt32(cmbSubscriptionType.SelectedValue);
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;
            bool isActive = chkIsActive.Checked;

            // Проверка дат
            if (endDate <= startDate)
            {
                MessageBox.Show("Дата окончания должна быть позже даты начала",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query;
                    if (subscriptionId > 0 && !isExtending)
                    {
                        // Обновляем абонемент
                        query = @"UPDATE Subscriptions 
                                SET ClientID = @ClientID, TypeID = @TypeID, StartDate = @StartDate, 
                                EndDate = @EndDate, IsActive = @IsActive
                                WHERE SubscriptionID = @SubscriptionID";
                    }
                    else
                    {
                        // Добавляем новый абонемент (или продлеваем - создаем новый)
                        query = @"INSERT INTO Subscriptions 
                                (ClientID, TypeID, StartDate, EndDate, IsActive)
                                VALUES (@ClientID, @TypeID, @StartDate, @EndDate, @IsActive)";
                    }

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        if (subscriptionId > 0 && !isExtending)
                        {
                            command.Parameters.AddWithValue("@SubscriptionID", subscriptionId);
                        }
                        command.Parameters.AddWithValue("@ClientID", clientId);
                        command.Parameters.AddWithValue("@TypeID", typeId);
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                        command.Parameters.AddWithValue("@IsActive", isActive);

                        command.ExecuteNonQuery();
                    }

                    // Если это продление, деактивируем старый абонемент
                    if (isExtending)
                    {
                        query = @"UPDATE Subscriptions SET IsActive = false WHERE SubscriptionID = @SubscriptionID";
                        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@SubscriptionID", subscriptionId);
                            command.ExecuteNonQuery();
                        }
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

        private void cmbSubscriptionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Устанавливаем дату окончания на основе выбранного типа абонемента
            if (cmbSubscriptionType.SelectedIndex != -1)
            {
                try
                {
                    // Получаем выбранное значение ID типа абонемента
                    int typeId = Convert.ToInt32(cmbSubscriptionType.SelectedValue);

                    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "SELECT Duration FROM SubscriptionTypes WHERE TypeID = @TypeID";

                        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@TypeID", typeId);
                            int duration = Convert.ToInt32(command.ExecuteScalar());

                            // Устанавливаем дату окончания
                            dtpEndDate.Value = dtpStartDate.Value.AddDays(duration);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при определении длительности абонемента: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            // Обновляем дату окончания при изменении даты начала
            if (cmbSubscriptionType.SelectedIndex != -1)
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "SELECT Duration FROM SubscriptionTypes WHERE TypeID = @TypeID";

                        using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@TypeID", Convert.ToInt32(cmbSubscriptionType.SelectedValue));
                            int duration = Convert.ToInt32(command.ExecuteScalar());

                            // Устанавливаем дату окончания
                            dtpEndDate.Value = dtpStartDate.Value.AddDays(duration);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при определении длительности абонемента: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}