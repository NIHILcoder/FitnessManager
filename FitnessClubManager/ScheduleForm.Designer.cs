namespace FitnessManager
{
    partial class ScheduleForm
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
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.scheduleGrid = new System.Windows.Forms.DataGridView();
            this.lblSelectedDate = new System.Windows.Forms.Label();
            this.cmbTimeFilter = new System.Windows.Forms.ComboBox();
            this.lblTimeFilter = new System.Windows.Forms.Label();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRegisterClient = new System.Windows.Forms.Button();
            this.btnDeleteClass = new System.Windows.Forms.Button();
            this.btnEditClass = new System.Windows.Forms.Button();
            this.btnAddClass = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGrid)).BeginInit();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
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
            this.lblTitle.Size = new System.Drawing.Size(240, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "РАСПИСАНИЕ ЗАНЯТИЙ";
            // 
            // calendar
            // 
            this.calendar.CalendarDimensions = new System.Drawing.Size(1, 2);
            this.calendar.Location = new System.Drawing.Point(20, 100);
            this.calendar.MaxSelectionCount = 1;
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 1;
            this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar_DateChanged);
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
            this.scheduleGrid.MultiSelect = false;
            this.scheduleGrid.Name = "scheduleGrid";
            this.scheduleGrid.ReadOnly = true;
            this.scheduleGrid.RowHeadersWidth = 51;
            this.scheduleGrid.RowTemplate.Height = 24;
            this.scheduleGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.scheduleGrid.Size = new System.Drawing.Size(670, 500);
            this.scheduleGrid.TabIndex = 2;
            // 
            // lblSelectedDate
            // 
            this.lblSelectedDate.AutoSize = true;
            this.lblSelectedDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSelectedDate.Location = new System.Drawing.Point(300, 70);
            this.lblSelectedDate.Name = "lblSelectedDate";
            this.lblSelectedDate.Size = new System.Drawing.Size(147, 23);
            this.lblSelectedDate.TabIndex = 3;
            this.lblSelectedDate.Text = "Расписание на...";
            // 
            // cmbTimeFilter
            // 
            this.cmbTimeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeFilter.FormattingEnabled = true;
            this.cmbTimeFilter.Location = new System.Drawing.Point(765, 69);
            this.cmbTimeFilter.Name = "cmbTimeFilter";
            this.cmbTimeFilter.Size = new System.Drawing.Size(205, 28);
            this.cmbTimeFilter.TabIndex = 4;
            this.cmbTimeFilter.SelectedIndexChanged += new System.EventHandler(this.cmbTimeFilter_SelectedIndexChanged);
            // 
            // lblTimeFilter
            // 
            this.lblTimeFilter.AutoSize = true;
            this.lblTimeFilter.Location = new System.Drawing.Point(697, 72);
            this.lblTimeFilter.Name = "lblTimeFilter";
            this.lblTimeFilter.Size = new System.Drawing.Size(62, 20);
            this.lblTimeFilter.TabIndex = 5;
            this.lblTimeFilter.Text = "Время:";
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.btnRefresh);
            this.panelActions.Controls.Add(this.btnRegisterClient);
            this.panelActions.Controls.Add(this.btnDeleteClass);
            this.panelActions.Controls.Add(this.btnEditClass);
            this.panelActions.Controls.Add(this.btnAddClass);
            this.panelActions.Location = new System.Drawing.Point(20, 350);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(250, 250);
            this.panelActions.TabIndex = 6;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(10, 190);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(230, 40);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRegisterClient
            // 
            this.btnRegisterClient.Location = new System.Drawing.Point(10, 145);
            this.btnRegisterClient.Name = "btnRegisterClient";
            this.btnRegisterClient.Size = new System.Drawing.Size(230, 40);
            this.btnRegisterClient.TabIndex = 3;
            this.btnRegisterClient.Text = "Записать клиента";
            this.btnRegisterClient.UseVisualStyleBackColor = true;
            this.btnRegisterClient.Click += new System.EventHandler(this.btnRegisterClient_Click);
            // 
            // btnDeleteClass
            // 
            this.btnDeleteClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeleteClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteClass.ForeColor = System.Drawing.Color.White;
            this.btnDeleteClass.Location = new System.Drawing.Point(10, 100);
            this.btnDeleteClass.Name = "btnDeleteClass";
            this.btnDeleteClass.Size = new System.Drawing.Size(230, 40);
            this.btnDeleteClass.TabIndex = 2;
            this.btnDeleteClass.Text = "Удалить занятие";
            this.btnDeleteClass.UseVisualStyleBackColor = false;
            this.btnDeleteClass.Click += new System.EventHandler(this.btnDeleteClass_Click);
            // 
            // btnEditClass
            // 
            this.btnEditClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnEditClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditClass.ForeColor = System.Drawing.Color.White;
            this.btnEditClass.Location = new System.Drawing.Point(10, 55);
            this.btnEditClass.Name = "btnEditClass";
            this.btnEditClass.Size = new System.Drawing.Size(230, 40);
            this.btnEditClass.TabIndex = 1;
            this.btnEditClass.Text = "Редактировать занятие";
            this.btnEditClass.UseVisualStyleBackColor = false;
            this.btnEditClass.Click += new System.EventHandler(this.btnEditClass_Click);
            // 
            // btnAddClass
            // 
            this.btnAddClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnAddClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddClass.ForeColor = System.Drawing.Color.White;
            this.btnAddClass.Location = new System.Drawing.Point(10, 10);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(230, 40);
            this.btnAddClass.TabIndex = 0;
            this.btnAddClass.Text = "Добавить занятие";
            this.btnAddClass.UseVisualStyleBackColor = false;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // ScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.lblTimeFilter);
            this.Controls.Add(this.cmbTimeFilter);
            this.Controls.Add(this.lblSelectedDate);
            this.Controls.Add(this.scheduleGrid);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "ScheduleForm";
            this.Text = "Расписание занятий";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGrid)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.DataGridView scheduleGrid;
        private System.Windows.Forms.Label lblSelectedDate;
        private System.Windows.Forms.ComboBox cmbTimeFilter;
        private System.Windows.Forms.Label lblTimeFilter;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRegisterClient;
        private System.Windows.Forms.Button btnDeleteClass;
        private System.Windows.Forms.Button btnEditClass;
        private System.Windows.Forms.Button btnAddClass;
    }
}