using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace FitnessManager
{
    public static class DatabaseInitializer
    {
        private static string connectionString = DBConnection.ConnectionString;

        /// <summary>
        /// Инициализирует таблицу платежей в базе данных
        /// </summary>
        public static bool InitializePaymentsTable()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Проверяем, существует ли уже таблица Payments
                    bool tableExists = CheckIfTableExists("payments");
                    if (tableExists)
                    {
                        MessageBox.Show("Таблица платежей уже существует в базе данных.",
                            "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }

                    // Создаем таблицу Payments
                    string createTableSQL = @"
                        CREATE TABLE Payments (
                            PaymentID SERIAL PRIMARY KEY,
                            SubscriptionID INT NOT NULL,
                            PaymentDate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
                            Amount DECIMAL(10, 2) NOT NULL,
                            PaymentMethod VARCHAR(50),
                            Description TEXT,
                            FOREIGN KEY (SubscriptionID) REFERENCES Subscriptions(SubscriptionID)
                        );
                        
                        -- Создание индексов для более быстрого поиска
                        CREATE INDEX idx_payments_subscription ON Payments(SubscriptionID);
                        CREATE INDEX idx_payments_date ON Payments(PaymentDate);
                    ";

                    using (NpgsqlCommand command = new NpgsqlCommand(createTableSQL, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Добавляем тестовые данные
                    if (AddSamplePaymentData())
                    {
                        MessageBox.Show("Таблица платежей успешно создана и заполнена тестовыми данными.",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Таблица платежей создана, но возникла ошибка при добавлении тестовых данных.",
                            "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании таблицы платежей: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Проверяет существование таблицы в базе данных
        /// </summary>
        private static bool CheckIfTableExists(string tableName)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"
                    SELECT EXISTS (
                        SELECT FROM information_schema.tables 
                        WHERE table_name = @tableName
                    );
                ";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@tableName", tableName);
                    return (bool)command.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Добавляет тестовые данные о платежах
        /// </summary>
        private static bool AddSamplePaymentData()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Получаем список существующих подписок
                    string getSubscriptionsSQL = @"
                        SELECT SubscriptionID, TypeID, StartDate, EndDate 
                        FROM Subscriptions 
                        LIMIT 50
                    ";

                    DataTable subscriptionsTable = new DataTable();
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(getSubscriptionsSQL, connection))
                    {
                        adapter.Fill(subscriptionsTable);
                    }

                    if (subscriptionsTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Не найдено абонементов для создания тестовых платежей.",
                            "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    // Получаем цены для типов абонементов
                    string getTypePricesSQL = @"
                        SELECT TypeID, Price FROM SubscriptionTypes
                    ";

                    DataTable typePricesTable = new DataTable();
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(getTypePricesSQL, connection))
                    {
                        adapter.Fill(typePricesTable);
                    }

                    // Словарь для соответствия TypeID -> Price
                    var typePrices = new System.Collections.Generic.Dictionary<int, decimal>();
                    foreach (DataRow row in typePricesTable.Rows)
                    {
                        typePrices[Convert.ToInt32(row["TypeID"])] = Convert.ToDecimal(row["Price"]);
                    }

                    // Создаем платежи для каждой подписки
                    string insertPaymentSQL = @"
                        INSERT INTO Payments (SubscriptionID, PaymentDate, Amount, PaymentMethod, Description)
                        VALUES (@SubscriptionID, @PaymentDate, @Amount, @PaymentMethod, @Description)
                    ";

                    using (NpgsqlCommand command = new NpgsqlCommand(insertPaymentSQL, connection))
                    {
                        foreach (DataRow subscriptionRow in subscriptionsTable.Rows)
                        {
                            int subscriptionId = Convert.ToInt32(subscriptionRow["SubscriptionID"]);
                            int typeId = Convert.ToInt32(subscriptionRow["TypeID"]);
                            DateTime startDate = Convert.ToDateTime(subscriptionRow["StartDate"]);

                            // Устанавливаем сумму платежа равной цене типа абонемента
                            decimal amount = 0;
                            if (typePrices.ContainsKey(typeId))
                            {
                                amount = typePrices[typeId];
                            }
                            else
                            {
                                // Если не нашли цену, задаем случайную сумму от 1000 до 10000
                                amount = new Random().Next(1000, 10000);
                            }

                            string[] paymentMethods = { "Наличные", "Карта", "Онлайн-оплата" };
                            string paymentMethod = paymentMethods[new Random().Next(paymentMethods.Length)];

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@SubscriptionID", subscriptionId);
                            command.Parameters.AddWithValue("@PaymentDate", startDate); // Платеж в день начала абонемента
                            command.Parameters.AddWithValue("@Amount", amount);
                            command.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                            command.Parameters.AddWithValue("@Description", $"Оплата абонемента #{subscriptionId}");

                            command.ExecuteNonQuery();

                            // Для некоторых абонементов добавим дополнительные платежи в другие даты
                            if (new Random().Next(100) < 30) // 30% шанс
                            {
                                DateTime additionalPaymentDate = startDate.AddDays(new Random().Next(1, 30));
                                decimal additionalAmount = new Random().Next(500, 3000);

                                command.Parameters.Clear();
                                command.Parameters.AddWithValue("@SubscriptionID", subscriptionId);
                                command.Parameters.AddWithValue("@PaymentDate", additionalPaymentDate);
                                command.Parameters.AddWithValue("@Amount", additionalAmount);
                                command.Parameters.AddWithValue("@PaymentMethod", paymentMethods[new Random().Next(paymentMethods.Length)]);
                                command.Parameters.AddWithValue("@Description", $"Дополнительная услуга для абонемента #{subscriptionId}");

                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении тестовых данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}