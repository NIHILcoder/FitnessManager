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
                    string query = "SELECT UserID, Role FROM Users WHERE Login = @Login AND Password = @Password";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Login", login);
                        command.Parameters.AddWithValue("@Password", password);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32(0);
                                string role = reader.GetString(1);

                                ModernMainForm mainForm = new ModernMainForm(userId, role);
                                this.Hide();
                                mainForm.FormClosed += (s, args) => this.Close();
                                mainForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль", "Ошибка авторизации",
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}