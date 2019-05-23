using System.Collections.Generic;

namespace InterviewDemo
{
    public class ShipmentCalculator
    {
        private const double AvailablePlaneVolume = 10000;
        private const double AvailalbeTruckVolume = 1500;
        public IEnumerable<Shipment> CreateShipments(string orderFilePath)
        {
            var orderedItems = GetOrderItems(orderFilePath);
            var itemsForTrucks = new List<ShippingBox>();
            var itemsForPlanes = new List<ShippingBox>();

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

        private IEnumerable<ShippingBox> GetOrderItems(string orderFilePath)
        {
            //read shipping box info from a file
            //hydrate new objects
            //return them
            return new List<ShippingBox>();
        }

        private IEnumerable<Shipment> CreatePlaneShipments(List<ShippingBox> itemsForPlanes)
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

        private IEnumerable<Shipment> CreateTruckShipments(List<ShippingBox> itemsForTrucks)
        {
            //naive packing algorithm
            var shipments = new List<Shipment>();
            var currentShipment = new Shipment();
            var availableVolume = AvailalbeTruckVolume;
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
                    availableVolume = AvailalbeTruckVolume;
                }
            }
            return shipments;
        }
    }
}
