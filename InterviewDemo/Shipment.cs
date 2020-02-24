using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewDemo
{
    public class Shipment
    {
        public string ShipmentMethod { get; set; }
        public List<ProductBox> Items { get; set; }

        public override string ToString()
        {
            var lines = Items.Select(i => i.ToString() + Environment.NewLine);
            return String.Concat(lines);
        }
    }
}