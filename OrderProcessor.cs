using ClosedXML.Excel;

public class OrderProcessor(
    OrderListReader orderListReader,
    ReportGenerator reportGenerator
    )
{

    public List<String> ProcessOrders(string filePath, String outputDirectory)
    {

        return orderListReader.ReadOrderListFile(filePath)
            .SelectMany(order => reportGenerator.GenerateReports(order, outputDirectory))
            .ToList();
    }
}

