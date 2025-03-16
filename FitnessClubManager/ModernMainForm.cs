using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace FitnessManager
{
    public partial class ModernMainForm : Form
    {
        private int userId;
        private string userRole;
        private string connectionString = DBConnection.ConnectionString;

        // Статическое поле для хранения ID текущего пользователя
        public static int CurrentUserID { get; private set; }

        // Текущая активная кнопка навигации
        private Button currentButton;

        // Различные цвета для кнопок в зависимости от раздела
        private Color clientsColor = Color.FromArgb(0, 122, 204);   // Синий
        private Color subscriptionsColor = Color.FromArgb(46, 204, 113); // Зеленый
        private Color scheduleColor = Color.FromArgb(231, 76, 60);   // Красный
        private Color trainersColor = Color.FromArgb(155, 89, 182);  // Фиолетовый
        private Color reportsColor = Color.FromArgb(243, 156, 18);   // Оранжевый

        public ModernMainForm(int userId, string userRole)
        {
            InitializeComponent();
            this.userId = userId;
            this.userRole = userRole;
            CurrentUserID = userId;

            lblUserInfo.Text = $"Роль: {userRole}";
            ConfigureAccessRights();

            // Активируем первую доступную кнопку по умолчанию
            if (btnClients.Visible)
                ActivateButton(btnClients);
            else if (btnSubscriptions.Visible)
                ActivateButton(btnSubscriptions);
            else if (btnSchedule.Visible)
                ActivateButton(btnSchedule);
        }

        private void ConfigureAccessRights()
        {
            switch (userRole)
            {
                case "Администратор":
                    // Администратор имеет доступ ко всем разделам
                    break;
                case "Тренер":
                    btnReports.Visible = false;
                    break;
                case "Клиент":
                    btnClients.Visible = false;
                    btnTrainers.Visible = false;
                    btnReports.Visible = false;
                    break;
            }
        }

        // Метод для активации выбранной кнопки и открытия соответствующей формы
        private void ActivateButton(Button button)
        {
            // Сбрасываем стиль текущей кнопки, если она была выбрана
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(40, 40, 40);
                currentButton.ForeColor = Color.White;
                currentButton.Font = new Font("Segoe UI", 10.0f, FontStyle.Regular);
            }

            // Устанавливаем стиль для активной кнопки
            Color themeColor = Color.FromArgb(0, 122, 204); // По умолчанию синий

            // Выбираем цвет в зависимости от кнопки
            if (button == btnClients)
                themeColor = clientsColor;
            else if (button == btnSubscriptions)
                themeColor = subscriptionsColor;
            else if (button == btnSchedule)
                themeColor = scheduleColor;
            else if (button == btnTrainers)
                themeColor = trainersColor;
            else if (button == btnReports)
                themeColor = reportsColor;

            button.BackColor = themeColor;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 10.0f, FontStyle.Bold);

            // Запоминаем текущую кнопку
            currentButton = button;

            // Открываем соответствующую форму
            OpenForm(button);
        }

        private void OpenForm(Button button)
        {
            // Закрываем все дочерние формы в панели содержимого
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }

            // Открываем нужную форму
            Form form = null;

            if (button == btnClients)
                form = new ModernClientsForm(userRole);
            else if (button == btnSubscriptions)
                form = new SubscriptionsForm(userRole);
            else if (button == btnSchedule)
                form = new ScheduleForm(userRole);
            else if (button == btnTrainers)
                form = new TrainersForm(userRole);
            else if (button == btnReports)
                form = new ReportsForm(userRole);

            if (form != null)
            {
                form.MdiParent = this;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
        }

        // Обработчики кнопок навигации
        private void btnClients_Click(object sender, EventArgs e)
        {
            ActivateButton(sender as Button);
        }

        private void btnSubscriptions_Click(object sender, EventArgs e)
        {
            ActivateButton(sender as Button);
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            ActivateButton(sender as Button);
        }

        private void btnTrainers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender as Button);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ActivateButton(sender as Button);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти из системы?", "Выход",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                this.Hide();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            // Открытие простого чат-бота
            ChatBotForm chatForm = new ChatBotForm();
            chatForm.ShowDialog();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Фитнес-клуб \"ActiveLife\"\nВерсия 2.0\n\n" +
                "Система управления фитнес-клубом\n" +
                "Разработано: FitTech",
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // Простой класс чат-бота (заглушка)
    public class ChatBotForm : Form
    {
        private RichTextBox rtbChat;
        private TextBox txtMessage;
        private Button btnSend;

        public ChatBotForm()
        {
            this.Text = "ActiveLife Чат-бот";
            this.Size = new Size(500, 500);
            this.StartPosition = FormStartPosition.CenterParent;

            // Создаем элементы управления
            rtbChat = new RichTextBox
            {
                Dock = DockStyle.Top,
                Height = 400,
                ReadOnly = true
            };

            Panel panelBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50
            };

            txtMessage = new TextBox
            {
                Width = 350,
                Location = new Point(10, 15),
                Parent = panelBottom
            };

            btnSend = new Button
            {
                Text = "Отправить",
                Width = 100,
                Location = new Point(370, 14),
                Parent = panelBottom
            };

            btnSend.Click += BtnSend_Click;

            // Добавляем элементы на форму
            this.Controls.Add(rtbChat);
            this.Controls.Add(panelBottom);

            // Приветственное сообщение
            AddBotMessage("Здравствуйте! Я чат-бот фитнес-клуба ActiveLife. Чем могу помочь?");
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                AddUserMessage(txtMessage.Text);
                ProcessUserMessage(txtMessage.Text);
                txtMessage.Clear();
            }
        }

        private void AddUserMessage(string message)
        {
            rtbChat.SelectionColor = Color.Blue;
            rtbChat.AppendText($"Вы: {message}\n");
        }

        private void AddBotMessage(string message)
        {
            rtbChat.SelectionColor = Color.Green;
            rtbChat.AppendText($"Бот: {message}\n");
        }

        private void ProcessUserMessage(string message)
        {
            // Очень простая логика ответов
            message = message.ToLower();

            if (message.Contains("привет") || message.Contains("здравствуй"))
            {
                AddBotMessage("Здравствуйте! Чем могу помочь?");
            }
            else if (message.Contains("расписание") || message.Contains("занятия"))
            {
                AddBotMessage("Расписание занятий доступно в соответствующем разделе приложения. Также вы можете уточнить его у администратора.");
            }
            else if (message.Contains("абонемент") || message.Contains("стоимость"))
            {
                AddBotMessage("У нас есть различные типы абонементов. Базовый от 2000 руб., Стандарт от 3500 руб., Премиум от 5000 руб. Подробности у администратора.");
            }
            else if (message.Contains("тренер") || message.Contains("персональ"))
            {
                AddBotMessage("Персональные тренировки можно заказать у любого из наших тренеров. Стоимость от 1000 руб. за тренировку.");
            }
            else
            {
                AddBotMessage("Извините, я не совсем понял ваш вопрос. Попробуйте переформулировать или обратитесь к администратору клуба.");
            }
        }
    }

    // Заглушки для остальных форм, которые будут реализованы позже
    public class SubscriptionsForm : Form
    {
        public SubscriptionsForm(string userRole)
        {
            this.Text = "Абонементы";

            Panel headerPanel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(46, 204, 113)
            };

            Label titleLabel = new Label()
            {
                Text = "АБОНЕМЕНТЫ",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 14),
                Parent = headerPanel
            };

            this.Controls.Add(headerPanel);

            Label notImplementedLabel = new Label()
            {
                Text = "Эта форма находится в разработке",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(300, 300)
            };

            this.Controls.Add(notImplementedLabel);
        }
    }

    public class ScheduleForm : Form
    {
        public ScheduleForm(string userRole)
        {
            this.Text = "Расписание занятий";

            Panel headerPanel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(231, 76, 60)
            };

            Label titleLabel = new Label()
            {
                Text = "РАСПИСАНИЕ ЗАНЯТИЙ",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 14),
                Parent = headerPanel
            };

            this.Controls.Add(headerPanel);

            Label notImplementedLabel = new Label()
            {
                Text = "Эта форма находится в разработке",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(300, 300)
            };

            this.Controls.Add(notImplementedLabel);
        }
    }

    public class TrainersForm : Form
    {
        public TrainersForm(string userRole)
        {
            this.Text = "Тренеры";

            Panel headerPanel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(155, 89, 182)
            };

            Label titleLabel = new Label()
            {
                Text = "ТРЕНЕРЫ",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 14),
                Parent = headerPanel
            };

            this.Controls.Add(headerPanel);

            Label notImplementedLabel = new Label()
            {
                Text = "Эта форма находится в разработке",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(300, 300)
            };

            this.Controls.Add(notImplementedLabel);
        }
    }

    public class ReportsForm : Form
    {
        public ReportsForm(string userRole)
        {
            this.Text = "Отчеты";

            Panel headerPanel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(243, 156, 18)
            };

            Label titleLabel = new Label()
            {
                Text = "ОТЧЕТЫ",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 14),
                Parent = headerPanel
            };

            this.Controls.Add(headerPanel);

            Button btnVisitStatistics = new Button()
            {
                Text = "Статистика посещений",
                Width = 250,
                Height = 40,
                Location = new Point(50, 100)
            };

            btnVisitStatistics.Click += (sender, e) =>
            {
                VisitStatisticsForm form = new VisitStatisticsForm();
                form.ShowDialog();
            };

            this.Controls.Add(btnVisitStatistics);

            Button btnClientsExpired = new Button()
            {
                Text = "Клиенты с истекшими абонементами",
                Width = 250,
                Height = 40,
                Location = new Point(50, 160)
            };

            Button btnIncomeReport = new Button()
            {
                Text = "Отчет по доходам",
                Width = 250,
                Height = 40,
                Location = new Point(50, 220)
            };

            this.Controls.Add(btnClientsExpired);
            this.Controls.Add(btnIncomeReport);
        }
    }
}