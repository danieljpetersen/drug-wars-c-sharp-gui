using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Weapon
    {
        int Strenght, accuracy, Speed, Cost;
        string Named;

        public Weapon(int TheStrength, int Accurates, int NumberOfAttacks, string Title, int Moneys)
        {
            Strenght = TheStrength;
            accuracy = Accurates;
            Speed = NumberOfAttacks;
            Named = Title;
            Cost = Moneys;
        }

        public void setWeapon(int a, int b, int c, string WepName, int Priiice)
        {
            Strenght = a;
            accuracy = b;
            Speed = c;
            Named = WepName;
            Cost = Priiice;
        }

        public int Power
        {
            get { return Strenght; }
            set { Strenght = value; }
        }

        public int Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }

        public int NumberOfShotsFired
        {
            get { return Speed; }
            set { Speed = value; }
        }
        
        public string Name
        {
            get { return Named; }
            set { Named = value; }
        }

        public int Price
        {
            get { return Cost; }
            set { Cost = value; }
        }
    }
}
