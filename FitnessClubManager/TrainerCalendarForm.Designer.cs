namespace FitnessManager
{
    partial class TrainerCalendarForm
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
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.scheduleGrid = new System.Windows.Forms.DataGridView();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.btnEditSchedule = new System.Windows.Forms.Button();
            this.btnDeleteSchedule = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbTimeFilter = new System.Windows.Forms.ComboBox();
            this.lblSelectedDate = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGrid)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendar
            // 
            this.calendar.CalendarDimensions = new System.Drawing.Size(1, 2);
            this.calendar.Location = new System.Drawing.Point(20, 70);
            this.calendar.MaxSelectionCount = 1;
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 0;
            this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Calendar_DateChanged);
            // 
            // scheduleGrid
            // 
            this.scheduleGrid.AllowUserToAddRows = false;
            this.scheduleGrid.AllowUserToDeleteRows = false;
            this.scheduleGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scheduleGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.scheduleGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.scheduleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scheduleGrid.Location = new System.Drawing.Point(300, 100);
            this.scheduleGrid.Name = "scheduleGrid";
            this.scheduleGrid.ReadOnly = true;
            this.scheduleGrid.RowHeadersVisible = false;
            this.scheduleGrid.RowHeadersWidth = 51;
            this.scheduleGrid.RowTemplate.Height = 24;
            this.scheduleGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.scheduleGrid.Size = new System.Drawing.Size(480, 350);
            this.scheduleGrid.TabIndex = 1;
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnAddSchedule.FlatAppearance.BorderSize = 0;
            this.btnAddSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSchedule.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddSchedule.ForeColor = System.Drawing.Color.White;
            this.btnAddSchedule.Location = new System.Drawing.Point(20, 325);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(120, 35);
            this.btnAddSchedule.TabIndex = 2;
            this.btnAddSchedule.Text = "Добавить";
            this.btnAddSchedule.UseVisualStyleBackColor = false;
            this.btnAddSchedule.Click += new System.EventHandler(this.BtnAddSchedule_Click);
            // 
            // btnEditSchedule
            // 
            this.btnEditSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnEditSchedule.FlatAppearance.BorderSize = 0;
            this.btnEditSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditSchedule.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditSchedule.ForeColor = System.Drawing.Color.White;
            this.btnEditSchedule.Location = new System.Drawing.Point(20, 370);
            this.btnEditSchedule.Name = "btnEditSchedule";
            this.btnEditSchedule.Size = new System.Drawing.Size(120, 35);
            this.btnEditSchedule.TabIndex = 3;
            this.btnEditSchedule.Text = "Изменить";
            this.btnEditSchedule.UseVisualStyleBackColor = false;
            this.btnEditSchedule.Click += new System.EventHandler(this.BtnEditSchedule_Click);
            // 
            // btnDeleteSchedule
            // 
            this.btnDeleteSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnDeleteSchedule.FlatAppearance.BorderSize = 0;
            this.btnDeleteSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSchedule.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteSchedule.ForeColor = System.Drawing.Color.White;
            this.btnDeleteSchedule.Location = new System.Drawing.Point(20, 415);
            this.btnDeleteSchedule.Name = "btnDeleteSchedule";
            this.btnDeleteSchedule.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteSchedule.TabIndex = 4;
            this.btnDeleteSchedule.Text = "Удалить";
            this.btnDeleteSchedule.UseVisualStyleBackColor = false;
            this.btnDeleteSchedule.Click += new System.EventHandler(this.BtnDeleteSchedule_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(160, 325);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 35);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // cmbTimeFilter
            // 
            this.cmbTimeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbTimeFilter.FormattingEnabled = true;
            this.cmbTimeFilter.Items.AddRange(new object[] {
            "Все часы",
            "Утро (6:00-12:00)",
            "День (12:00-18:00)",
            "Вечер (18:00-23:00)"});
            this.cmbTimeFilter.Location = new System.Drawing.Point(300, 60);
            this.cmbTimeFilter.Name = "cmbTimeFilter";
            this.cmbTimeFilter.Size = new System.Drawing.Size(200, 28);
            this.cmbTimeFilter.TabIndex = 6;
            this.cmbTimeFilter.SelectedIndexChanged += new System.EventHandler(this.CmbTimeFilter_SelectedIndexChanged);
            // 
            // lblSelectedDate
            // 
            this.lblSelectedDate.AutoSize = true;
            this.lblSelectedDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSelectedDate.Location = new System.Drawing.Point(300, 30);
            this.lblSelectedDate.Name = "lblSelectedDate";
            this.lblSelectedDate.Size = new System.Drawing.Size(163, 25);
            this.lblSelectedDate.TabIndex = 7;
            this.lblSelectedDate.Text = "Расписание на ...";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 50);
            this.panelHeader.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "КАЛЕНДАРЬ ЗАНЯТИЙ";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(660, 470);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 35);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TrainerCalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lblSelectedDate);
            this.Controls.Add(this.cmbTimeFilter);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeleteSchedule);
            this.Controls.Add(this.btnEditSchedule);
            this.Controls.Add(this.btnAddSchedule);
            this.Controls.Add(this.scheduleGrid);
            this.Controls.Add(this.calendar);
            this.Name = "TrainerCalendarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Календарь занятий тренера";
            this.Load += new System.EventHandler(this.TrainerCalendarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGrid)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.DataGridView scheduleGrid;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Button btnEditSchedule;
        private System.Windows.Forms.Button btnDeleteSchedule;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbTimeFilter;
        private System.Windows.Forms.Label lblSelectedDate;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
    }
}