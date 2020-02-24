using System;
using System.Collections.Generic;
using System.IO;

namespace InterviewDemo
{
    public class ShipmentCalculator
    {
        private const double AvailablePlaneVolume = 10000;
        private const double AvailableTruckVolume = 1500;
        public IEnumerable<Shipment> CreateShipments(string orderFilePath)
        {
            var orderedItems = GetOrderItems(orderFilePath);
            var itemsForTrucks = new List<ProductBox>();
            var itemsForPlanes = new List<ProductBox>();

            foreach(var item in orderedItems)
            {
                if(item.ProductCategory == ProductCategory.ExerciseEquipment || item.ProductCategory == ProductCategory.Housewares)
                {
                    itemsForTrucks.Add(item);
                }
                else
                {
                    itemsForPlanes.Add(item);
                }
            }

            var shipments = new List<Shipment>();
            shipments.AddRange(CreateTruckShipments(itemsForTrucks));
            shipments.AddRange(CreatePlaneShipments(itemsForPlanes));

            return shipments;
        }

        private IEnumerable<ProductBox> GetOrderItems(string orderFilePath)
        {
            var order = new List<ProductBox>();
            //read shipping box info from a file
            var orderFileLines = File.ReadAllLines(orderFilePath);
            //hydrate new objects - our ordering system generates a file
            // - each ordered box is on a separate line
            // - each line is pipe separated
            foreach (var line in orderFileLines)
            {
                var orderedItem = line.Split('|');
                order.Add(new ProductBox
                {
                    ProductId = int.Parse(orderedItem[0]),
                    Height = double.Parse(orderedItem[1]),
                    Width = double.Parse(orderedItem[2]),
                    Length = double.Parse(orderedItem[3]),
                    Weight = double.Parse(orderedItem[4]),
                    ProductDescription = orderedItem[5],
                    ProductCost = decimal.Parse(orderedItem[6]),
                    ProductCategory = Enum.Parse<ProductCategory>(orderedItem[7])
                });
            }
            //return the parsed order
            return order;
        }

        private IEnumerable<Shipment> CreatePlaneShipments(List<ProductBox> itemsForPlanes)
        {
            //naive packing algorithm
            var shipments = new List<Shipment>();
            var currentShipment = new Shipment();
            var availableVolume = AvailablePlaneVolume;
            foreach(var item in itemsForPlanes)
            {
                if(availableVolume >= item.Volume)
                {
                    currentShipment.Items.Add(item);
                    availableVolume -= item.Volume;
                }
                else
                {
                    shipments.Add(currentShipment);
                    currentShipment = new Shipment();
                    availableVolume = AvailablePlaneVolume;
                }
            }
            return shipments;
            
        }

        private IEnumerable<Shipment> CreateTruckShipments(List<ProductBox> itemsForTrucks)
        {
            //naive packing algorithm
            var shipments = new List<Shipment>();
            var currentShipment = new Shipment();
            var availableVolume = AvailableTruckVolume;
            foreach (var item in itemsForTrucks)
            {
                if (availableVolume >= item.Volume)
                {
                    currentShipment.Items.Add(item);
                    availableVolume -= item.Volume;
                }
                else
                {
                    shipments.Add(currentShipment);
                    currentShipment = new Shipment();
                    availableVolume = AvailableTruckVolume;
                }
            }
            return shipments;
        }
    }
}
