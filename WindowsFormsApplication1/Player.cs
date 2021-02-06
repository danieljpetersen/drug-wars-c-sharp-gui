using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Player
    {
        private int CurrentLocation, CurrentMoney, CurrentDebt, CurrentTime, CurrentDay, InventoryMax, CurrentInventory, DebtPercent, CurrentBank, CurrentHealth, HealthMax, DebtPenalty;
        public BundleDrugs SellDrugs = new BundleDrugs();
        public Weapon PlayerWeapon = new Weapon(15, 8, 1, "Slingshot", 1000);
        public Vehicle PlayerVehicle = new Vehicle(1, 0, "None", 0);
        BundleItems PlayerItems = new BundleItems();

        public bool OwnTrench, OwnBackpack, OwnCargo, OwnBodyArmor, OwnHelmet, OwnKneepads, OwnShield, OwnCalculator;
        bool[] Owned = new bool[8];

        // Instance Constructor. 
        public Player()
        {
            CurrentLocation = 0;
            CurrentTime = 0;
            CurrentDay = 0;
            CurrentMoney = 1000000;
            CurrentBank = 0;
            CurrentDebt = 4400;
            InventoryMax = 100;
            CurrentInventory = 0;
            DebtPercent = 14;
            CurrentHealth = 100;
            HealthMax = 100;

            OwnTrench = false;
            OwnBackpack = false;
            OwnCargo = false;
            OwnBodyArmor = false;
            OwnHelmet = false;
            OwnKneepads = false;
            OwnShield = false;
            OwnCalculator = false;
            int counter = 0;
            while (counter < 8)
            {
                Owned[counter] = false;
                counter++;
            }
        }

        public int Health
        {
            get { return CurrentHealth; }
            set { CurrentHealth = value; }
        }

        public int MaxHealth
        {
            get { return HealthMax; }
            set { HealthMax = value; }
        }

        public int Location
        {
            get { return CurrentLocation; }
            set { CurrentLocation = value; }
        }

        public int Time
        {
            get { return CurrentTime; }
            set { CurrentTime = value; }
        }


        public int DebtPenaltyValue
        {
            get { return DebtPenalty; }
            set { DebtPenalty = value; }
        }

        public int Day
        {
            get { return CurrentDay; }
            set { CurrentDay = value; }
        }

        public int Money
        {
            get { return CurrentMoney; }
            set { CurrentMoney = value; }
        }

        public int Debt
        {
            get { return CurrentDebt; }
            set { CurrentDebt = value; }
        }

        public int DebtInterest
        {
            get { return DebtPercent; }
            set { DebtPercent = value; }
        }

        public int Bank
        {
            get { return CurrentBank; }
            set { CurrentBank = value; }
        }

        public int MaxInventory
        {
            get { return InventoryMax; }
            set { InventoryMax = value; }
        }

        public int Inventory
        {
            get { return CurrentInventory; }
            set { CurrentInventory = value; }
        }

        public void setWeapon(Weapon Wep)
        {
            PlayerWeapon.setWeapon(Wep.Power, Wep.Accuracy, Wep.NumberOfShotsFired, Wep.Name, Wep.Price);
        }

        public void setVehicle(Vehicle Vek)
        {
            InventoryMax -= PlayerVehicle.Capacity;
            PlayerVehicle.setVehicle(Vek.Speeds, Vek.Capacity, Vek.Name, Vek.Prices);
            InventoryMax += PlayerVehicle.Capacity;
        }

        public void addTrenchCoat()
        {
            if (OwnTrench == false)
            {
                OwnTrench = true;
                InventoryMax += PlayerItems.TrenchCoat.Capacity;
                MaxHealth += PlayerItems.TrenchCoat.Armor;
                Money -= PlayerItems.TrenchCoat.Price;
                Owned[0] = true;
            }
        }

        public void addBackPack()
        {
            if (OwnBackpack == false)
            {
                OwnBackpack = true;
                InventoryMax += PlayerItems.BackPack.Capacity;
                MaxHealth += PlayerItems.BackPack.Armor;
                Money -= PlayerItems.BackPack.Price;
                Owned[1] = true;
            }
        }

        public void addCargoPants()
        {
            if (OwnCargo == false)
            {
                OwnCargo = true;
                InventoryMax += PlayerItems.CargoPants.Capacity;
                MaxHealth += PlayerItems.CargoPants.Armor;
                Money -= PlayerItems.CargoPants.Price;
                Owned[2] = true;
            }
        }

        public void addBodyArmor()
        {
            if (OwnBodyArmor == false)
            {
                OwnBodyArmor = true;
                InventoryMax += PlayerItems.BodyArmor.Capacity;
                MaxHealth += PlayerItems.BodyArmor.Armor;
                Money -= PlayerItems.BodyArmor.Price;
                Owned[3] = true;
            }
        }

        public void addHelmet()
        {
            if (OwnHelmet == false)
            {
                OwnBackpack = true;
                InventoryMax += PlayerItems.Helmet.Capacity;
                MaxHealth += PlayerItems.Helmet.Armor;
                Money -= PlayerItems.Helmet.Price;
                Owned[4] = true;
            }
        }

        public void addKneepads()
        {
            if (OwnKneepads == false)
            {
                OwnKneepads = true;
                InventoryMax += PlayerItems.Kneepads.Capacity;
                MaxHealth += PlayerItems.Kneepads.Armor;
                Money -= PlayerItems.Kneepads.Price;
                Owned[5] = true;
            }
        }

        public void addSwatShield()
        {
            if (OwnShield == false)
            {
                OwnShield = true;
                InventoryMax += PlayerItems.SwatShield.Capacity;
                MaxHealth += PlayerItems.SwatShield.Armor;
                Money -= PlayerItems.SwatShield.Price;
                Owned[6] = true;
            }
        }

        public void addCalculator()
        {
            if (OwnCalculator == false)
            {
                OwnCalculator = true;
                InventoryMax += PlayerItems.Calculator.Capacity;
                MaxHealth += PlayerItems.Calculator.Armor;
                Money -= PlayerItems.Calculator.Price;
                Owned[7] = true;
            }
        }

        public bool getOwned(int Index)
        {
            return Owned[Index];
        }
    }
}
