namespace FitnessManager
{
    partial class TrainersForm
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
            this.panelSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvTrainers = new System.Windows.Forms.DataGridView();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRateTrainer = new System.Windows.Forms.Button();
            this.btnViewSchedule = new System.Windows.Forms.Button();
            this.btnDeleteTrainer = new System.Windows.Forms.Button();
            this.btnEditTrainer = new System.Windows.Forms.Button();
            this.btnAddTrainer = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainers)).BeginInit();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
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
            this.lblTitle.Size = new System.Drawing.Size(134, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ТРЕНЕРЫ";
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Controls.Add(this.lblSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 60);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1000, 50);
            this.panelSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(140, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(350, 28);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(20, 14);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(114, 20);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Поиск тренера:";
            // 
            // dgvTrainers
            // 
            this.dgvTrainers.AllowUserToAddRows = false;
            this.dgvTrainers.AllowUserToDeleteRows = false;
            this.dgvTrainers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTrainers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTrainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrainers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrainers.Location = new System.Drawing.Point(0, 110);
            this.dgvTrainers.MultiSelect = false;
            this.dgvTrainers.Name = "dgvTrainers";
            this.dgvTrainers.ReadOnly = true;
            this.dgvTrainers.RowHeadersWidth = 51;
            this.dgvTrainers.RowTemplate.Height = 24;
            this.dgvTrainers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrainers.Size = new System.Drawing.Size(800, 530);
            this.dgvTrainers.TabIndex = 2;
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.btnRefresh);
            this.panelActions.Controls.Add(this.btnRateTrainer);
            this.panelActions.Controls.Add(this.btnViewSchedule);
            this.panelActions.Controls.Add(this.btnDeleteTrainer);
            this.panelActions.Controls.Add(this.btnEditTrainer);
            this.panelActions.Controls.Add(this.btnAddTrainer);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelActions.Location = new System.Drawing.Point(800, 110);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(200, 530);
            this.panelActions.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(15, 250);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(170, 40);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRateTrainer
            // 
            this.btnRateTrainer.Location = new System.Drawing.Point(15, 200);
            this.btnRateTrainer.Name = "btnRateTrainer";
            this.btnRateTrainer.Size = new System.Drawing.Size(170, 40);
            this.btnRateTrainer.TabIndex = 4;
            this.btnRateTrainer.Text = "Оценить тренера";
            this.btnRateTrainer.UseVisualStyleBackColor = true;
            this.btnRateTrainer.Click += new System.EventHandler(this.btnRateTrainer_Click);
            // 
            // btnViewSchedule
            // 
            this.btnViewSchedule.Location = new System.Drawing.Point(15, 150);
            this.btnViewSchedule.Name = "btnViewSchedule";
            this.btnViewSchedule.Size = new System.Drawing.Size(170, 40);
            this.btnViewSchedule.TabIndex = 3;
            this.btnViewSchedule.Text = "Расписание";
            this.btnViewSchedule.UseVisualStyleBackColor = true;
            this.btnViewSchedule.Click += new System.EventHandler(this.btnViewSchedule_Click);
            // 
            // btnDeleteTrainer
            // 
            this.btnDeleteTrainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnDeleteTrainer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTrainer.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTrainer.Location = new System.Drawing.Point(15, 100);
            this.btnDeleteTrainer.Name = "btnDeleteTrainer";
            this.btnDeleteTrainer.Size = new System.Drawing.Size(170, 40);
            this.btnDeleteTrainer.TabIndex = 2;
            this.btnDeleteTrainer.Text = "Удалить";
            this.btnDeleteTrainer.UseVisualStyleBackColor = false;
            this.btnDeleteTrainer.Click += new System.EventHandler(this.btnDeleteTrainer_Click);
            // 
            // btnEditTrainer
            // 
            this.btnEditTrainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnEditTrainer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTrainer.ForeColor = System.Drawing.Color.White;
            this.btnEditTrainer.Location = new System.Drawing.Point(15, 50);
            this.btnEditTrainer.Name = "btnEditTrainer";
            this.btnEditTrainer.Size = new System.Drawing.Size(170, 40);
            this.btnEditTrainer.TabIndex = 1;
            this.btnEditTrainer.Text = "Редактировать";
            this.btnEditTrainer.UseVisualStyleBackColor = false;
            this.btnEditTrainer.Click += new System.EventHandler(this.btnEditTrainer_Click);
            // 
            // btnAddTrainer
            // 
            this.btnAddTrainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnAddTrainer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTrainer.ForeColor = System.Drawing.Color.White;
            this.btnAddTrainer.Location = new System.Drawing.Point(15, 0);
            this.btnAddTrainer.Name = "btnAddTrainer";
            this.btnAddTrainer.Size = new System.Drawing.Size(170, 40);
            this.btnAddTrainer.TabIndex = 0;
            this.btnAddTrainer.Text = "Добавить тренера";
            this.btnAddTrainer.UseVisualStyleBackColor = false;
            this.btnAddTrainer.Click += new System.EventHandler(this.btnAddTrainer_Click);
            // 
            // TrainersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Controls.Add(this.dgvTrainers);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "TrainersForm";
            this.Text = "Тренеры";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainers)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dgvTrainers;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRateTrainer;
        private System.Windows.Forms.Button btnViewSchedule;
        private System.Windows.Forms.Button btnDeleteTrainer;
        private System.Windows.Forms.Button btnEditTrainer;
        private System.Windows.Forms.Button btnAddTrainer;
    }
}