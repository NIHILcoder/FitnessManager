using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FitnessManager
{
    public partial class ReportViewerForm : Form
    {
        private DataTable reportData;

        public ReportViewerForm(string title, DataTable data)
        {
            InitializeComponent();
            this.Text = title;
            lblReportTitle.Text = title;
            this.reportData = data;
        }

        private void ReportViewerForm_Load(object sender, EventArgs e)
        {
            // Заполняем DataGridView данными отчета
            dgvReport.DataSource = reportData;

            // Настраиваем внешний вид таблицы
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.ReadOnly = true;
            dgvReport.BackgroundColor = SystemColors.Control;
            dgvReport.RowHeadersWidth = 51;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Добавляем итоговую информацию
            lblRecordCount.Text = $"Количество записей: {reportData.Rows.Count}";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Заглушка для печати - в реальном проекте здесь была бы логика печати
            MessageBox.Show("Функция печати будет доступна в следующей версии",
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Экспорт данных в текстовый файл
            DataExportHelper.ExportToTxt(reportData, lblReportTitle.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}