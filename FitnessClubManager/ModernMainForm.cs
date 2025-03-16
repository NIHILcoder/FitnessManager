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
            // Открытие чат-бота
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
}