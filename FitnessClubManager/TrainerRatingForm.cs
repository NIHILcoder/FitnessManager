using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace FitnessManager
{
    public partial class TrainerRatingForm : Form
    {
        private int trainerId;
        private int clientId;
        private string trainerName;
        private string connectionString = DBConnection.ConnectionString;

        // Звездочки для рейтинга
        private PictureBox[] stars;
        private int currentRating = 0;

        // Изображения для звезд - создаем вручную вместо ресурсов
        private Image starEmpty;
        private Image starFilled;

        public TrainerRatingForm(int trainerId, string trainerName, int clientId)
        {
            InitializeComponent();

            this.trainerId = trainerId;
            this.trainerName = trainerName;
            this.clientId = clientId;

            lblTrainerName.Text = trainerName;

            // Создаем изображения программно вместо использования ресурсов
            CreateStarImages();

            // Инициализируем звезды
            InitializeStars();

            // Загружаем существующий рейтинг, если есть
            LoadCurrentRating();
        }

        private void CreateStarImages()
        {
            // Создаем пустую звезду (контур)
            starEmpty = CreateEmptyStarImage();

            // Создаем заполненную звезду
            starFilled = CreateFilledStarImage();
        }

        private Image CreateEmptyStarImage()
        {
            // Создаем изображение пустой звезды программно
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                using (Pen pen = new Pen(Color.Gray, 2))
                {
                    // Рисуем пятиконечную звезду
                    PointF[] points = CreateStarPoints(15, 5, 15);
                    g.DrawPolygon(pen, points);
                }
            }
            return bmp;
        }

        private Image CreateFilledStarImage()
        {
            // Создаем изображение заполненной звезды программно
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                using (Brush brush = new SolidBrush(Color.Gold))
                using (Pen pen = new Pen(Color.Orange, 2))
                {
                    // Рисуем пятиконечную звезду
                    PointF[] points = CreateStarPoints(15, 5, 15);
                    g.FillPolygon(brush, points);
                    g.DrawPolygon(pen, points);
                }
            }
            return bmp;
        }

        private PointF[] CreateStarPoints(int centerX, int innerRadius, int outerRadius)
        {
            // Создаем точки для пятиконечной звезды
            PointF[] points = new PointF[10];
            double angle = -Math.PI / 2; // Начинаем с верхней точки

            for (int i = 0; i < 10; i++)
            {
                int radius = i % 2 == 0 ? outerRadius : innerRadius;
                points[i] = new PointF(
                    (float)(centerX + radius * Math.Cos(angle)),
                    (float)(centerX + radius * Math.Sin(angle))
                );
                angle += Math.PI / 5;
            }

            return points;
        }

        private void InitializeStars()
        {
            // Создаем массив для звезд
            stars = new PictureBox[5];

            // Создаем элементы PictureBox для каждой звезды
            for (int i = 0; i < 5; i++)
            {
                stars[i] = new PictureBox();
                stars[i].Size = new Size(32, 32);
                stars[i].Location = new Point(50 + i * 40, 100);
                stars[i].SizeMode = PictureBoxSizeMode.Zoom;
                stars[i].Image = starEmpty;
                stars[i].Tag = i + 1; // Сохраняем значение рейтинга (1-5)
                stars[i].Cursor = Cursors.Hand;

                // Добавляем обработчики событий
                stars[i].Click += Star_Click;
                stars[i].MouseEnter += Star_MouseEnter;
                stars[i].MouseLeave += Star_MouseLeave;

                // Добавляем на форму
                panelRating.Controls.Add(stars[i]);
            }
        }

        private void LoadCurrentRating()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT rating_value, comment 
                                    FROM trainer_ratings 
                                    WHERE trainer_id = @TrainerID AND client_id = @ClientID";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrainerID", trainerId);
                        command.Parameters.AddWithValue("@ClientID", clientId);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int ratingValue = reader.GetInt32(0);
                                string comment = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);

                                // Устанавливаем текущий рейтинг
                                SetRating(ratingValue);

                                // Заполняем комментарий
                                txtComment.Text = comment;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке существующего рейтинга: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetRating(int rating)
        {
            currentRating = rating;

            // Обновляем отображение звезд
            for (int i = 0; i < 5; i++)
            {
                stars[i].Image = (i < rating) ? starFilled : starEmpty;
            }
        }

        private void Star_Click(object sender, EventArgs e)
        {
            PictureBox clickedStar = sender as PictureBox;
            int rating = (int)clickedStar.Tag;

            SetRating(rating);
        }

        private void Star_MouseEnter(object sender, EventArgs e)
        {
            PictureBox hoveredStar = sender as PictureBox;
            int rating = (int)hoveredStar.Tag;

            // При наведении заполняем все звезды до текущей
            for (int i = 0; i < 5; i++)
            {
                stars[i].Image = (i < rating) ? starFilled : starEmpty;
            }
        }

        private void Star_MouseLeave(object sender, EventArgs e)
        {
            // При уходе курсора восстанавливаем текущий рейтинг
            for (int i = 0; i < 5; i++)
            {
                stars[i].Image = (i < currentRating) ? starFilled : starEmpty;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentRating == 0)
            {
                MessageBox.Show("Пожалуйста, выберите оценку (от 1 до 5 звезд)", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Проверяем, существует ли уже рейтинг от этого клиента
                    string checkQuery = @"SELECT COUNT(*) 
                                        FROM trainer_ratings 
                                        WHERE trainer_id = @TrainerID AND client_id = @ClientID";

                    int existingCount = 0;

                    using (NpgsqlCommand checkCommand = new NpgsqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@TrainerID", trainerId);
                        checkCommand.Parameters.AddWithValue("@ClientID", clientId);

                        existingCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                    }

                    string query;
                    if (existingCount > 0)
                    {
                        // Обновляем существующий рейтинг
                        query = @"UPDATE trainer_ratings 
                                SET rating_value = @RatingValue, comment = @Comment, rating_date = CURRENT_TIMESTAMP
                                WHERE trainer_id = @TrainerID AND client_id = @ClientID";
                    }
                    else
                    {
                        // Добавляем новый рейтинг
                        query = @"INSERT INTO trainer_ratings 
                                (trainer_id, client_id, rating_value, comment, rating_date)
                                VALUES (@TrainerID, @ClientID, @RatingValue, @Comment, CURRENT_TIMESTAMP)";
                    }

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrainerID", trainerId);
                        command.Parameters.AddWithValue("@ClientID", clientId);
                        command.Parameters.AddWithValue("@RatingValue", currentRating);
                        command.Parameters.AddWithValue("@Comment", txtComment.Text.Trim());

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Ваша оценка успешно сохранена", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении оценки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}