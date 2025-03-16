using System;
using System.Windows.Forms;
using Npgsql;

namespace FitnessManager
{
    public partial class AddClientForm : Form
    {
        private string connectionString = DBConnection.ConnectionString;
        private int userId = 0; // 0 означает, что это новый клиент

        // Enum для уровней активности
        public enum ActivityLevel
        {
            Низкий,
            Средний,
            Высокий,
            Профессиональный
        }

        public AddClientForm()
        {
            InitializeComponent();
            InitializeActivityLevels();
        }

        // Конструктор для редактирования клиента
        public AddClientForm(int clientId)
        {
            InitializeComponent();
            InitializeActivityLevels();
            LoadClientData(clientId);
        }

        // Инициализация комбобокса с уровнями активности
        private void InitializeActivityLevels()
        {
            cmbActivityLevel.Items.Clear();
            foreach (ActivityLevel level in Enum.GetValues(typeof(ActivityLevel)))
            {
                cmbActivityLevel.Items.Add(level.ToString());
            }
            cmbActivityLevel.SelectedIndex = 1; // По умолчанию средний уровень
        }

        private void LoadClientData(int clientId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT c.LastName, c.FirstName, c.MiddleName, c.BirthDate, 
                                    c.Phone, c.Email, c.UserID, c.ActivityLevel, c.Notes
                                    FROM Clients c
                                    WHERE c.ClientID = @ClientID";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClientID", clientId);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtLastName.Text = reader["LastName"].ToString();
                                txtFirstName.Text = reader["FirstName"].ToString();
                                txtMiddleName.Text = reader["MiddleName"].ToString();
                                dtpBirthDate.Value = Convert.ToDateTime(reader["BirthDate"]);
                                txtPhone.Text = reader["Phone"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                userId = Convert.ToInt32(reader["UserID"]);

                                // Загружаем дополнительные поля
                                if (!reader.IsDBNull(reader.GetOrdinal("ActivityLevel")))
                                {
                                    string activityLevel = reader["ActivityLevel"].ToString();
                                    int index = cmbActivityLevel.FindStringExact(activityLevel);
                                    if (index >= 0)
                                        cmbActivityLevel.SelectedIndex = index;
                                }

                                if (!reader.IsDBNull(reader.GetOrdinal("Notes")))
                                {
                                    rtbNotes.Text = reader["Notes"].ToString();
                                }

                                this.Text = "Редактирование клиента";
                                btnSave.Text = "Сохранить изменения";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных клиента: {ex.Message}", "Ошибка",
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

                    // Если это новый клиент и нужно создать пользователя
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
                        string userQuery = "INSERT INTO Users (Login, Password, Role) VALUES (@Login, @Password, 'Клиент') RETURNING UserID";
                        using (NpgsqlCommand userCommand = new NpgsqlCommand(userQuery, connection))
                        {
                            userCommand.Parameters.AddWithValue("@Login", login);
                            userCommand.Parameters.AddWithValue("@Password", password);
                            userId = Convert.ToInt32(userCommand.ExecuteScalar());
                        }
                    }

                    // Добавляем или обновляем клиента
                    string query;
                    if (this.Text.Contains("Редактирование"))
                    {
                        // Обновляем данные клиента
                        query = @"UPDATE Clients 
                                SET LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName,
                                BirthDate = @BirthDate, Phone = @Phone, Email = @Email, ActivityLevel = @ActivityLevel, Notes = @Notes
                                WHERE UserID = @UserID";
                    }
                    else
                    {
                        // Добавляем нового клиента
                        query = @"INSERT INTO Clients 
                                (UserID, LastName, FirstName, MiddleName, BirthDate, Phone, Email, RegistrationDate, ActivityLevel, Notes)
                                VALUES (@UserID, @LastName, @FirstName, @MiddleName, @BirthDate, @Phone, @Email, CURRENT_DATE, @ActivityLevel, @Notes)";
                    }

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);
                        command.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                        command.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                        command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text.Trim());
                        command.Parameters.AddWithValue("@BirthDate", dtpBirthDate.Value);
                        command.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                        command.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        command.Parameters.AddWithValue("@ActivityLevel", cmbActivityLevel.SelectedItem?.ToString());
                        command.Parameters.AddWithValue("@Notes", rtbNotes.Text.Trim());

                        command.ExecuteNonQuery();
                    }

                    // Логирование изменений
                    LogClientChange(userId, this.Text.Contains("Редактирование") ? "Update" : "Create");

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

        // Метод для логирования изменений клиента
        private void LogClientChange(int userId, string changeType)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO client_history (client_id, change_date, change_type, changed_by)
                                    VALUES ((SELECT ClientID FROM Clients WHERE UserID = @UserID), CURRENT_TIMESTAMP, @ChangeType, @ChangedBy)";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);
                        command.Parameters.AddWithValue("@ChangeType", changeType);
                        command.Parameters.AddWithValue("@ChangedBy", ModernMainForm.CurrentUserID); // Передаем ID текущего пользователя

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // В данном случае просто логируем ошибку, но не прерываем основную операцию
                Console.WriteLine($"Error logging client change: {ex.Message}");
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

        // Новые методы для работы с заметками
        private void btnFormatBold_Click(object sender, EventArgs e)
        {
            // Применяем жирный шрифт к выделенному тексту
            if (rtbNotes.SelectionFont != null)
            {
                System.Drawing.Font currentFont = rtbNotes.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (currentFont.Bold)
                    newFontStyle = currentFont.Style & ~System.Drawing.FontStyle.Bold;
                else
                    newFontStyle = currentFont.Style | System.Drawing.FontStyle.Bold;

                rtbNotes.SelectionFont = new System.Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void btnFormatItalic_Click(object sender, EventArgs e)
        {
            // Применяем курсив к выделенному тексту
            if (rtbNotes.SelectionFont != null)
            {
                System.Drawing.Font currentFont = rtbNotes.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (currentFont.Italic)
                    newFontStyle = currentFont.Style & ~System.Drawing.FontStyle.Italic;
                else
                    newFontStyle = currentFont.Style | System.Drawing.FontStyle.Italic;

                rtbNotes.SelectionFont = new System.Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void btnFormatUnderline_Click(object sender, EventArgs e)
        {
            // Применяем подчеркивание к выделенному тексту
            if (rtbNotes.SelectionFont != null)
            {
                System.Drawing.Font currentFont = rtbNotes.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (currentFont.Underline)
                    newFontStyle = currentFont.Style & ~System.Drawing.FontStyle.Underline;
                else
                    newFontStyle = currentFont.Style | System.Drawing.FontStyle.Underline;

                rtbNotes.SelectionFont = new System.Drawing.Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }
    }
}