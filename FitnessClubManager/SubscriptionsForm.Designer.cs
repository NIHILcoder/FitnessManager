namespace FitnessManager
{
    partial class SubscriptionsForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSubscriptions = new System.Windows.Forms.TabPage();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnRunAutoRenewal = new System.Windows.Forms.Button();
            this.btnToggleAutoRenew = new System.Windows.Forms.Button();
            this.btnExtendSubscription = new System.Windows.Forms.Button();
            this.btnEditSubscription = new System.Windows.Forms.Button();
            this.btnAddSubscription = new System.Windows.Forms.Button();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvSubscriptions = new System.Windows.Forms.DataGridView();
            this.tabTypes = new System.Windows.Forms.TabPage();
            this.panelTypesActions = new System.Windows.Forms.Panel();
            this.btnEditSubscriptionType = new System.Windows.Forms.Button();
            this.btnAddSubscriptionType = new System.Windows.Forms.Button();
            this.dgvSubscriptionTypes = new System.Windows.Forms.DataGridView();
            this.panelHeader.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabSubscriptions.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubscriptions)).BeginInit();
            this.tabTypes.SuspendLayout();
            this.panelTypesActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubscriptionTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
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
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(183, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "АБОНЕМЕНТЫ";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSubscriptions);
            this.tabControl.Controls.Add(this.tabTypes);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl.Location = new System.Drawing.Point(0, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 580);
            this.tabControl.TabIndex = 1;
            // 
            // tabSubscriptions
            // 
            this.tabSubscriptions.Controls.Add(this.panelActions);
            this.tabSubscriptions.Controls.Add(this.panelSearch);
            this.tabSubscriptions.Controls.Add(this.dgvSubscriptions);
            this.tabSubscriptions.Location = new System.Drawing.Point(4, 32);
            this.tabSubscriptions.Name = "tabSubscriptions";
            this.tabSubscriptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabSubscriptions.Size = new System.Drawing.Size(992, 544);
            this.tabSubscriptions.TabIndex = 0;
            this.tabSubscriptions.Text = "Абонементы клиентов";
            this.tabSubscriptions.UseVisualStyleBackColor = true;
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.btnRunAutoRenewal);
            this.panelActions.Controls.Add(this.btnToggleAutoRenew);
            this.panelActions.Controls.Add(this.btnExtendSubscription);
            this.panelActions.Controls.Add(this.btnEditSubscription);
            this.panelActions.Controls.Add(this.btnAddSubscription);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelActions.Location = new System.Drawing.Point(789, 53);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(200, 488);
            this.panelActions.TabIndex = 2;
            // 
            // btnRunAutoRenewal
            // 
            this.btnRunAutoRenewal.Location = new System.Drawing.Point(15, 285);
            this.btnRunAutoRenewal.Name = "btnRunAutoRenewal";
            this.btnRunAutoRenewal.Size = new System.Drawing.Size(170, 40);
            this.btnRunAutoRenewal.TabIndex = 4;
            this.btnRunAutoRenewal.Text = "Запуск автопродления";
            this.btnRunAutoRenewal.UseVisualStyleBackColor = true;
            this.btnRunAutoRenewal.Click += new System.EventHandler(this.btnRunAutoRenewal_Click);
            // 
            // btnToggleAutoRenew
            // 
            this.btnToggleAutoRenew.Location = new System.Drawing.Point(15, 215);
            this.btnToggleAutoRenew.Name = "btnToggleAutoRenew";
            this.btnToggleAutoRenew.Size = new System.Drawing.Size(170, 40);
            this.btnToggleAutoRenew.TabIndex = 3;
            this.btnToggleAutoRenew.Text = "Вкл/выкл автопродление";
            this.btnToggleAutoRenew.UseVisualStyleBackColor = true;
            this.btnToggleAutoRenew.Click += new System.EventHandler(this.btnToggleAutoRenew_Click);
            // 
            // btnExtendSubscription
            // 
            this.btnExtendSubscription.Location = new System.Drawing.Point(15, 145);
            this.btnExtendSubscription.Name = "btnExtendSubscription";
            this.btnExtendSubscription.Size = new System.Drawing.Size(170, 40);
            this.btnExtendSubscription.TabIndex = 2;
            this.btnExtendSubscription.Text = "Продлить абонемент";
            this.btnExtendSubscription.UseVisualStyleBackColor = true;
            this.btnExtendSubscription.Click += new System.EventHandler(this.btnExtendSubscription_Click);
            // 
            // btnEditSubscription
            // 
            this.btnEditSubscription.Location = new System.Drawing.Point(15, 75);
            this.btnEditSubscription.Name = "btnEditSubscription";
            this.btnEditSubscription.Size = new System.Drawing.Size(170, 40);
            this.btnEditSubscription.TabIndex = 1;
            this.btnEditSubscription.Text = "Редактировать";
            this.btnEditSubscription.UseVisualStyleBackColor = true;
            this.btnEditSubscription.Click += new System.EventHandler(this.btnEditSubscription_Click);
            // 
            // btnAddSubscription
            // 
            this.btnAddSubscription.Location = new System.Drawing.Point(15, 15);
            this.btnAddSubscription.Name = "btnAddSubscription";
            this.btnAddSubscription.Size = new System.Drawing.Size(170, 40);
            this.btnAddSubscription.TabIndex = 0;
            this.btnAddSubscription.Text = "Добавить абонемент";
            this.btnAddSubscription.UseVisualStyleBackColor = true;
            this.btnAddSubscription.Click += new System.EventHandler(this.btnAddSubscription_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelSearch.Controls.Add(this.btnExport);
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Controls.Add(this.lblSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(3, 3);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(986, 50);
            this.panelSearch.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(550, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 35);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Экспорт";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(169, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(350, 30);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(15, 13);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(148, 23);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Поиск абонемента:";
            // 
            // dgvSubscriptions
            // 
            this.dgvSubscriptions.AllowUserToAddRows = false;
            this.dgvSubscriptions.AllowUserToDeleteRows = false;
            this.dgvSubscriptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubscriptions.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSubscriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubscriptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubscriptions.Location = new System.Drawing.Point(3, 53);
            this.dgvSubscriptions.MultiSelect = false;
            this.dgvSubscriptions.Name = "dgvSubscriptions";
            this.dgvSubscriptions.ReadOnly = true;
            this.dgvSubscriptions.RowHeadersWidth = 51;
            this.dgvSubscriptions.RowTemplate.Height = 24;
            this.dgvSubscriptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubscriptions.Size = new System.Drawing.Size(986, 488);
            this.dgvSubscriptions.TabIndex = 0;
            // 
            // tabTypes
            // 
            this.tabTypes.Controls.Add(this.panelTypesActions);
            this.tabTypes.Controls.Add(this.dgvSubscriptionTypes);
            this.tabTypes.Location = new System.Drawing.Point(4, 32);
            this.tabTypes.Name = "tabTypes";
            this.tabTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabTypes.Size = new System.Drawing.Size(992, 544);
            this.tabTypes.TabIndex = 1;
            this.tabTypes.Text = "Типы абонементов";
            this.tabTypes.UseVisualStyleBackColor = true;
            // 
            // panelTypesActions
            // 
            this.panelTypesActions.Controls.Add(this.btnEditSubscriptionType);
            this.panelTypesActions.Controls.Add(this.btnAddSubscriptionType);
            this.panelTypesActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTypesActions.Location = new System.Drawing.Point(789, 3);
            this.panelTypesActions.Name = "panelTypesActions";
            this.panelTypesActions.Size = new System.Drawing.Size(200, 538);
            this.panelTypesActions.TabIndex = 1;
            // 
            // btnEditSubscriptionType
            // 
            this.btnEditSubscriptionType.Location = new System.Drawing.Point(15, 75);
            this.btnEditSubscriptionType.Name = "btnEditSubscriptionType";
            this.btnEditSubscriptionType.Size = new System.Drawing.Size(170, 40);
            this.btnEditSubscriptionType.TabIndex = 1;
            this.btnEditSubscriptionType.Text = "Редактировать";
            this.btnEditSubscriptionType.UseVisualStyleBackColor = true;
            this.btnEditSubscriptionType.Click += new System.EventHandler(this.btnEditSubscriptionType_Click);
            // 
            // btnAddSubscriptionType
            // 
            this.btnAddSubscriptionType.Location = new System.Drawing.Point(15, 15);
            this.btnAddSubscriptionType.Name = "btnAddSubscriptionType";
            this.btnAddSubscriptionType.Size = new System.Drawing.Size(170, 40);
            this.btnAddSubscriptionType.TabIndex = 0;
            this.btnAddSubscriptionType.Text = "Добавить тип";
            this.btnAddSubscriptionType.UseVisualStyleBackColor = true;
            this.btnAddSubscriptionType.Click += new System.EventHandler(this.btnAddSubscriptionType_Click);
            // 
            // dgvSubscriptionTypes
            // 
            this.dgvSubscriptionTypes.AllowUserToAddRows = false;
            this.dgvSubscriptionTypes.AllowUserToDeleteRows = false;
            this.dgvSubscriptionTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubscriptionTypes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSubscriptionTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubscriptionTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubscriptionTypes.Location = new System.Drawing.Point(3, 3);
            this.dgvSubscriptionTypes.MultiSelect = false;
            this.dgvSubscriptionTypes.Name = "dgvSubscriptionTypes";
            this.dgvSubscriptionTypes.ReadOnly = true;
            this.dgvSubscriptionTypes.RowHeadersWidth = 51;
            this.dgvSubscriptionTypes.RowTemplate.Height = 24;
            this.dgvSubscriptionTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubscriptionTypes.Size = new System.Drawing.Size(986, 538);
            this.dgvSubscriptionTypes.TabIndex = 0;
            // 
            // SubscriptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelHeader);
            this.Name = "SubscriptionsForm";
            this.Text = "Управление абонементами";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabSubscriptions.ResumeLayout(false);
            this.panelActions.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubscriptions)).EndInit();
            this.tabTypes.ResumeLayout(false);
            this.panelTypesActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubscriptionTypes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSubscriptions;
        private System.Windows.Forms.TabPage tabTypes;
        private System.Windows.Forms.DataGridView dgvSubscriptions;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnRunAutoRenewal;
        private System.Windows.Forms.Button btnToggleAutoRenew;
        private System.Windows.Forms.Button btnExtendSubscription;
        private System.Windows.Forms.Button btnEditSubscription;
        private System.Windows.Forms.Button btnAddSubscription;
        private System.Windows.Forms.DataGridView dgvSubscriptionTypes;
        private System.Windows.Forms.Panel panelTypesActions;
        private System.Windows.Forms.Button btnEditSubscriptionType;
        private System.Windows.Forms.Button btnAddSubscriptionType;
        private System.Windows.Forms.Button btnExport;
    }
}