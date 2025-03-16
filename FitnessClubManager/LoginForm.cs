using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace FitnessManager
{
    public partial class LoginForm : Form
    {
        // Строка подключения к базе данных
        private string connectionString = DBConnection.ConnectionString;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT UserID, Password, Role FROM Users WHERE Login = @Login";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Login", login);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32(0);
                                string hashedPassword = reader.GetString(1);
                                string role = reader.GetString(2);

                                // Проверяем пароль с использованием BCrypt
                                bool passwordMatches;

                                // Проверяем, начинается ли хеш с $2a$ (BCrypt) или это старый формат
                                if (hashedPassword.StartsWith("$2a$") || hashedPassword.StartsWith("$2b$") || hashedPassword.StartsWith("$2y$"))
                                {
                                    // Используем BCrypt для проверки
                                    passwordMatches = SecurityServices.VerifyPassword(password, hashedPassword);
                                }
                                else
                                {
                                    // Старый формат - прямое сравнение
                                    passwordMatches = password == hashedPassword;

                                    // Если пароль совпал, обновляем его до BCrypt формата
                                    if (passwordMatches)
                                    {
                                        UpdatePasswordToBCrypt(userId, password);
                                    }
                                }

                                if (passwordMatches)
                                {
                                    ModernMainForm mainForm = new ModernMainForm(userId, role);
                                    this.Hide();
                                    mainForm.FormClosed += (s, args) => this.Close();
                                    mainForm.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Неверный пароль", "Ошибка авторизации",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Пользователь с таким логином не найден", "Ошибка авторизации",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для обновления пароля до BCrypt формата
        private void UpdatePasswordToBCrypt(int userId, string password)
        {
            try
            {
                string hashedPassword = SecurityServices.HashPassword(password);

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Users SET Password = @Password WHERE UserID = @UserID";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);
                        command.Parameters.AddWithValue("@Password", hashedPassword);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Логируем ошибку, но не прерываем процесс авторизации
                Console.WriteLine($"Error updating password to BCrypt: {ex.Message}");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}