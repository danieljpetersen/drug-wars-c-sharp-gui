using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class BundleVehicles
    {
        Vehicle None = new Vehicle(1, 0, "None", 0);
        Vehicle Rollerblades = new Vehicle(1, 20, "Rollerblades", 100);
        Vehicle Horse = new Vehicle(2, 20, "Horse", 10000);
        Vehicle GarbageTruck = new Vehicle(2, 500, "Dump Truck", 90000);
        Vehicle Van = new Vehicle(3, 360, "White Van", 100000);
        Vehicle Boat = new Vehicle(4, 120, "Boat", 100000);
        Vehicle SportsCar = new Vehicle(5, 150, "Sports Car", 450000);
        Vehicle PortalGun = new Vehicle(6, 160, "Portal Gun", 1000000);

        public Vehicle VehicleNone
        {
            get { return None; }
            set { None = value; }
        }

        public Vehicle VehicleRollerblades
        {
            get { return Rollerblades; }
            set { Rollerblades = value; }
        }
        public Vehicle VehicleHorse
        {
            get { return Horse; }
            set { Horse = value; }
        }
        public Vehicle VehicleVan
        {
            get { return Van; }
            set { Van = value; }
        }
        public Vehicle VehicleBoat
        {
            get { return Boat; }
            set { Boat = value; }
        }
        public Vehicle VehicleSportsCar
        {
            get { return SportsCar; }
            set { SportsCar = value; }
        }
        public Vehicle VehiclePortalGun
        {
            get { return PortalGun; }
            set { PortalGun = value; }
        }
        public Vehicle VehicleGarbage
        {
            get { return GarbageTruck; }
            set { GarbageTruck = value; }
        }
    }
}
