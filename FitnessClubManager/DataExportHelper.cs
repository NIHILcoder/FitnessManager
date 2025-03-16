using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Npgsql.Internal;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Xml.Linq;

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

        /// <summary>
        /// Экспорт данных из DataTable в Excel файл (XLSX)
        /// </summary>
        /// <param name="dt">DataTable с данными</param>
        /// <param name="title">Заголовок (название отчета)</param>
        /// <returns>true, если экспорт выполнен успешно</returns>
        public static bool ExportToExcel(DataTable dt, string title)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel файлы (*.xlsx)|*.xlsx";
                saveDialog.Title = "Экспорт в Excel";
                saveDialog.FileName = $"{title}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Устанавливаем лицензию EPPlus для некоммерческого использования
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    using (ExcelPackage package = new ExcelPackage())
                    {
                        // Создаем лист
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(title);

                        // Добавляем заголовок отчета
                        worksheet.Cells[1, 1].Value = title;
                        worksheet.Cells[1, 1, 1, dt.Columns.Count].Merge = true;
                        worksheet.Cells[1, 1].Style.Font.Bold = true;
                        worksheet.Cells[1, 1].Style.Font.Size = 14;
                        worksheet.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        // Добавляем дату формирования
                        worksheet.Cells[2, 1].Value = $"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm:ss}";
                        worksheet.Cells[2, 1, 2, dt.Columns.Count].Merge = true;
                        worksheet.Cells[2, 1].Style.Font.Italic = true;
                        worksheet.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                        // Добавляем заголовки столбцов
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            worksheet.Cells[4, i + 1].Value = dt.Columns[i].ColumnName;
                            worksheet.Cells[4, i + 1].Style.Font.Bold = true;
                            worksheet.Cells[4, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[4, i + 1].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                            worksheet.Cells[4, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        }

                        // Добавляем данные
                        for (int r = 0; r < dt.Rows.Count; r++)
                        {
                            for (int c = 0; c < dt.Columns.Count; c++)
                            {
                                worksheet.Cells[r + 5, c + 1].Value = dt.Rows[r][c].ToString();
                                worksheet.Cells[r + 5, c + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }
                        }

                        // Добавляем итоговую информацию
                        worksheet.Cells[dt.Rows.Count + 6, 1].Value = $"Всего записей: {dt.Rows.Count}";
                        worksheet.Cells[dt.Rows.Count + 6, 1, dt.Rows.Count + 6, dt.Columns.Count].Merge = true;
                        worksheet.Cells[dt.Rows.Count + 6, 1].Style.Font.Bold = true;

                        // Автоподбор ширины столбцов
                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        // Сохраняем файл
                        package.SaveAs(new FileInfo(saveDialog.FileName));
                    }

                    MessageBox.Show($"Данные успешно экспортированы в файл: {saveDialog.FileName}",
                        "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте данных в Excel: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        /// <summary>
        /// Экспорт данных из DataTable в PDF файл
        /// </summary>
        /// <param name="dt">DataTable с данными</param>
        /// <param name="title">Заголовок (название отчета)</param>
        /// <returns>true, если экспорт выполнен успешно</returns>
        public static bool ExportToPdf(DataTable dt, string title)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF файлы (*.pdf)|*.pdf";
                saveDialog.Title = "Экспорт в PDF";
                saveDialog.FileName = $"{title}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Создаем документ PDF
                    using (FileStream fs = new FileStream(saveDialog.FileName, FileMode.Create))
                    {
                        // Установка размера страницы А4 и поля
                        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 30, 30);
                        iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, fs);

                        // Открываем документ для редактирования
                        document.Open();

                        // Добавляем заголовок отчета
                        iTextSharp.text.Font titleFont = iTextSharp.text.FontFactory.GetFont(
                            iTextSharp.text.FontFactory.HELVETICA_BOLD, 16, iTextSharp.text.BaseColor.DARK_GRAY);
                        iTextSharp.text.Paragraph titleParagraph = new iTextSharp.text.Paragraph(title, titleFont);
                        titleParagraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                        document.Add(titleParagraph);

                        // Добавляем дату формирования
                        iTextSharp.text.Font dateFont = iTextSharp.text.FontFactory.GetFont(
                            iTextSharp.text.FontFactory.HELVETICA_OBLIQUE, 10, iTextSharp.text.BaseColor.DARK_GRAY);
                        iTextSharp.text.Paragraph dateParagraph = new iTextSharp.text.Paragraph(
                            $"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm:ss}", dateFont);
                        dateParagraph.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        document.Add(dateParagraph);

                        // Добавляем пустую строку
                        document.Add(new iTextSharp.text.Paragraph(" "));

                        // Создаем таблицу
                        iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(dt.Columns.Count);
                        table.WidthPercentage = 100;

                        // Устанавливаем относительную ширину столбцов
                        float[] widths = new float[dt.Columns.Count];
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            widths[i] = 1f;
                        }
                        table.SetWidths(widths);

                        // Добавляем заголовки столбцов
                        iTextSharp.text.Font headerFont = iTextSharp.text.FontFactory.GetFont(
                            iTextSharp.text.FontFactory.HELVETICA_BOLD, 10, iTextSharp.text.BaseColor.WHITE);
                        iTextSharp.text.BaseColor headerBackColor = new iTextSharp.text.BaseColor(0, 122, 204); // Синий цвет

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(
                                new iTextSharp.text.Phrase(dt.Columns[i].ColumnName, headerFont));
                            cell.BackgroundColor = headerBackColor;
                            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.Padding = 5;
                            table.AddCell(cell);
                        }

                        // Добавляем данные
                        iTextSharp.text.Font dataFont = iTextSharp.text.FontFactory.GetFont(
                            iTextSharp.text.FontFactory.HELVETICA, 10);
                        for (int r = 0; r < dt.Rows.Count; r++)
                        {
                            // Чередуем фон строк для удобства чтения
                            iTextSharp.text.BaseColor rowColor = (r % 2 == 0) ?
                                new iTextSharp.text.BaseColor(240, 240, 240) :
                                iTextSharp.text.BaseColor.WHITE;

                            for (int c = 0; c < dt.Columns.Count; c++)
                            {
                                iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(
                                    new iTextSharp.text.Phrase(dt.Rows[r][c].ToString(), dataFont));
                                cell.BackgroundColor = rowColor;
                                cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                                cell.Padding = 5;
                                table.AddCell(cell);
                            }
                        }

                        // Добавляем таблицу в документ
                        document.Add(table);

                        // Добавляем итоговую информацию
                        document.Add(new iTextSharp.text.Paragraph(" "));
                        iTextSharp.text.Font summaryFont = iTextSharp.text.FontFactory.GetFont(
                            iTextSharp.text.FontFactory.HELVETICA_BOLD, 10);
                        iTextSharp.text.Paragraph summaryParagraph = new iTextSharp.text.Paragraph(
                            $"Всего записей: {dt.Rows.Count}", summaryFont);
                        summaryParagraph.Alignment = iTextSharp.text.Element.ALIGN_LEFT;
                        document.Add(summaryParagraph);

                        // Добавляем информацию о системе
                        iTextSharp.text.Font footerFont = iTextSharp.text.FontFactory.GetFont(
                            iTextSharp.text.FontFactory.HELVETICA_OBLIQUE, 8, iTextSharp.text.BaseColor.GRAY);
                        iTextSharp.text.Paragraph footerParagraph = new iTextSharp.text.Paragraph(
                            $"Отчет сгенерирован системой \"ActiveLife\" • {DateTime.Now:yyyy-MM-dd}", footerFont);
                        footerParagraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                        document.Add(footerParagraph);

                        // Закрываем документ
                        document.Close();
                    }

                    MessageBox.Show($"Данные успешно экспортированы в файл: {saveDialog.FileName}",
                        "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте данных в PDF: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}