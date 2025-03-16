using System;
using System.Windows.Forms;
using System.Xml.Linq;
using Npgsql;

namespace FitnessManager
{
    public partial class AddSubscriptionTypeForm : Form
    {
        private string connectionString = DBConnection.ConnectionString;
        private int typeId = 0;

        public AddSubscriptionTypeForm()
        {
            InitializeComponent();
        }

        public AddSubscriptionTypeForm(int typeId)
        {
            InitializeComponent();
            this.typeId = typeId;
            LoadTypeData();
            this.Text = "Редактирование типа абонемента";
            btnSave.Text = "Сохранить изменения";
        }

        private void LoadTypeData()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT Name, Description, Duration, Price
                                    FROM SubscriptionTypes
                                    WHERE TypeID = @TypeID";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TypeID", typeId);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["Name"].ToString();
                                txtDescription.Text = reader["Description"].ToString();
                                nudDuration.Value = Convert.ToDecimal(reader["Duration"]);
                                nudPrice.Value = Convert.ToDecimal(reader["Price"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных типа абонемента: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверка заполнения обязательных полей
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Пожалуйста, введите название типа абонемента",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();
            int duration = Convert.ToInt32(nudDuration.Value);
            decimal price = nudPrice.Value;

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string query;
                    if (typeId > 0)
                    {
                        // Обновляем тип абонемента
                        query = @"UPDATE SubscriptionTypes 
                                SET Name = @Name, Description = @Description, Duration = @Duration, Price = @Price
                                WHERE TypeID = @TypeID";
                    }
                    else
                    {
                        // Добавляем новый тип абонемента
                        query = @"INSERT INTO SubscriptionTypes 
                                (Name, Description, Duration, Price)
                                VALUES (@Name, @Description, @Duration, @Price)";
                    }

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        if (typeId > 0)
                        {
                            command.Parameters.AddWithValue("@TypeID", typeId);
                        }
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@Duration", duration);
                        command.Parameters.AddWithValue("@Price", price);

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