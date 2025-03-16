using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Npgsql;

namespace FitnessManager
{
    public partial class VisitStatisticsForm : Form
    {
        private string connectionString = DBConnection.ConnectionString;
        private Dictionary<int, string> selectedPeriods = new Dictionary<int, string>
        {
            { 0, "Последние 7 дней" },
            { 1, "Последний месяц" },
            { 3, "Последние 3 месяца" },
            { 6, "Последние 6 месяцев" },
            { 12, "Последний год" }
        };

        public VisitStatisticsForm()
        {
            InitializeComponent();

            // Инициализируем комбобокс с выбором периода
            cmbPeriod.Items.Clear();
            foreach (var period in selectedPeriods.Values)
            {
                cmbPeriod.Items.Add(period);
            }
            cmbPeriod.SelectedIndex = 1; // По умолчанию - последний месяц

            // Инициализируем график
            InitializeChart();

            // Загружаем статистику
            LoadVisitStatistics();
        }

        private void InitializeChart()
        {
            // Очищаем текущие серии
            chartVisits.Series.Clear();

            // Настраиваем внешний вид графика
            chartVisits.BackColor = Color.FromArgb(240, 240, 240);
            chartVisits.BorderlineColor = Color.FromArgb(200, 200, 200);
            chartVisits.BorderlineDashStyle = ChartDashStyle.Solid;

            // Настройка легенды
            chartVisits.Legends.Add(new Legend("MainLegend"));
            chartVisits.Legends["MainLegend"].Docking = Docking.Bottom;

            // Создаем и настраиваем область графика
            ChartArea chartArea = new ChartArea("MainChartArea");
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 8);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
            chartArea.AxisX.Title = "Дата";
            chartArea.AxisY.Title = "Количество посещений";
            chartArea.AxisX.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            chartArea.AxisY.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            chartArea.BackColor = Color.White;

            chartVisits.ChartAreas.Add(chartArea);

            // Добавляем серию данных для диаграммы
            Series series = new Series("Посещения");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.FromArgb(0, 122, 204);
            series.IsVisibleInLegend = true;

            chartVisits.Series.Add(series);

            // Добавляем серию для линейного тренда
            Series trendSeries = new Series("Тренд");
            trendSeries.ChartType = SeriesChartType.Line;
            trendSeries.Color = Color.FromArgb(231, 76, 60);
            trendSeries.BorderWidth = 2;
            trendSeries.IsVisibleInLegend = true;

            chartVisits.Series.Add(trendSeries);

            // Аналогично для второго графика (pie chart)
            chartClasses.Series.Clear();
            chartClasses.Legends.Clear();

            chartClasses.BackColor = Color.FromArgb(240, 240, 240);
            chartClasses.BorderlineColor = Color.FromArgb(200, 200, 200);
            chartClasses.BorderlineDashStyle = ChartDashStyle.Solid;

            ChartArea pieArea = new ChartArea("PieChartArea");
            pieArea.BackColor = Color.White;
            chartClasses.ChartAreas.Add(pieArea);

            chartClasses.Legends.Add(new Legend("ClassesLegend"));
            chartClasses.Legends["ClassesLegend"].Docking = Docking.Bottom;
        }

        private void LoadVisitStatistics()
        {
            try
            {
                // Определяем период для запроса
                int monthsBack = 1; // По умолчанию последний месяц

                foreach (var period in selectedPeriods)
                {
                    if (period.Value == cmbPeriod.SelectedItem.ToString())
                    {
                        monthsBack = period.Key;
                        break;
                    }
                }

                // Формируем запрос в зависимости от периода
                string dateFilter = "";

                if (monthsBack == 0) // Последние 7 дней
                {
                    dateFilter = "AND v.VisitDate >= CURRENT_DATE - INTERVAL '7 days'";
                }
                else
                {
                    dateFilter = $"AND v.VisitDate >= CURRENT_DATE - INTERVAL '{monthsBack} months'";
                }

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Загружаем данные о посещениях по дням
                    string query = $@"
                        SELECT 
                            v.VisitDate,
                            COUNT(*) as VisitCount
                        FROM 
                            Visits v
                        WHERE 
                            v.VisitDate IS NOT NULL
                            {dateFilter}
                        GROUP BY 
                            v.VisitDate
                        ORDER BY 
                            v.VisitDate";

                    DataTable dtVisits = new DataTable();
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        adapter.Fill(dtVisits);
                    }

                    // Загружаем данные о посещениях по классам
                    string classQuery = $@"
                        SELECT 
                            c.Name,
                            COUNT(*) as VisitCount
                        FROM 
                            Visits v
                            JOIN Schedule s ON v.ScheduleID = s.ScheduleID
                            JOIN Classes c ON s.ClassID = c.ClassID
                        WHERE 
                            v.VisitDate IS NOT NULL
                            {dateFilter}
                        GROUP BY 
                            c.Name
                        ORDER BY 
                            VisitCount DESC";

                    DataTable dtClasses = new DataTable();
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(classQuery, connection))
                    {
                        adapter.Fill(dtClasses);
                    }

                    // Отображаем данные
                    DisplayVisitChart(dtVisits);
                    DisplayPieChart(dtClasses);

                    // Отображаем основные показатели
                    DisplayStatisticsSummary(connection, dateFilter);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке статистики посещений: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayStatisticsSummary(NpgsqlConnection connection, string dateFilter)
        {
            try
            {
                string totalQuery = $@"
                    SELECT 
                        COUNT(*) as TotalVisits,
                        COUNT(DISTINCT v.ClientID) as UniqueClients
                    FROM 
                        Visits v
                    WHERE 
                        v.VisitDate IS NOT NULL
                        {dateFilter}";

                using (NpgsqlCommand command = new NpgsqlCommand(totalQuery, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int totalVisits = reader.GetInt32(0);
                            int uniqueClients = reader.GetInt32(1);

                            lblTotalVisits.Text = totalVisits.ToString();
                            lblUniqueClients.Text = uniqueClients.ToString();
                        }
                    }
                }

                // Самое популярное занятие
                string topClassQuery = $@"
                    SELECT 
                        c.Name,
                        COUNT(*) as VisitCount
                    FROM 
                        Visits v
                        JOIN Schedule s ON v.ScheduleID = s.ScheduleID
                        JOIN Classes c ON s.ClassID = c.ClassID
                    WHERE 
                        v.VisitDate IS NOT NULL
                        {dateFilter}
                    GROUP BY 
                        c.Name
                    ORDER BY 
                        VisitCount DESC
                    LIMIT 1";

                using (NpgsqlCommand command = new NpgsqlCommand(topClassQuery, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string className = reader.GetString(0);
                            int visitCount = reader.GetInt32(1);

                            lblTopClass.Text = $"{className} ({visitCount} посещений)";
                        }
                        else
                        {
                            lblTopClass.Text = "Нет данных";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading statistics summary: {ex.Message}");
            }
        }

        private void DisplayVisitChart(DataTable dtVisits)
        {
            try
            {
                // Очищаем текущие данные
                chartVisits.Series["Посещения"].Points.Clear();
                chartVisits.Series["Тренд"].Points.Clear();

                if (dtVisits.Rows.Count == 0)
                {
                    // Нет данных для отображения
                    chartVisits.Titles.Clear();
                    chartVisits.Titles.Add("Нет данных о посещениях за выбранный период");
                    return;
                }

                // Добавляем заголовок
                chartVisits.Titles.Clear();
                chartVisits.Titles.Add("Статистика посещений");

                // Заполняем данными колонки
                foreach (DataRow row in dtVisits.Rows)
                {
                    DateTime visitDate = Convert.ToDateTime(row["VisitDate"]);
                    int visitCount = Convert.ToInt32(row["VisitCount"]);

                    DataPoint point = new DataPoint();
                    point.AxisLabel = visitDate.ToString("dd.MM");
                    point.YValues = new double[] { visitCount };
                    point.ToolTip = $"{visitDate.ToString("dd.MM.yyyy")}: {visitCount} посещений";

                    chartVisits.Series["Посещения"].Points.Add(point);
                }

                // Вычисляем и отображаем линию тренда
                CalculateTrendLine(dtVisits);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying visit chart: {ex.Message}");
            }
        }

        private void CalculateTrendLine(DataTable dtVisits)
        {
            if (dtVisits.Rows.Count < 2)
                return;

            // Вычисляем коэффициенты для линейного тренда (y = mx + b)
            double sumX = 0;
            double sumY = 0;
            double sumXY = 0;
            double sumX2 = 0;
            int n = dtVisits.Rows.Count;

            for (int i = 0; i < n; i++)
            {
                double x = i;
                double y = Convert.ToDouble(dtVisits.Rows[i]["VisitCount"]);

                sumX += x;
                sumY += y;
                sumXY += x * y;
                sumX2 += x * x;
            }

            double m = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            double b = (sumY - m * sumX) / n;

            // Добавляем точки тренда
            for (int i = 0; i < n; i++)
            {
                double trend = m * i + b;
                DateTime visitDate = Convert.ToDateTime(dtVisits.Rows[i]["VisitDate"]);

                DataPoint point = new DataPoint();
                point.AxisLabel = visitDate.ToString("dd.MM");
                point.YValues = new double[] { trend };

                chartVisits.Series["Тренд"].Points.Add(point);
            }
        }

        private void DisplayPieChart(DataTable dtClasses)
        {
            try
            {
                // Очищаем текущие данные
                chartClasses.Series.Clear();

                if (dtClasses.Rows.Count == 0)
                {
                    // Нет данных для отображения
                    chartClasses.Titles.Clear();
                    chartClasses.Titles.Add("Нет данных о классах за выбранный период");
                    return;
                }

                // Добавляем заголовок
                chartClasses.Titles.Clear();
                chartClasses.Titles.Add("Распределение по занятиям");

                // Настраиваем серию для круговой диаграммы
                Series series = new Series("Classes");
                series.ChartType = SeriesChartType.Pie;

                // Загружаем данные
                foreach (DataRow row in dtClasses.Rows)
                {
                    string className = row["Name"].ToString();
                    int visitCount = Convert.ToInt32(row["VisitCount"]);

                    DataPoint point = new DataPoint();
                    point.AxisLabel = className;
                    point.YValues = new double[] { visitCount };
                    point.LegendText = className;
                    point.Label = $"{className}\n{visitCount} ({visitCount * 100.0 / GetTotalClassVisits(dtClasses):0.0}%)";

                    series.Points.Add(point);
                }

                // Добавляем серию на график
                chartClasses.Series.Add(series);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying pie chart: {ex.Message}");
            }
        }

        private double GetTotalClassVisits(DataTable dtClasses)
        {
            double total = 0;
            foreach (DataRow row in dtClasses.Rows)
            {
                total += Convert.ToDouble(row["VisitCount"]);
            }
            return total;
        }

        private void cmbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadVisitStatistics();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                // Экспорт графика в изображение
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|BMP Image|*.bmp";
                saveDialog.Title = "Экспорт графика";
                saveDialog.FileName = $"visit_statistics_{DateTime.Now:yyyyMMdd}.png";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Определяем формат изображения по расширению
                    ChartImageFormat format = ChartImageFormat.Png;
                    string extension = System.IO.Path.GetExtension(saveDialog.FileName).ToLower();

                    switch (extension)
                    {
                        case ".jpg":
                        case ".jpeg":
                            format = ChartImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ChartImageFormat.Bmp;
                            break;
                    }

                    // Сохраняем график как изображение
                    chartVisits.SaveImage(saveDialog.FileName, format);

                    MessageBox.Show("График успешно экспортирован", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте графика: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}