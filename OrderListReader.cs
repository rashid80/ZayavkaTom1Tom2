using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OrderListReader(ExcelReader excelReader)
{

    public List<OrderItem> ReadOrderListFile(string filePath)
    {
        var excelData = excelReader.ReadExcelRange(filePath, startRow: 3, startColumn: 1, endColumn: 20, columnEmptyCheck: 1);

        return ConvertToOrderItems(excelData);
    }

    private List<OrderItem> ConvertToOrderItems(List<string[]> data)
    {
        return data.Select(row => new OrderItem(
            Field1: row[0],
            Field2: row[1],
            Field3: row[2],
            Field4: row[3],
            Field5: row[4],
            Field6: row[5],
            Field7: row[6],
            Field8: row[7],
            Field9: row[8],
            Field10: row[9],
            Field11: row[10],
            Field12: row[11],
            Field13: row[12],
            Field14: row[13],
            Field15: row[14],
            Field16: row[15],
            Field17: row[16],
            Field18: row[17],
            Field19: row[18],
            Field20: row[19]
        )).ToList();
    }

}

