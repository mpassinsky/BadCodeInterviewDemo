using System;
using System.IO;

namespace InterviewDemo
{
    class Program
    {
        private static string shipmentDirectory = "\\\\ShipmentServer\\shipments";
        static void Main(string[] args)
        {
            var orderFilePath = args[0];
            var shipments = new ShipmentCalculator().CreateShipments(orderFilePath);

            var shipmentSubdirectory = DateTime.Now.Date.ToShortDateString().Replace('/', '_');
            foreach (var shipment in shipments)
            {
                var shipmentPath = Path.Combine(shipmentDirectory, shipmentSubdirectory, "Wizbang_Order.ord");
                File.WriteAllText(shipmentPath, shipment.ToString());
            }
        }
    }
}
