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
            // Показываем форму для выбора формата экспорта
            Form exportForm = new Form();
            exportForm.Text = "Выберите формат экспорта";
            exportForm.Size = new Size(300, 200);
            exportForm.StartPosition = FormStartPosition.CenterParent;
            exportForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            exportForm.MaximizeBox = false;
            exportForm.MinimizeBox = false;

            Button btnExportText = new Button();
            btnExportText.Text = "Текстовый файл (TXT)";
            btnExportText.Location = new Point(75, 20);
            btnExportText.Size = new Size(150, 30);
            btnExportText.Click += (s, args) => {
                DataExportHelper.ExportToTxt(reportData, lblReportTitle.Text);
                exportForm.Close();
            };

            Button btnExportExcel = new Button();
            btnExportExcel.Text = "Excel (XLSX)";
            btnExportExcel.Location = new Point(75, 60);
            btnExportExcel.Size = new Size(150, 30);
            btnExportExcel.Click += (s, args) => {
                DataExportHelper.ExportToExcel(reportData, lblReportTitle.Text);
                exportForm.Close();
            };

            Button btnExportPdf = new Button();
            btnExportPdf.Text = "PDF";
            btnExportPdf.Location = new Point(75, 100);
            btnExportPdf.Size = new Size(150, 30);
            btnExportPdf.Click += (s, args) => {
                DataExportHelper.ExportToPdf(reportData, lblReportTitle.Text);
                exportForm.Close();
            };

            exportForm.Controls.Add(btnExportText);
            exportForm.Controls.Add(btnExportExcel);
            exportForm.Controls.Add(btnExportPdf);
            exportForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}