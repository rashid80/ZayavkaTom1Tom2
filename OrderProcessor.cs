public class OrderProcessor(OrderListReader orderListReader)
{

    public void ProcessOrder(string filePath)
    {
        var orders = orderListReader.ReadOrderListFile(filePath);

        var a = orders.First();
    }
}

