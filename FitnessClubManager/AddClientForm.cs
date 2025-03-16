using System;
using System.Windows.Forms;
using Npgsql;

namespace FitnessManager
{
    public partial class AddClientForm : Form
    {
        private string connectionString = DBConnection.ConnectionString;
        private int userId = 0; // 0 означает, что это новый клиент

        public AddClientForm()
        {
            InitializeComponent();
        }

        // Конструктор для редактирования клиента
        public AddClientForm(int clientId)
        {
            InitializeComponent();
            LoadClientData(clientId);
        }

        private void LoadClientData(int clientId)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT c.LastName, c.FirstName, c.MiddleName, c.BirthDate, 
                                    c.Phone, c.Email, c.UserID
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
                                BirthDate = @BirthDate, Phone = @Phone, Email = @Email
                                WHERE UserID = @UserID";
                    }
                    else
                    {
                        // Добавляем нового клиента
                        query = @"INSERT INTO Clients 
                                (UserID, LastName, FirstName, MiddleName, BirthDate, Phone, Email, RegistrationDate)
                                VALUES (@UserID, @LastName, @FirstName, @MiddleName, @BirthDate, @Phone, @Email, CURRENT_DATE)";
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

        private void chkCreateAccount_CheckedChanged(object sender, EventArgs e)
        {
            // Показываем или скрываем панель создания учетной записи
            panelAccount.Visible = chkCreateAccount.Checked;
        }
    }
}