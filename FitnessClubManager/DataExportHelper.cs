using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FitnessManager
{
    public static class DataExportHelper
    {
        /// <summary>
        /// Экспорт данных из DataTable в текстовый файл (TXT)
        /// </summary>
        /// <param name="dt">DataTable с данными</param>
        /// <param name="title">Заголовок (название отчета)</param>
        /// <returns>true, если экспорт выполнен успешно</returns>
        public static bool ExportToTxt(DataTable dt, string title)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                saveDialog.Title = "Экспорт в текстовый файл";
                saveDialog.FileName = $"{title}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();

                    // Добавляем заголовок
                    sb.AppendLine(title);
                    sb.AppendLine(new string('-', title.Length));
                    sb.AppendLine($"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
                    sb.AppendLine();

                    // Добавляем заголовки столбцов
                    string[] headers = new string[dt.Columns.Count];
                    int[] colWidths = new int[dt.Columns.Count];

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        headers[i] = dt.Columns[i].ColumnName;
                        // Устанавливаем ширину столбца не менее длины заголовка
                        colWidths[i] = Math.Max(dt.Columns[i].ColumnName.Length, 10);
                    }

                    // Вычисляем максимальную ширину каждого столбца на основе данных
                    foreach (DataRow row in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            string cellValue = row[i]?.ToString() ?? "";
                            colWidths[i] = Math.Max(colWidths[i], cellValue.Length);
                        }
                    }

                    // Формируем строку с заголовками
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sb.Append(headers[i].PadRight(colWidths[i] + 2));
                    }
                    sb.AppendLine();

                    // Добавляем разделитель
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sb.Append(new string('-', colWidths[i]) + "  ");
                    }
                    sb.AppendLine();

                    // Добавляем данные
                    foreach (DataRow row in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            string cellValue = row[i]?.ToString() ?? "";
                            sb.Append(cellValue.PadRight(colWidths[i] + 2));
                        }
                        sb.AppendLine();
                    }

                    // Добавляем итоговую информацию
                    sb.AppendLine();
                    sb.AppendLine($"Всего записей: {dt.Rows.Count}");

                    // Записываем в файл
                    File.WriteAllText(saveDialog.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show($"Данные успешно экспортированы в файл: {saveDialog.FileName}",
                        "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}