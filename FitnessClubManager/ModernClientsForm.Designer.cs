namespace FitnessManager
{
    partial class ModernClientsForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabClients = new System.Windows.Forms.TabControl();
            this.tabList = new System.Windows.Forms.TabPage();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.panelClientActions = new System.Windows.Forms.Panel();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnEditClient = new System.Windows.Forms.Button();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.lblActivityFilter = new System.Windows.Forms.Label();
            this.cmbActivityFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.dgvClientSubscriptions = new System.Windows.Forms.DataGridView();
            this.tabClientDetails = new System.Windows.Forms.TabControl();
            this.tabNotes = new System.Windows.Forms.TabPage();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.tabClients.SuspendLayout();
            this.tabList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.panelClientActions.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.tabDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientSubscriptions)).BeginInit();
            this.tabClientDetails.SuspendLayout();
            this.tabNotes.SuspendLayout();
            this.tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(132, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "КЛИЕНТЫ";
            // 
            // tabClients
            // 
            this.tabClients.Controls.Add(this.tabList);
            this.tabClients.Controls.Add(this.tabDetails);
            this.tabClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabClients.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabClients.Location = new System.Drawing.Point(0, 60);
            this.tabClients.Name = "tabClients";
            this.tabClients.SelectedIndex = 0;
            this.tabClients.Size = new System.Drawing.Size(1000, 580);
            this.tabClients.TabIndex = 1;
            // 
            // tabList
            // 
            this.tabList.Controls.Add(this.dgvClients);
            this.tabList.Controls.Add(this.panelClientActions);
            this.tabList.Controls.Add(this.panelSearch);
            this.tabList.Location = new System.Drawing.Point(4, 32);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(3);
            this.tabList.Size = new System.Drawing.Size(992, 544);
            this.tabList.TabIndex = 0;
            this.tabList.Text = "Список клиентов";
            this.tabList.UseVisualStyleBackColor = true;
            // 
            // dgvClients
            // 
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClients.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClients.Location = new System.Drawing.Point(3, 53);
            this.dgvClients.MultiSelect = false;
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.RowHeadersWidth = 51;
            this.dgvClients.RowTemplate.Height = 24;
            this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.Size = new System.Drawing.Size(766, 488);
            this.dgvClients.TabIndex = 2;
            // 
            // panelClientActions
            // 
            this.panelClientActions.Controls.Add(this.btnViewDetails);
            this.panelClientActions.Controls.Add(this.btnEditClient);
            this.panelClientActions.Controls.Add(this.btnAddClient);
            this.panelClientActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelClientActions.Location = new System.Drawing.Point(769, 53);
            this.panelClientActions.Name = "panelClientActions";
            this.panelClientActions.Size = new System.Drawing.Size(220, 488);
            this.panelClientActions.TabIndex = 1;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Location = new System.Drawing.Point(15, 128);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(190, 40);
            this.btnViewDetails.TabIndex = 2;
            this.btnViewDetails.Text = "Просмотр деталей";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnEditClient
            // 
            this.btnEditClient.Location = new System.Drawing.Point(15, 75);
            this.btnEditClient.Name = "btnEditClient";
            this.btnEditClient.Size = new System.Drawing.Size(190, 40);
            this.btnEditClient.TabIndex = 1;
            this.btnEditClient.Text = "Редактировать";
            this.btnEditClient.UseVisualStyleBackColor = true;
            this.btnEditClient.Click += new System.EventHandler(this.btnEditClient_Click);
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(15, 25);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(190, 40);
            this.btnAddClient.TabIndex = 0;
            this.btnAddClient.Text = "Добавить клиента";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelSearch.Controls.Add(this.lblActivityFilter);
            this.panelSearch.Controls.Add(this.cmbActivityFilter);
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Controls.Add(this.lblSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(3, 3);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(986, 50);
            this.panelSearch.TabIndex = 0;
            // 
            // lblActivityFilter
            // 
            this.lblActivityFilter.AutoSize = true;
            this.lblActivityFilter.Location = new System.Drawing.Point(600, 14);
            this.lblActivityFilter.Name = "lblActivityFilter";
            this.lblActivityFilter.Size = new System.Drawing.Size(103, 23);
            this.lblActivityFilter.TabIndex = 3;
            this.lblActivityFilter.Text = "Активность:";
            // 
            // cmbActivityFilter
            // 
            this.cmbActivityFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActivityFilter.FormattingEnabled = true;
            this.cmbActivityFilter.Location = new System.Drawing.Point(709, 10);
            this.cmbActivityFilter.Name = "cmbActivityFilter";
            this.cmbActivityFilter.Size = new System.Drawing.Size(180, 31);
            this.cmbActivityFilter.TabIndex = 2;
            this.cmbActivityFilter.SelectedIndexChanged += new System.EventHandler(this.cmbActivityFilter_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(140, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(350, 30);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(15, 14);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(119, 23);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Поиск клиента:";
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.splitContainer1);
            this.tabDetails.Controls.Add(this.btnBack);
            this.tabDetails.Location = new System.Drawing.Point(4, 32);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(992, 544);
            this.tabDetails.TabIndex = 1;
            this.tabDetails.Text = "Детали клиента";
            this.tabDetails.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Panel1.Controls.Add(this.groupDetails);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabClientDetails);
            this.splitContainer1.Size = new System.Drawing.Size(986, 495);
            this.splitContainer1.SplitterDistance = 230;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupDetails
            // 
            this.groupDetails.Controls.Add(this.dgvClientSubscriptions);
            this.groupDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupDetails.Location = new System.Drawing.Point(0, 0);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(986, 230);
            this.groupDetails.TabIndex = 0;
            this.groupDetails.TabStop = false;
            this.groupDetails.Text = "Абонементы клиента";
            // 
            // dgvClientSubscriptions
            // 
            this.dgvClientSubscriptions.AllowUserToAddRows = false;
            this.dgvClientSubscriptions.AllowUserToDeleteRows = false;
            this.dgvClientSubscriptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientSubscriptions.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvClientSubscriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientSubscriptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientSubscriptions.Location = new System.Drawing.Point(3, 26);
            this.dgvClientSubscriptions.MultiSelect = false;
            this.dgvClientSubscriptions.Name = "dgvClientSubscriptions";
            this.dgvClientSubscriptions.ReadOnly = true;
            this.dgvClientSubscriptions.RowHeadersWidth = 51;
            this.dgvClientSubscriptions.RowTemplate.Height = 24;
            this.dgvClientSubscriptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientSubscriptions.Size = new System.Drawing.Size(980, 201);
            this.dgvClientSubscriptions.TabIndex = 0;
            // 
            // tabClientDetails
            // 
            this.tabClientDetails.Controls.Add(this.tabNotes);
            this.tabClientDetails.Controls.Add(this.tabHistory);
            this.tabClientDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabClientDetails.Location = new System.Drawing.Point(0, 0);
            this.tabClientDetails.Name = "tabClientDetails";
            this.tabClientDetails.SelectedIndex = 0;
            this.tabClientDetails.Size = new System.Drawing.Size(986, 261);
            this.tabClientDetails.TabIndex = 0;
            // 
            // tabNotes
            // 
            this.tabNotes.Controls.Add(this.rtbNotes);
            this.tabNotes.Location = new System.Drawing.Point(4, 32);
            this.tabNotes.Name = "tabNotes";
            this.tabNotes.Padding = new System.Windows.Forms.Padding(3);
            this.tabNotes.Size = new System.Drawing.Size(978, 225);
            this.tabNotes.TabIndex = 0;
            this.tabNotes.Text = "Заметки";
            this.tabNotes.UseVisualStyleBackColor = true;
            // 
            // rtbNotes
            // 
            this.rtbNotes.BackColor = System.Drawing.Color.White;
            this.rtbNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbNotes.Location = new System.Drawing.Point(3, 3);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.ReadOnly = true;
            this.rtbNotes.Size = new System.Drawing.Size(972, 219);
            this.rtbNotes.TabIndex = 0;
            this.rtbNotes.Text = "";
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.dgvHistory);
            this.tabHistory.Location = new System.Drawing.Point(4, 32);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistory.Size = new System.Drawing.Size(978, 225);
            this.tabHistory.TabIndex = 1;
            this.tabHistory.Text = "История изменений";
            this.tabHistory.UseVisualStyleBackColor = true;
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.Location = new System.Drawing.Point(3, 3);
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.RowTemplate.Height = 24;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(972, 219);
            this.dgvHistory.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBack.Location = new System.Drawing.Point(3, 498);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(986, 43);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "← Вернуться к списку клиентов";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ModernClientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Controls.Add(this.tabClients);
            this.Controls.Add(this.panelHeader);
            this.Name = "ModernClientsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление клиентами";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tabClients.ResumeLayout(false);
            this.tabList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.panelClientActions.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.tabDetails.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientSubscriptions)).EndInit();
            this.tabClientDetails.ResumeLayout(false);
            this.tabNotes.ResumeLayout(false);
            this.tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabClients;
        private System.Windows.Forms.TabPage tabList;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel panelClientActions;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnEditClient;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.DataGridView dgvClientSubscriptions;
        private System.Windows.Forms.TabControl tabClientDetails;
        private System.Windows.Forms.TabPage tabNotes;
        private System.Windows.Forms.TabPage tabHistory;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Label lblActivityFilter;
        private System.Windows.Forms.ComboBox cmbActivityFilter;
    }
}