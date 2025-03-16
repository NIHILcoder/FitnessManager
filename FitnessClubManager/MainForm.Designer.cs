namespace FitnessManager
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сменитьПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblUserInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabClients = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnViewClientSubscriptions = new System.Windows.Forms.Button();
            this.btnEditClient = new System.Windows.Forms.Button();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.dgvClientSubscriptions = new System.Windows.Forms.DataGridView();
            this.tabSubscriptions = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvSubscriptions = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExtendSubscription = new System.Windows.Forms.Button();
            this.btnEditSubscription = new System.Windows.Forms.Button();
            this.btnAddSubscription = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSubscriptionTypes = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnEditSubscriptionType = new System.Windows.Forms.Button();
            this.btnAddSubscriptionType = new System.Windows.Forms.Button();
            this.tabSchedule = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvClasses = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnEditClass = new System.Windows.Forms.Button();
            this.btnAddClass = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpScheduleDate = new System.Windows.Forms.DateTimePicker();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnEditScheduleItem = new System.Windows.Forms.Button();
            this.btnAddScheduleItem = new System.Windows.Forms.Button();
            this.tabTrainers = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.dgvTrainers = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnViewTrainerSchedule = new System.Windows.Forms.Button();
            this.btnEditTrainer = new System.Windows.Forms.Button();
            this.btnAddTrainer = new System.Windows.Forms.Button();
            this.dgvTrainerSchedule = new System.Windows.Forms.DataGridView();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExpiredSubscriptionsReport = new System.Windows.Forms.Button();
            this.btnIncomeReport = new System.Windows.Forms.Button();
            this.btnVisitReport = new System.Windows.Forms.Button();

            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientSubscriptions)).BeginInit();
            this.tabSubscriptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubscriptions)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubscriptionTypes)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.panel5.SuspendLayout();
            this.tabTrainers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainers)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainerSchedule)).BeginInit();
            this.tabReports.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();

            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1282, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сменитьПользователяToolStripMenuItem,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сменитьПользователяToolStripMenuItem
            // 
            this.сменитьПользователяToolStripMenuItem.Name = "сменитьПользователяToolStripMenuItem";
            this.сменитьПользователяToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.сменитьПользователяToolStripMenuItem.Text = "Сменить пользователя";
            this.сменитьПользователяToolStripMenuItem.Click += new System.EventHandler(this.сменитьПользователяToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(242, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUserInfo});
            this.statusStrip.Location = new System.Drawing.Point(0, 727);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1282, 26);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(56, 20);
            this.lblUserInfo.Text = "Статус:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabClients);
            this.tabControl.Controls.Add(this.tabSubscriptions);
            this.tabControl.Controls.Add(this.tabSchedule);
            this.tabControl.Controls.Add(this.tabTrainers);
            this.tabControl.Controls.Add(this.tabReports);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl.Location = new System.Drawing.Point(0, 28);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1282, 699);
            this.tabControl.TabIndex = 2;
            // 
            // tabClients
            // 
            this.tabClients.Controls.Add(this.splitContainer1);
            this.tabClients.Location = new System.Drawing.Point(4, 32);
            this.tabClients.Name = "tabClients";
            this.tabClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabClients.Size = new System.Drawing.Size(1274, 663);
            this.tabClients.TabIndex = 0;
            this.tabClients.Text = "Клиенты";
            this.tabClients.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvClients);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvClientSubscriptions);
            this.splitContainer1.Size = new System.Drawing.Size(1268, 657);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvClients
            // 
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClients.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClients.Location = new System.Drawing.Point(0, 0);
            this.dgvClients.MultiSelect = false;
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.RowHeadersWidth = 51;
            this.dgvClients.RowTemplate.Height = 24;
            this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.Size = new System.Drawing.Size(1000, 350);
            this.dgvClients.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnViewClientSubscriptions);
            this.panel1.Controls.Add(this.btnEditClient);
            this.panel1.Controls.Add(this.btnAddClient);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1000, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 350);
            this.panel1.TabIndex = 0;
            // 
            // btnViewClientSubscriptions
            // 
            this.btnViewClientSubscriptions.Location = new System.Drawing.Point(15, 128);
            this.btnViewClientSubscriptions.Name = "btnViewClientSubscriptions";
            this.btnViewClientSubscriptions.Size = new System.Drawing.Size(241, 40);
            this.btnViewClientSubscriptions.TabIndex = 2;
            this.btnViewClientSubscriptions.Text = "Просмотр абонементов";
            this.btnViewClientSubscriptions.UseVisualStyleBackColor = true;
            this.btnViewClientSubscriptions.Click += new System.EventHandler(this.btnViewClientSubscriptions_Click);
            // 
            // btnEditClient
            // 
            this.btnEditClient.Location = new System.Drawing.Point(15, 75);
            this.btnEditClient.Name = "btnEditClient";
            this.btnEditClient.Size = new System.Drawing.Size(241, 40);
            this.btnEditClient.TabIndex = 1;
            this.btnEditClient.Text = "Редактировать клиента";
            this.btnEditClient.UseVisualStyleBackColor = true;
            this.btnEditClient.Click += new System.EventHandler(this.btnEditClient_Click);
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(15, 25);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(241, 40);
            this.btnAddClient.TabIndex = 0;
            this.btnAddClient.Text = "Добавить клиента";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // dgvClientSubscriptions
            // 
            this.dgvClientSubscriptions.AllowUserToAddRows = false;
            this.dgvClientSubscriptions.AllowUserToDeleteRows = false;
            this.dgvClientSubscriptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientSubscriptions.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvClientSubscriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientSubscriptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientSubscriptions.Location = new System.Drawing.Point(0, 0);
            this.dgvClientSubscriptions.MultiSelect = false;
            this.dgvClientSubscriptions.Name = "dgvClientSubscriptions";
            this.dgvClientSubscriptions.ReadOnly = true;
            this.dgvClientSubscriptions.RowHeadersWidth = 51;
            this.dgvClientSubscriptions.RowTemplate.Height = 24;
            this.dgvClientSubscriptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientSubscriptions.Size = new System.Drawing.Size(1268, 303);
            this.dgvClientSubscriptions.TabIndex = 0;
            // 
            // tabSubscriptions
            // 
            this.tabSubscriptions.Controls.Add(this.splitContainer2);
            this.tabSubscriptions.Location = new System.Drawing.Point(4, 32);
            this.tabSubscriptions.Name = "tabSubscriptions";
            this.tabSubscriptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabSubscriptions.Size = new System.Drawing.Size(1274, 663);
            this.tabSubscriptions.TabIndex = 1;
            this.tabSubscriptions.Text = "Абонементы";
            this.tabSubscriptions.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvSubscriptions);
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(1268, 657);
            this.splitContainer2.SplitterDistance = 350;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvSubscriptions
            // 
            this.dgvSubscriptions.AllowUserToAddRows = false;
            this.dgvSubscriptions.AllowUserToDeleteRows = false;
            this.dgvSubscriptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubscriptions.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSubscriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubscriptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubscriptions.Location = new System.Drawing.Point(0, 0);
            this.dgvSubscriptions.MultiSelect = false;
            this.dgvSubscriptions.Name = "dgvSubscriptions";
            this.dgvSubscriptions.ReadOnly = true;
            this.dgvSubscriptions.RowHeadersWidth = 51;
            this.dgvSubscriptions.RowTemplate.Height = 24;
            this.dgvSubscriptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubscriptions.Size = new System.Drawing.Size(1000, 350);
            this.dgvSubscriptions.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExtendSubscription);
            this.panel2.Controls.Add(this.btnEditSubscription);
            this.panel2.Controls.Add(this.btnAddSubscription);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1000, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 350);
            this.panel2.TabIndex = 1;
            // 
            // btnExtendSubscription
            // 
            this.btnExtendSubscription.Location = new System.Drawing.Point(15, 128);
            this.btnExtendSubscription.Name = "btnExtendSubscription";
            this.btnExtendSubscription.Size = new System.Drawing.Size(241, 40);
            this.btnExtendSubscription.TabIndex = 2;
            this.btnExtendSubscription.Text = "Продлить абонемент";
            this.btnExtendSubscription.UseVisualStyleBackColor = true;
            this.btnExtendSubscription.Click += new System.EventHandler(this.btnExtendSubscription_Click);
            // 
            // btnEditSubscription
            // 
            this.btnEditSubscription.Location = new System.Drawing.Point(15, 75);
            this.btnEditSubscription.Name = "btnEditSubscription";
            this.btnEditSubscription.Size = new System.Drawing.Size(241, 40);
            this.btnEditSubscription.TabIndex = 1;
            this.btnEditSubscription.Text = "Редактировать";
            this.btnEditSubscription.UseVisualStyleBackColor = true;
            this.btnEditSubscription.Click += new System.EventHandler(this.btnEditSubscription_Click);
            // 
            // btnAddSubscription
            // 
            this.btnAddSubscription.Location = new System.Drawing.Point(15, 25);
            this.btnAddSubscription.Name = "btnAddSubscription";
            this.btnAddSubscription.Size = new System.Drawing.Size(241, 40);
            this.btnAddSubscription.TabIndex = 0;
            this.btnAddSubscription.Text = "Добавить абонемент";
            this.btnAddSubscription.UseVisualStyleBackColor = true;
            this.btnAddSubscription.Click += new System.EventHandler(this.btnAddSubscription_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvSubscriptionTypes);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1268, 303);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Типы абонементов";
            // 
            // dgvSubscriptionTypes
            // 
            this.dgvSubscriptionTypes.AllowUserToAddRows = false;
            this.dgvSubscriptionTypes.AllowUserToDeleteRows = false;
            this.dgvSubscriptionTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubscriptionTypes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSubscriptionTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubscriptionTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubscriptionTypes.Location = new System.Drawing.Point(3, 26);
            this.dgvSubscriptionTypes.MultiSelect = false;
            this.dgvSubscriptionTypes.Name = "dgvSubscriptionTypes";
            this.dgvSubscriptionTypes.ReadOnly = true;
            this.dgvSubscriptionTypes.RowHeadersWidth = 51;
            this.dgvSubscriptionTypes.RowTemplate.Height = 24;
            this.dgvSubscriptionTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubscriptionTypes.Size = new System.Drawing.Size(994, 274);
            this.dgvSubscriptionTypes.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnEditSubscriptionType);
            this.panel3.Controls.Add(this.btnAddSubscriptionType);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(997, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(268, 274);
            this.panel3.TabIndex = 1;
            // 
            // btnEditSubscriptionType
            // 
            this.btnEditSubscriptionType.Location = new System.Drawing.Point(15, 75);
            this.btnEditSubscriptionType.Name = "btnEditSubscriptionType";
            this.btnEditSubscriptionType.Size = new System.Drawing.Size(241, 40);
            this.btnEditSubscriptionType.TabIndex = 1;
            this.btnEditSubscriptionType.Text = "Редактировать";
            this.btnEditSubscriptionType.UseVisualStyleBackColor = true;
            this.btnEditSubscriptionType.Click += new System.EventHandler(this.btnEditSubscriptionType_Click);
            // 
            // btnAddSubscriptionType
            // 
            this.btnAddSubscriptionType.Location = new System.Drawing.Point(15, 25);
            this.btnAddSubscriptionType.Name = "btnAddSubscriptionType";
            this.btnAddSubscriptionType.Size = new System.Drawing.Size(241, 40);
            this.btnAddSubscriptionType.TabIndex = 0;
            this.btnAddSubscriptionType.Text = "Добавить тип";
            this.btnAddSubscriptionType.UseVisualStyleBackColor = true;
            this.btnAddSubscriptionType.Click += new System.EventHandler(this.btnAddSubscriptionType_Click);
            // 
            // tabSchedule
            // 
            this.tabSchedule.Controls.Add(this.splitContainer3);
            this.tabSchedule.Location = new System.Drawing.Point(4, 32);
            this.tabSchedule.Name = "tabSchedule";
            this.tabSchedule.Size = new System.Drawing.Size(1274, 663);
            this.tabSchedule.TabIndex = 2;
            this.tabSchedule.Text = "Расписание занятий";
            this.tabSchedule.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dgvClasses);
            this.splitContainer3.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer3.Size = new System.Drawing.Size(1274, 663);
            this.splitContainer3.SplitterDistance = 293;
            this.splitContainer3.TabIndex = 0;
            // 
            // dgvClasses
            // 
            this.dgvClasses.AllowUserToAddRows = false;
            this.dgvClasses.AllowUserToDeleteRows = false;
            this.dgvClasses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClasses.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClasses.Location = new System.Drawing.Point(0, 0);
            this.dgvClasses.MultiSelect = false;
            this.dgvClasses.Name = "dgvClasses";
            this.dgvClasses.ReadOnly = true;
            this.dgvClasses.RowHeadersWidth = 51;
            this.dgvClasses.RowTemplate.Height = 24;
            this.dgvClasses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClasses.Size = new System.Drawing.Size(1006, 293);
            this.dgvClasses.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnEditClass);
            this.panel4.Controls.Add(this.btnAddClass);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1006, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(268, 293);
            this.panel4.TabIndex = 2;
            // 
            // btnEditClass
            // 
            this.btnEditClass.Location = new System.Drawing.Point(15, 75);
            this.btnEditClass.Name = "btnEditClass";
            this.btnEditClass.Size = new System.Drawing.Size(241, 40);
            this.btnEditClass.TabIndex = 1;
            this.btnEditClass.Text = "Редактировать занятие";
            this.btnEditClass.UseVisualStyleBackColor = true;
            this.btnEditClass.Click += new System.EventHandler(this.btnEditClass_Click);
            // 
            // btnAddClass
            // 
            this.btnAddClass.Location = new System.Drawing.Point(15, 25);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(241, 40);
            this.btnAddClass.TabIndex = 0;
            this.btnAddClass.Text = "Добавить занятие";
            this.btnAddClass.UseVisualStyleBackColor = true;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpScheduleDate);
            this.groupBox2.Controls.Add(this.dgvSchedule);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1274, 366);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Расписание";
            // 
            // dtpScheduleDate
            // 
            this.dtpScheduleDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpScheduleDate.Location = new System.Drawing.Point(8, 31);
            this.dtpScheduleDate.Name = "dtpScheduleDate";
            this.dtpScheduleDate.Size = new System.Drawing.Size(200, 30);
            this.dtpScheduleDate.TabIndex = 5;
            this.dtpScheduleDate.ValueChanged += new System.EventHandler(this.dtpScheduleDate_ValueChanged);
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.AllowUserToDeleteRows = false;
            this.dgvSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSchedule.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Location = new System.Drawing.Point(3, 71);
            this.dgvSchedule.MultiSelect = false;
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.ReadOnly = true;
            this.dgvSchedule.RowHeadersWidth = 51;
            this.dgvSchedule.RowTemplate.Height = 24;
            this.dgvSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchedule.Size = new System.Drawing.Size(1000, 292);
            this.dgvSchedule.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnEditScheduleItem);
            this.panel5.Controls.Add(this.btnAddScheduleItem);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(1003, 26);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(268, 337);
            this.panel5.TabIndex = 3;
            // 
            // btnEditScheduleItem
            // 
            this.btnEditScheduleItem.Location = new System.Drawing.Point(15, 75);
            this.btnEditScheduleItem.Name = "btnEditScheduleItem";
            this.btnEditScheduleItem.Size = new System.Drawing.Size(241, 40);
            this.btnEditScheduleItem.TabIndex = 1;
            this.btnEditScheduleItem.Text = "Редактировать";
            this.btnEditScheduleItem.UseVisualStyleBackColor = true;
            this.btnEditScheduleItem.Click += new System.EventHandler(this.btnEditScheduleItem_Click);
            // 
            // btnAddScheduleItem
            // 
            this.btnAddScheduleItem.Location = new System.Drawing.Point(15, 25);
            this.btnAddScheduleItem.Name = "btnAddScheduleItem";
            this.btnAddScheduleItem.Size = new System.Drawing.Size(241, 40);
            this.btnAddScheduleItem.TabIndex = 0;
            this.btnAddScheduleItem.Text = "Добавить в расписание";
            this.btnAddScheduleItem.UseVisualStyleBackColor = true;
            this.btnAddScheduleItem.Click += new System.EventHandler(this.btnAddScheduleItem_Click);
            // 
            // tabTrainers
            // 
            this.tabTrainers.Controls.Add(this.splitContainer4);
            this.tabTrainers.Location = new System.Drawing.Point(4, 32);
            this.tabTrainers.Name = "tabTrainers";
            this.tabTrainers.Size = new System.Drawing.Size(1274, 663);
            this.tabTrainers.TabIndex = 3;
            this.tabTrainers.Text = "Тренеры";
            this.tabTrainers.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.dgvTrainers);
            this.splitContainer4.Panel1.Controls.Add(this.panel6);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dgvTrainerSchedule);
            this.splitContainer4.Size = new System.Drawing.Size(1274, 663);
            this.splitContainer4.SplitterDistance = 350;
            this.splitContainer4.TabIndex = 1;
            // 
            // dgvTrainers
            // 
            this.dgvTrainers.AllowUserToAddRows = false;
            this.dgvTrainers.AllowUserToDeleteRows = false;
            this.dgvTrainers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTrainers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTrainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrainers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrainers.Location = new System.Drawing.Point(0, 0);
            this.dgvTrainers.MultiSelect = false;
            this.dgvTrainers.Name = "dgvTrainers";
            this.dgvTrainers.ReadOnly = true;
            this.dgvTrainers.RowHeadersWidth = 51;
            this.dgvTrainers.RowTemplate.Height = 24;
            this.dgvTrainers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrainers.Size = new System.Drawing.Size(1006, 350);
            this.dgvTrainers.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnViewTrainerSchedule);
            this.panel6.Controls.Add(this.btnEditTrainer);
            this.panel6.Controls.Add(this.btnAddTrainer);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1006, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(268, 350);
            this.panel6.TabIndex = 2;
            // 
            // btnViewTrainerSchedule
            // 
            this.btnViewTrainerSchedule.Location = new System.Drawing.Point(15, 128);
            this.btnViewTrainerSchedule.Name = "btnViewTrainerSchedule";
            this.btnViewTrainerSchedule.Size = new System.Drawing.Size(241, 40);
            this.btnViewTrainerSchedule.TabIndex = 2;
            this.btnViewTrainerSchedule.Text = "Просмотр расписания";
            this.btnViewTrainerSchedule.UseVisualStyleBackColor = true;
            this.btnViewTrainerSchedule.Click += new System.EventHandler(this.btnViewTrainerSchedule_Click);
            // 
            // btnEditTrainer
            // 
            this.btnEditTrainer.Location = new System.Drawing.Point(15, 75);
            this.btnEditTrainer.Name = "btnEditTrainer";
            this.btnEditTrainer.Size = new System.Drawing.Size(241, 40);
            this.btnEditTrainer.TabIndex = 1;
            this.btnEditTrainer.Text = "Редактировать тренера";
            this.btnEditTrainer.UseVisualStyleBackColor = true;
            this.btnEditTrainer.Click += new System.EventHandler(this.btnEditTrainer_Click);
            // 
            // btnAddTrainer
            // 
            this.btnAddTrainer.Location = new System.Drawing.Point(15, 25);
            this.btnAddTrainer.Name = "btnAddTrainer";
            this.btnAddTrainer.Size = new System.Drawing.Size(241, 40);
            this.btnAddTrainer.TabIndex = 0;
            this.btnAddTrainer.Text = "Добавить тренера";
            this.btnAddTrainer.UseVisualStyleBackColor = true;
            this.btnAddTrainer.Click += new System.EventHandler(this.btnAddTrainer_Click);
            // 
            // dgvTrainerSchedule
            // 
            this.dgvTrainerSchedule.AllowUserToAddRows = false;
            this.dgvTrainerSchedule.AllowUserToDeleteRows = false;
            this.dgvTrainerSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTrainerSchedule.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTrainerSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrainerSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrainerSchedule.Location = new System.Drawing.Point(0, 0);
            this.dgvTrainerSchedule.MultiSelect = false;
            this.dgvTrainerSchedule.Name = "dgvTrainerSchedule";
            this.dgvTrainerSchedule.ReadOnly = true;
            this.dgvTrainerSchedule.RowHeadersWidth = 51;
            this.dgvTrainerSchedule.RowTemplate.Height = 24;
            this.dgvTrainerSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrainerSchedule.Size = new System.Drawing.Size(1274, 309);
            this.dgvTrainerSchedule.TabIndex = 1;
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.groupBox3);
            this.tabReports.Location = new System.Drawing.Point(4, 32);
            this.tabReports.Name = "tabReports";
            this.tabReports.Size = new System.Drawing.Size(1274, 663);
            this.tabReports.TabIndex = 4;
            this.tabReports.Text = "Отчеты";
            this.tabReports.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExpiredSubscriptionsReport);
            this.groupBox3.Controls.Add(this.btnIncomeReport);
            this.groupBox3.Controls.Add(this.btnVisitReport);
            this.groupBox3.Location = new System.Drawing.Point(8, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(500, 259);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Отчеты";
            // 
            // btnExpiredSubscriptionsReport
            //
            this.btnExpiredSubscriptionsReport.Location = new System.Drawing.Point(21, 155);
            this.btnExpiredSubscriptionsReport.Name = "btnExpiredSubscriptionsReport";
            this.btnExpiredSubscriptionsReport.Size = new System.Drawing.Size(456, 40);
            this.btnExpiredSubscriptionsReport.TabIndex = 2;
            this.btnExpiredSubscriptionsReport.Text = "Клиенты с истекшими абонементами";
            this.btnExpiredSubscriptionsReport.UseVisualStyleBackColor = true;
            this.btnExpiredSubscriptionsReport.Click += new System.EventHandler(this.btnExpiredSubscriptionsReport_Click);
            // 
            // btnIncomeReport
            // 
            this.btnIncomeReport.Location = new System.Drawing.Point(21, 100);
            this.btnIncomeReport.Name = "btnIncomeReport";
            this.btnIncomeReport.Size = new System.Drawing.Size(456, 40);
            this.btnIncomeReport.TabIndex = 1;
            this.btnIncomeReport.Text = "Отчет по доходам";
            this.btnIncomeReport.UseVisualStyleBackColor = true;
            this.btnIncomeReport.Click += new System.EventHandler(this.btnIncomeReport_Click);
            // 
            // btnVisitReport
            // 
            this.btnVisitReport.Location = new System.Drawing.Point(21, 45);
            this.btnVisitReport.Name = "btnVisitReport";
            this.btnVisitReport.Size = new System.Drawing.Size(456, 40);
            this.btnVisitReport.TabIndex = 0;
            this.btnVisitReport.Text = "Статистика посещаемости";
            this.btnVisitReport.UseVisualStyleBackColor = true;
            this.btnVisitReport.Click += new System.EventHandler(this.btnVisitReport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Фитнес-клуб \"ActiveLife\" - Система управления";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabClients.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientSubscriptions)).EndInit();
            this.tabSubscriptions.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubscriptions)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubscriptionTypes)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabSchedule.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.panel5.ResumeLayout(false);
            this.tabTrainers.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainers)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainerSchedule)).EndInit();
            this.tabReports.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblUserInfo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabClients;
        private System.Windows.Forms.TabPage tabSubscriptions;
        private System.Windows.Forms.TabPage tabSchedule;
        private System.Windows.Forms.TabPage tabTrainers;
        private System.Windows.Forms.TabPage tabReports;
        private System.Windows.Forms.ToolStripMenuItem сменитьПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnViewClientSubscriptions;
        private System.Windows.Forms.Button btnEditClient;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.DataGridView dgvClientSubscriptions;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvSubscriptions;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExtendSubscription;
        private System.Windows.Forms.Button btnEditSubscription;
        private System.Windows.Forms.Button btnAddSubscription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSubscriptionTypes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnEditSubscriptionType;
        private System.Windows.Forms.Button btnAddSubscriptionType;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dgvClasses;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnEditClass;
        private System.Windows.Forms.Button btnAddClass;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpScheduleDate;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnEditScheduleItem;
        private System.Windows.Forms.Button btnAddScheduleItem;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView dgvTrainers;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnViewTrainerSchedule;
        private System.Windows.Forms.Button btnEditTrainer;
        private System.Windows.Forms.Button btnAddTrainer;
        private System.Windows.Forms.DataGridView dgvTrainerSchedule;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnExpiredSubscriptionsReport;
        private System.Windows.Forms.Button btnIncomeReport;
        private System.Windows.Forms.Button btnVisitReport;
    }
}