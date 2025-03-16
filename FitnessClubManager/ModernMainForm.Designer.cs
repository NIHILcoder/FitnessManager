namespace FitnessManager
{
    partial class ModernMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModernMainForm));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnChat = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnTrainers = new System.Windows.Forms.Button();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnSubscriptions = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.panelSideMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelSideMenu.Controls.Add(this.btnChat);
            this.panelSideMenu.Controls.Add(this.btnAbout);
            this.panelSideMenu.Controls.Add(this.btnLogout);
            this.panelSideMenu.Controls.Add(this.btnReports);
            this.panelSideMenu.Controls.Add(this.btnTrainers);
            this.panelSideMenu.Controls.Add(this.btnSchedule);
            this.panelSideMenu.Controls.Add(this.btnSubscriptions);
            this.panelSideMenu.Controls.Add(this.btnClients);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(220, 753);
            this.panelSideMenu.TabIndex = 0;
            // 
            // btnChat
            // 
            this.btnChat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnChat.FlatAppearance.BorderSize = 0;
            this.btnChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChat.ForeColor = System.Drawing.Color.White;
            this.btnChat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChat.Location = new System.Drawing.Point(0, 633);
            this.btnChat.Name = "btnChat";
            this.btnChat.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnChat.Size = new System.Drawing.Size(220, 40);
            this.btnChat.TabIndex = 8;
            this.btnChat.Text = "  Чат-бот";
            this.btnChat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAbout.ForeColor = System.Drawing.Color.White;
            this.btnAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbout.Location = new System.Drawing.Point(0, 673);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAbout.Size = new System.Drawing.Size(220, 40);
            this.btnAbout.TabIndex = 7;
            this.btnAbout.Text = "  О программе";
            this.btnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 713);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(220, 40);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "  Выход";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnReports
            // 
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(0, 260);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(220, 50);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "  Отчеты";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnTrainers
            // 
            this.btnTrainers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTrainers.FlatAppearance.BorderSize = 0;
            this.btnTrainers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrainers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTrainers.ForeColor = System.Drawing.Color.White;
            this.btnTrainers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrainers.Location = new System.Drawing.Point(0, 210);
            this.btnTrainers.Name = "btnTrainers";
            this.btnTrainers.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTrainers.Size = new System.Drawing.Size(220, 50);
            this.btnTrainers.TabIndex = 4;
            this.btnTrainers.Text = "  Тренеры";
            this.btnTrainers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrainers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTrainers.UseVisualStyleBackColor = true;
            this.btnTrainers.Click += new System.EventHandler(this.btnTrainers_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSchedule.FlatAppearance.BorderSize = 0;
            this.btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedule.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSchedule.ForeColor = System.Drawing.Color.White;
            this.btnSchedule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSchedule.Location = new System.Drawing.Point(0, 160);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSchedule.Size = new System.Drawing.Size(220, 50);
            this.btnSchedule.TabIndex = 3;
            this.btnSchedule.Text = "  Расписание";
            this.btnSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSchedule.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnSubscriptions
            // 
            this.btnSubscriptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSubscriptions.FlatAppearance.BorderSize = 0;
            this.btnSubscriptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubscriptions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSubscriptions.ForeColor = System.Drawing.Color.White;
            this.btnSubscriptions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubscriptions.Location = new System.Drawing.Point(0, 110);
            this.btnSubscriptions.Name = "btnSubscriptions";
            this.btnSubscriptions.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSubscriptions.Size = new System.Drawing.Size(220, 50);
            this.btnSubscriptions.TabIndex = 2;
            this.btnSubscriptions.Text = "  Абонементы";
            this.btnSubscriptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubscriptions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSubscriptions.UseVisualStyleBackColor = true;
            this.btnSubscriptions.Click += new System.EventHandler(this.btnSubscriptions_Click);
            // 
            // btnClients
            // 
            this.btnClients.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClients.FlatAppearance.BorderSize = 0;
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClients.ForeColor = System.Drawing.Color.White;
            this.btnClients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClients.Location = new System.Drawing.Point(0, 60);
            this.btnClients.Name = "btnClients";
            this.btnClients.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnClients.Size = new System.Drawing.Size(220, 50);
            this.btnClients.TabIndex = 1;
            this.btnClients.Text = "  Клиенты";
            this.btnClients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClients.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Controls.Add(this.lblLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 60);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(54, 16);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(130, 28);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "ACTIVE LIFE";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelFooter.Controls.Add(this.lblUserInfo);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(220, 723);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1062, 30);
            this.panelFooter.TabIndex = 2;
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUserInfo.ForeColor = System.Drawing.Color.White;
            this.lblUserInfo.Location = new System.Drawing.Point(21, 5);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(114, 20);
            this.lblUserInfo.TabIndex = 0;
            this.lblUserInfo.Text = "Роль: Тренер";
            // 
            // ModernMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelSideMenu);
            this.IsMdiContainer = true;
            this.Name = "ModernMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Фитнес-клуб \"ActiveLife\" - Система управления";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelSideMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnTrainers;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button btnSubscriptions;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnChat;
    }
}