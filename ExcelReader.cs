using ClosedXML.Excel;

public class ExcelReader
{
    public List<string[]> ReadExcelRange(string filePath, int startRow, int startColumn, int endColumn, int columnEmptyCheck)
    {
        var data = new List<string[]>();

        // Открываем файл
        using (var workbook = new XLWorkbook(filePath))
        {
            // Получаем первый лист
            var worksheet = workbook.Worksheet(1);

            // Определяем последнюю заполненную строку
            int lastRow = worksheet.LastRowUsed().RowNumber();

            // Вычисляем количество столбцов
            int columnCount = endColumn - startColumn + 1;

            // Читаем строки, начиная с startRow
            for (int row = startRow; row <= lastRow; row++)
            {
  
                var columnValue = worksheet.Cell(row, columnEmptyCheck).GetString();

                // Если определенная колонка пустая, пропускаем строку
                if (string.IsNullOrWhiteSpace(columnValue))
                {
                    continue;
                }

                // Создаем фиксированный массив для хранения данных строки
                var rowData = new string[columnCount];

                // Читаем данные из указанного диапазона столбцов
                for (int col = startColumn; col <= endColumn; col++)
                {
                    rowData[col - startColumn] = worksheet.Cell(row, col).GetString();
                }

                // Добавляем строку в результат
                data.Add(rowData);
            }
        }

        return data;
    }
}