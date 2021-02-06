using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Drug
    {
        private int PriceOfDrug, PricePurchased;
        private int Type;
        public string TheName;
        private int Amount;
        public static Random random = new Random();
        

        public void generateNewPrice()
        {
            int RangeMin = 0, RangeMax = 100;

            if (Type == DrugType.ACID)
            {
                RangeMin = 1400;
                RangeMax = 3000;                  
            }
            else if (Type == DrugType.COCAINE)
            {
                RangeMin = 20000;
                RangeMax = 29000;
            }
            else if (Type == DrugType.CRACK)
            {
                RangeMin = 9000;
                RangeMax = 20000;
            }
            else if (Type == DrugType.CRYSTAL_METH)
            {
                RangeMin = 400;
                RangeMax = 800;
            }
            else if (Type == DrugType.ECSTASY)
            {
                RangeMin = 21;
                RangeMax = 92;
            }
            else if (Type == DrugType.HASH)
            {
                RangeMin = 600;
                RangeMax = 2800;
            }
            else if (Type == DrugType.HEROIN)
            {
                RangeMin = 1000;
                RangeMax = 8000;
            }
            else if (Type == DrugType.MESCALINE)
            {
                RangeMin = 10;
                RangeMax = 76;
            }
            else if (Type == DrugType.MORPHINE)
            {
                RangeMin = 2000;
                RangeMax = 4100;
            }
            else if (Type == DrugType.MUSHROOMS)
            {
                RangeMin = 300;
                RangeMax = 1300;
            }
            else if (Type == DrugType.WEED)
            {
                RangeMin = 98;
                RangeMax = 900;
            }

            Price = random.Next(RangeMin, RangeMax);
        }
        public void generateNewQuantity()
        {            
            int RangeMin = 0, RangeMax = 325;
            Amount = random.Next(RangeMin, RangeMax);
        }


        public int Price
        {
            get { return PriceOfDrug; }
            set { PriceOfDrug = value; }
        }

        public int PurchasePrice
        {
            get { return PricePurchased; }
            set { PricePurchased = value; }
        }

        public String Name
        {
            get { return TheName; }
            set { TheName = value; }
        }

        public int TypeOfDrug
        {
            get { return Type; }
            set { 
                    Type = value;
                    if (Type == 1)
                        TheName = "Acid";
                    else if (Type == 2)
                    {
                        TheName = "Cocaine";
                    }
                    else if (Type == 3)
                    {
                        TheName = "Crack";
                    }
                    else if (Type == 4)
                    {
                        TheName = "Crystal Meth";
                    }
                    else if (Type == 5)
                    {
                        TheName = "Ecstasy";
                    }
                    else if (Type == 6)
                    {
                        TheName = "Hash";
                    }
                    else if (Type == 7)
                    {
                        TheName = "Heroin";
                    }
                    else if (Type == 8)
                    {
                        TheName = "Mescaline";
                    }
                    else if (Type == 9)
                    {
                        TheName = "Morphine";
                    }
                    else if (Type == 10)
                    {
                        TheName = "Mushrooms";
                    }
                    else if (Type == 11)
                    {
                        TheName = "Weed";
                    }
                
                 }
        }

        public int Quantity
        {
            get { return Amount; }
            set { Amount = value; }
        }

        public Drug()
        {
            Price = 0;
            PricePurchased = 0;
            Type = 0;
            Amount = 0;
            generateNewPrice();
            TheName = "Default";
        }
    }
}
