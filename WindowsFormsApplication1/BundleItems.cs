using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class BundleItems
    {
        public Item TrenchCoat = new Item(10, "Trench Coat", false, 30, 5000);
        public Item BackPack = new Item(10, "Backpack", false, 30, 5000);
        public Item CargoPants = new Item(10, "Cargo Pants", false, 30, 5000);
        public Item BodyArmor = new Item(50, "Body Armor", false, 0, 10000);
        public Item Helmet = new Item(50, "Safety Helmet", false, 0, 10000);
        public Item Kneepads = new Item(40, "Bitchin' Kneepads", false, 0, 10000);
        public Item SwatShield = new Item(50, "Swat Shield", false, 0, 10000);
        public Item Calculator = new Item(0, "Calculator", true, 0, 23);
    }
}
