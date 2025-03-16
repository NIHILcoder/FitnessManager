namespace FitnessManager
{
    partial class ReportsForm
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
            this.panelReports = new System.Windows.Forms.Panel();
            this.btnIncomeReport = new System.Windows.Forms.Button();
            this.btnClientsExpired = new System.Windows.Forms.Button();
            this.btnVisitStatistics = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
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
            this.lblTitle.Size = new System.Drawing.Size(113, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ОТЧЕТЫ";
            // 
            // panelReports
            // 
            this.panelReports.Controls.Add(this.btnIncomeReport);
            this.panelReports.Controls.Add(this.btnClientsExpired);
            this.panelReports.Controls.Add(this.btnVisitStatistics);
            this.panelReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReports.Location = new System.Drawing.Point(0, 60);
            this.panelReports.Name = "panelReports";
            this.panelReports.Size = new System.Drawing.Size(1000, 580);
            this.panelReports.TabIndex = 1;
            // 
            // btnIncomeReport
            // 
            this.btnIncomeReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnIncomeReport.FlatAppearance.BorderSize = 0;
            this.btnIncomeReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncomeReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnIncomeReport.ForeColor = System.Drawing.Color.White;
            this.btnIncomeReport.Location = new System.Drawing.Point(50, 220);
            this.btnIncomeReport.Name = "btnIncomeReport";
            this.btnIncomeReport.Size = new System.Drawing.Size(250, 60);
            this.btnIncomeReport.TabIndex = 2;
            this.btnIncomeReport.Text = "Отчет по доходам";
            this.btnIncomeReport.UseVisualStyleBackColor = false;
            this.btnIncomeReport.Click += new System.EventHandler(this.btnIncomeReport_Click);
            // 
            // btnClientsExpired
            // 
            this.btnClientsExpired.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnClientsExpired.FlatAppearance.BorderSize = 0;
            this.btnClientsExpired.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientsExpired.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClientsExpired.ForeColor = System.Drawing.Color.White;
            this.btnClientsExpired.Location = new System.Drawing.Point(50, 130);
            this.btnClientsExpired.Name = "btnClientsExpired";
            this.btnClientsExpired.Size = new System.Drawing.Size(320, 60);
            this.btnClientsExpired.TabIndex = 1;
            this.btnClientsExpired.Text = "Клиенты с истекшими абонементами";
            this.btnClientsExpired.UseVisualStyleBackColor = false;
            this.btnClientsExpired.Click += new System.EventHandler(this.btnClientsExpired_Click);
            // 
            // btnVisitStatistics
            // 
            this.btnVisitStatistics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnVisitStatistics.FlatAppearance.BorderSize = 0;
            this.btnVisitStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisitStatistics.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnVisitStatistics.ForeColor = System.Drawing.Color.White;
            this.btnVisitStatistics.Location = new System.Drawing.Point(50, 40);
            this.btnVisitStatistics.Name = "btnVisitStatistics";
            this.btnVisitStatistics.Size = new System.Drawing.Size(250, 60);
            this.btnVisitStatistics.TabIndex = 0;
            this.btnVisitStatistics.Text = "Статистика посещений";
            this.btnVisitStatistics.UseVisualStyleBackColor = false;
            this.btnVisitStatistics.Click += new System.EventHandler(this.btnVisitStatistics_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Controls.Add(this.panelReports);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "ReportsForm";
            this.Text = "Отчеты";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelReports.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelReports;
        private System.Windows.Forms.Button btnIncomeReport;
        private System.Windows.Forms.Button btnClientsExpired;
        private System.Windows.Forms.Button btnVisitStatistics;
    }
}