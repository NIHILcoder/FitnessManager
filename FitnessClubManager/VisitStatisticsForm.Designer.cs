namespace FitnessManager
{
    partial class VisitStatisticsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.cmbPeriod = new System.Windows.Forms.ComboBox();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chartVisits = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chartClasses = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.lblTopClass = new System.Windows.Forms.Label();
            this.lblUniqueClients = new System.Windows.Forms.Label();
            this.lblTotalVisits = new System.Windows.Forms.Label();
            this.lblTopClassTitle = new System.Windows.Forms.Label();
            this.lblUniqueClientsTitle = new System.Windows.Forms.Label();
            this.lblTotalVisitsTitle = new System.Windows.Forms.Label();
            this.lblSummaryTitle = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVisits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartClasses)).BeginInit();
            this.panelSummary.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelTop.Controls.Add(this.btnExport);
            this.panelTop.Controls.Add(this.cmbPeriod);
            this.panelTop.Controls.Add(this.lblPeriod);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 60);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 50);
            this.panelTop.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(850, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(130, 32);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Экспорт";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cmbPeriod
            // 
            this.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriod.FormattingEnabled = true;
            this.cmbPeriod.Location = new System.Drawing.Point(148, 10);
            this.cmbPeriod.Name = "cmbPeriod";
            this.cmbPeriod.Size = new System.Drawing.Size(250, 31);
            this.cmbPeriod.TabIndex = 1;
            this.cmbPeriod.SelectedIndexChanged += new System.EventHandler(this.cmbPeriod_SelectedIndexChanged);
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(25, 14);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(117, 23);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Выбор периода:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 110);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chartVisits);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1000, 550);
            this.splitContainer1.SplitterDistance = 270;
            this.splitContainer1.TabIndex = 1;
            // 
            // chartVisits
            // 
            chartArea1.Name = "ChartArea1";
            this.chartVisits.ChartAreas.Add(chartArea1);
            this.chartVisits.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartVisits.Legends.Add(legend1);
            this.chartVisits.Location = new System.Drawing.Point(0, 0);
            this.chartVisits.Name = "chartVisits";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartVisits.Series.Add(series1);
            this.chartVisits.Size = new System.Drawing.Size(1000, 270);
            this.chartVisits.TabIndex = 0;
            this.chartVisits.Text = "Посещения";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chartClasses);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panelSummary);
            this.splitContainer2.Size = new System.Drawing.Size(1000, 276);
            this.splitContainer2.SplitterDistance = 600;
            this.splitContainer2.TabIndex = 0;
            // 
            // chartClasses
            // 
            chartArea2.Name = "ChartArea1";
            this.chartClasses.ChartAreas.Add(chartArea2);
            this.chartClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartClasses.Legends.Add(legend2);
            this.chartClasses.Location = new System.Drawing.Point(0, 0);
            this.chartClasses.Name = "chartClasses";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartClasses.Series.Add(series2);
            this.chartClasses.Size = new System.Drawing.Size(600, 276);
            this.chartClasses.TabIndex = 0;
            this.chartClasses.Text = "Занятия";
            // 
            // panelSummary
            // 
            this.panelSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelSummary.Controls.Add(this.lblTopClass);
            this.panelSummary.Controls.Add(this.lblUniqueClients);
            this.panelSummary.Controls.Add(this.lblTotalVisits);
            this.panelSummary.Controls.Add(this.lblTopClassTitle);
            this.panelSummary.Controls.Add(this.lblUniqueClientsTitle);
            this.panelSummary.Controls.Add(this.lblTotalVisitsTitle);
            this.panelSummary.Controls.Add(this.lblSummaryTitle);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSummary.Location = new System.Drawing.Point(0, 0);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(396, 276);
            this.panelSummary.TabIndex = 0;
            // 
            // lblTopClass
            // 
            this.lblTopClass.AutoSize = true;
            this.lblTopClass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTopClass.Location = new System.Drawing.Point(226, 170);
            this.lblTopClass.Name = "lblTopClass";
            this.lblTopClass.Size = new System.Drawing.Size(20, 23);
            this.lblTopClass.TabIndex = 6;
            this.lblTopClass.Text = "0";
            // 
            // lblUniqueClients
            // 
            this.lblUniqueClients.AutoSize = true;
            this.lblUniqueClients.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUniqueClients.Location = new System.Drawing.Point(226, 120);
            this.lblUniqueClients.Name = "lblUniqueClients";
            this.lblUniqueClients.Size = new System.Drawing.Size(20, 23);
            this.lblUniqueClients.TabIndex = 5;
            this.lblUniqueClients.Text = "0";
            // 
            // lblTotalVisits
            // 
            this.lblTotalVisits.AutoSize = true;
            this.lblTotalVisits.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotalVisits.Location = new System.Drawing.Point(226, 70);
            this.lblTotalVisits.Name = "lblTotalVisits";
            this.lblTotalVisits.Size = new System.Drawing.Size(20, 23);
            this.lblTotalVisits.TabIndex = 4;
            this.lblTotalVisits.Text = "0";
            // 
            // lblTopClassTitle
            // 
            this.lblTopClassTitle.AutoSize = true;
            this.lblTopClassTitle.Location = new System.Drawing.Point(25, 170);
            this.lblTopClassTitle.Name = "lblTopClassTitle";
            this.lblTopClassTitle.Size = new System.Drawing.Size(188, 23);
            this.lblTopClassTitle.TabIndex = 3;
            this.lblTopClassTitle.Text = "Популярное занятие:";
            // 
            // lblUniqueClientsTitle
            // 
            this.lblUniqueClientsTitle.AutoSize = true;
            this.lblUniqueClientsTitle.Location = new System.Drawing.Point(25, 120);
            this.lblUniqueClientsTitle.Name = "lblUniqueClientsTitle";
            this.lblUniqueClientsTitle.Size = new System.Drawing.Size(171, 23);
            this.lblUniqueClientsTitle.TabIndex = 2;
            this.lblUniqueClientsTitle.Text = "Уникальных клиентов:";
            // 
            // lblTotalVisitsTitle
            // 
            this.lblTotalVisitsTitle.AutoSize = true;
            this.lblTotalVisitsTitle.Location = new System.Drawing.Point(25, 70);
            this.lblTotalVisitsTitle.Name = "lblTotalVisitsTitle";
            this.lblTotalVisitsTitle.Size = new System.Drawing.Size(145, 23);
            this.lblTotalVisitsTitle.TabIndex = 1;
            this.lblTotalVisitsTitle.Text = "Всего посещений:";
            // 
            // lblSummaryTitle
            // 
            this.lblSummaryTitle.AutoSize = true;
            this.lblSummaryTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSummaryTitle.Location = new System.Drawing.Point(15, 15);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.Size = new System.Drawing.Size(230, 28);
            this.lblSummaryTitle.TabIndex = 0;
            this.lblSummaryTitle.Text = "Основные показатели";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 60);
            this.panelHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(331, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "СТАТИСТИКА ПОСЕЩЕНИЙ";
            // 
            // VisitStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 660);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "VisitStatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Статистика посещений";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVisits)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartClasses)).EndInit();
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox cmbPeriod;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVisits;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartClasses;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.Label lblTopClass;
        private System.Windows.Forms.Label lblUniqueClients;
        private System.Windows.Forms.Label lblTotalVisits;
        private System.Windows.Forms.Label lblTopClassTitle;
        private System.Windows.Forms.Label lblUniqueClientsTitle;
        private System.Windows.Forms.Label lblTotalVisitsTitle;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
    }
}