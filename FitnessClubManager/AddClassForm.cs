using System;
using System.Windows.Forms;
using System.Xml.Linq;
using Npgsql;

namespace FitnessManager
{
    public partial class AddClassForm : Form
    {
        private string connectionString = DBConnection.ConnectionString;
        private int classId = 0;

        public AddClassForm()
        {
            InitializeComponent();
        }

        public AddClassForm(int classId)
        {
            InitializeComponent();
            this.classId = classId;
            LoadClassData();
            this.Text = "Редактирование занятия";
            btnSave.Text = "Сохранить изменения";
        }

        private void LoadClassData()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT Name, Description, Duration
                                    FROM Classes
                                    WHERE ClassID = @ClassID";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClassID", classId);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["Name"].ToString();
                                txtDescription.Text = reader["Description"].ToString();
                                nudDuration.Value = Convert.ToDecimal(reader["Duration"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных занятия: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверка заполнения обязательных полей
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Пожалуйста, введите название занятия",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();
            int duration = Convert.ToInt32(nudDuration.Value);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query;
                    if (classId > 0)
                    {
                        // Обновляем занятие
                        query = @"UPDATE Classes 
                                SET Name = @Name, Description = @Description, Duration = @Duration
                                WHERE ClassID = @ClassID";
                    }
                    else
                    {
                        // Добавляем новое занятие
                        query = @"INSERT INTO Classes 
                                (Name, Description, Duration)
                                VALUES (@Name, @Description, @Duration)";
                    }

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        if (classId > 0)
                        {
                            command.Parameters.AddWithValue("@ClassID", classId);
                        }
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@Duration", duration);

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
    }
}