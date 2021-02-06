using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Vehicle
    {
        int Speed, ItemCapacity, Price;
        string ItemName;

        public Vehicle(int SpeedValue, int CapacityValue, string NameValue, int PriceValue)
        {
            Speed = SpeedValue;
            ItemCapacity = CapacityValue;
            ItemName = NameValue;
            Price = PriceValue;
        }

        public void setVehicle(int SpeedValue, int CapacityValue, string NameValue, int PriceValue)
        {
            Speed = SpeedValue;
            ItemCapacity = CapacityValue;
            ItemName = NameValue;
            Price = PriceValue;
        }

        public int Speeds
        {
            get { return Speed; }
            set { Speed = value; }
        }

        public int Capacity
        {
            get { return ItemCapacity; }
            set { ItemCapacity = value; }
        }

        public int Prices
        {
            get { return Price; }
            set { Price = value; }
        }

        public string Name
        {
            get { return ItemName; }
            set { ItemName = value; }
        }
    }
}
