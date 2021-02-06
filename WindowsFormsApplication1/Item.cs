using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Item
    {
        public int Armor { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        bool Calculator;

        public Item(int StrengthOfArmor, string ItemName, bool Machine, int Carry, int PriceValue)
        {
            Calculator = Machine;
            Name = ItemName;
            Armor = StrengthOfArmor;
            Capacity = Carry;
            Price = PriceValue;
        }
    }
}
