using ClosedXML.Excel;

public class ReportGenerator
{

    private static readonly string TemplatePath1 = "Templates/template1.xlsx";
    private static readonly string TemplatePath2 = "Templates/template2.xlsx";

    public List<String> GenerateReports(OrderItem orderItem, String outputDirectory)
    {

        return [
            GenerateTom1(orderItem, outputDirectory),
            GenerateTom2(orderItem, outputDirectory),
            ];
    }

    private string GetFullTemplatePath(string relativePath)
    {
        // Получаем путь к папке с exe-файлом
        string exeDir = AppContext.BaseDirectory;
        string fullPath = Path.Combine(exeDir, relativePath);

        if (!File.Exists(fullPath))
            throw new FileNotFoundException($"Шаблон не найден: {fullPath}");

        return fullPath;
    }


    private String TrimTimeForDateTimeString(String dateTime) =>
        dateTime.Split(' ')[0];


    private String GenerateTom1(OrderItem orderItem, String outputDirectory)
    {

        var outputPath = Path.Combine(outputDirectory, $"{orderItem.Field1}.xlsx");

        var variables = new Dictionary<string, string>
        {
                { "#VALUE1#", orderItem.Field1 },
                { "#VALUE2#", orderItem.Field2 },
                { "#VALUE3#", TrimTimeForDateTimeString(orderItem.Field3) },
                { "#VALUE4#", orderItem.Field4 },
                { "#VALUE5#", orderItem.Field5 },
                { "#VALUE6#", orderItem.Field6 },
                { "#VALUE7#", orderItem.Field7 },
                { "#VALUE8#", TrimTimeForDateTimeString(orderItem.Field8) },
                { "#VALUE9#", orderItem.Field9 },
                { "#VALUE10#", orderItem.Field10 },

        };

        return GenerateReport(GetFullTemplatePath(TemplatePath1), outputPath, variables);
    }

    private String GenerateTom2(OrderItem orderItem, String outputDirectory)
    {

        var outputPath = Path.Combine(outputDirectory, $"{orderItem.Field11}.xlsx");

        var variables = new Dictionary<string, string>
        {
                { "#VALUE11#", orderItem.Field11 },
                { "#VALUE12#", orderItem.Field12 },
                { "#VALUE13#", TrimTimeForDateTimeString(orderItem.Field13) },
                { "#VALUE14#", orderItem.Field14 },
                { "#VALUE15#", orderItem.Field15 },
                { "#VALUE16#", orderItem.Field16 },
                { "#VALUE17#", orderItem.Field17 },
                { "#VALUE18#", TrimTimeForDateTimeString(orderItem.Field18) },
                { "#VALUE19#", orderItem.Field19 },
                { "#VALUE20#", orderItem.Field20 },

        };

        return GenerateReport(GetFullTemplatePath(TemplatePath2), outputPath, variables);
    }

    private String GenerateReport(String templatePath, String outputPath, Dictionary<String, String> variables)
    {
        using (var workbook = new XLWorkbook(templatePath))
        {
            var worksheet = workbook.Worksheet(1); // Первый лист

            // Проверяем все используемые ячейки
            foreach (var cell in worksheet.CellsUsed())
            {
                string cellValue = cell.Value.ToString();

                // Если в ячейке есть хотя бы один плейсхолдер из словаря
                foreach (var placeholder in variables.Keys)
                {
                    if (cellValue.Contains(placeholder))
                    {
                        cellValue = cellValue.Replace(placeholder, variables[placeholder]);
                    }
                }

                // Обновляем значение ячейки
                cell.Value = cellValue;
            }

            // Сохраняем результат
            workbook.SaveAs(outputPath);

            return outputPath;
        }
    }
}

