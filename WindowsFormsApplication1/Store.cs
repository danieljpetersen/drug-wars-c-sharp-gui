using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Store : Form
    {
        BundleOfGuns Guns = new BundleOfGuns();
        BundleVehicles Vehicles = new BundleVehicles();
        BundleItems ItemItem = new BundleItems();
        Player Stupid;
        Label OrigMoneyLabel, OriglWeaponLabel, OrigVehicleLabel, OrigItem, OrigHealth;
        bool BuyingVehicles, BuyingWeapons, BuyingMisc;

        public Store(ref Player aPlayerObject, ref Label OriginalMoneyLabel, ref Label OriginalWeaponLabel, ref Label OriginalVehicleLabel, ref Label OriginalItemCount, ref Label OriginalHealth)
        {
            InitializeComponent();
            populateStoreListWeapons();

            Stupid = aPlayerObject;

            OrigMoneyLabel = OriginalMoneyLabel;
            OriglWeaponLabel = OriginalWeaponLabel;
            OrigVehicleLabel = OriginalVehicleLabel;
            OrigItem = OriginalItemCount;
            OrigHealth = OriginalHealth;

            label2.Text = OriginalMoneyLabel.Text;
            label5.Text = OriginalWeaponLabel.Text;
            label6.Text = OriginalVehicleLabel.Text;

            BuyingWeapons = true;
            BuyingVehicles = false;
            BuyingMisc = false;
        }

        private void StoreListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void populateStoreListWeapons()
        {
            StoreListView.Items.Clear();
            StoreListView.Columns.Clear();

            StoreListView.Columns.Add("Items To Buy", 105, HorizontalAlignment.Left);
            StoreListView.Columns.Add("Power", 44, HorizontalAlignment.Right);
            StoreListView.Columns.Add("Accuracy", 60, HorizontalAlignment.Right);
            StoreListView.Columns.Add("Shots Fired", 66, HorizontalAlignment.Right);
            StoreListView.Columns.Add("Price", 62, HorizontalAlignment.Right);

            //i know I could probably reuse the same string instead of making 11 different ones, but fuck you.
            string[] row1 = { Guns.WeaponButterKnife.Power.ToString(), Guns.WeaponButterKnife.Accuracy.ToString(), Guns.WeaponButterKnife.NumberOfShotsFired.ToString(), formatStringToCurrency(Guns.WeaponButterKnife.Price) };
            StoreListView.Items.Add(Guns.WeaponButterKnife.Name).SubItems.AddRange(row1);

            string[] row2 = { Guns.WeaponSlingShot.Power.ToString(), Guns.WeaponSlingShot.Accuracy.ToString(), Guns.WeaponSlingShot.NumberOfShotsFired.ToString(), formatStringToCurrency(Guns.WeaponSlingShot.Price) };
            StoreListView.Items.Add(Guns.WeaponSlingShot.Name).SubItems.AddRange(row2);

            string[] row3 = { Guns.WeaponHuntingKnife.Power.ToString(), Guns.WeaponHuntingKnife.Accuracy.ToString(), Guns.WeaponHuntingKnife.NumberOfShotsFired.ToString(), formatStringToCurrency(Guns.WeaponHuntingKnife.Price) };
            StoreListView.Items.Add(Guns.WeaponHuntingKnife.Name).SubItems.AddRange(row3);

            string[] row4 = { Guns.WeaponHandGun.Power.ToString(), Guns.WeaponHandGun.Accuracy.ToString(), Guns.WeaponHandGun.NumberOfShotsFired.ToString(), formatStringToCurrency(Guns.WeaponHandGun.Price) };
            StoreListView.Items.Add(Guns.WeaponHandGun.Name).SubItems.AddRange(row4);

            string[] row5 = { Guns.WeaponSMG.Power.ToString(), Guns.WeaponSMG.Accuracy.ToString(), Guns.WeaponSMG.NumberOfShotsFired.ToString(), formatStringToCurrency(Guns.WeaponSMG.Price) };
            StoreListView.Items.Add(Guns.WeaponSMG.Name).SubItems.AddRange(row5);

            string[] row6 = { Guns.WeaponGrenade.Power.ToString(), Guns.WeaponGrenade.Accuracy.ToString(), Guns.WeaponGrenade.NumberOfShotsFired.ToString(), formatStringToCurrency(Guns.WeaponGrenade.Price) };
            StoreListView.Items.Add(Guns.WeaponGrenade.Name).SubItems.AddRange(row6);

            string[] row7 = { Guns.WeaponBazooka.Power.ToString(), Guns.WeaponBazooka.Accuracy.ToString(), Guns.WeaponBazooka.NumberOfShotsFired.ToString(), formatStringToCurrency(Guns.WeaponBazooka.Price) };
            StoreListView.Items.Add(Guns.WeaponBazooka.Name).SubItems.AddRange(row7);

            string[] row8 = { Guns.WeaponSniper.Power.ToString(), Guns.WeaponSniper.Accuracy.ToString(), Guns.WeaponSniper.NumberOfShotsFired.ToString(), formatStringToCurrency(Guns.WeaponSniper.Price) };
            StoreListView.Items.Add(Guns.WeaponSniper.Name).SubItems.AddRange(row8);

            string[] row9 = { Guns.WeaponPlasmaRifle.Power.ToString(), Guns.WeaponPlasmaRifle.Accuracy.ToString(), Guns.WeaponPlasmaRifle.NumberOfShotsFired.ToString(), formatStringToCurrency(Guns.WeaponPlasmaRifle.Price) };
            StoreListView.Items.Add(Guns.WeaponPlasmaRifle.Name).SubItems.AddRange(row9);
        }

        private void populateStoreListVehicles()
        {

            StoreListView.Items.Clear();
            StoreListView.Columns.Clear();

            StoreListView.Columns.Add("Items To Buy", 105, HorizontalAlignment.Left);
            StoreListView.Columns.Add("Speed", 44, HorizontalAlignment.Right);
            StoreListView.Columns.Add("Capacity", 60, HorizontalAlignment.Right);
            StoreListView.Columns.Add("Price", 66, HorizontalAlignment.Right);

            string[] row1 = { Vehicles.VehicleRollerblades.Speeds.ToString(), Vehicles.VehicleRollerblades.Capacity.ToString(), formatStringToCurrency(Vehicles.VehicleRollerblades.Prices) };
            StoreListView.Items.Add(Vehicles.VehicleRollerblades.Name).SubItems.AddRange(row1);

            string[] row2 = { Vehicles.VehicleHorse.Speeds.ToString(), Vehicles.VehicleHorse.Capacity.ToString(), formatStringToCurrency(Vehicles.VehicleHorse.Prices) };
            StoreListView.Items.Add(Vehicles.VehicleHorse.Name).SubItems.AddRange(row2);

            string[] row3 = { Vehicles.VehicleGarbage.Speeds.ToString(), Vehicles.VehicleGarbage.Capacity.ToString(), formatStringToCurrency(Vehicles.VehicleGarbage.Prices) };
            StoreListView.Items.Add(Vehicles.VehicleGarbage.Name).SubItems.AddRange(row3);

            string[] row4 = { Vehicles.VehicleVan.Speeds.ToString(), Vehicles.VehicleVan.Capacity.ToString(), formatStringToCurrency(Vehicles.VehicleVan.Prices) };
            StoreListView.Items.Add(Vehicles.VehicleVan.Name).SubItems.AddRange(row4);

            string[] row5 = { Vehicles.VehicleBoat.Speeds.ToString(), Vehicles.VehicleBoat.Capacity.ToString(), formatStringToCurrency(Vehicles.VehicleBoat.Prices) };
            StoreListView.Items.Add(Vehicles.VehicleBoat.Name).SubItems.AddRange(row5);

            string[] row6 = { Vehicles.VehicleSportsCar.Speeds.ToString(), Vehicles.VehicleSportsCar.Capacity.ToString(), formatStringToCurrency(Vehicles.VehicleSportsCar.Prices) };
            StoreListView.Items.Add(Vehicles.VehicleSportsCar.Name).SubItems.AddRange(row6);

            string[] row7 = { Vehicles.VehiclePortalGun.Speeds.ToString(), Vehicles.VehiclePortalGun.Capacity.ToString(), formatStringToCurrency(Vehicles.VehiclePortalGun.Prices) };
            StoreListView.Items.Add(Vehicles.VehiclePortalGun.Name).SubItems.AddRange(row7);
        }

        private void populateStoreListMisc()
        {
            StoreListView.Items.Clear();
            StoreListView.Columns.Clear();

            StoreListView.Columns.Add("Items To Buy", 105, HorizontalAlignment.Left);
            StoreListView.Columns.Add("Armor", 44, HorizontalAlignment.Right);
            StoreListView.Columns.Add("Capacity", 60, HorizontalAlignment.Right);
            StoreListView.Columns.Add("Price", 66, HorizontalAlignment.Right);
            StoreListView.Columns.Add("Owned?", 66, HorizontalAlignment.Right);

            string[] row1 = { ItemItem.TrenchCoat.Armor.ToString(), ItemItem.TrenchCoat.Capacity.ToString(), formatStringToCurrency(ItemItem.TrenchCoat.Price), Stupid.getOwned(0).ToString() };
            StoreListView.Items.Add(ItemItem.TrenchCoat.Name).SubItems.AddRange(row1);

            string[] row2 = { ItemItem.BackPack.Armor.ToString(), ItemItem.BackPack.Capacity.ToString(), formatStringToCurrency(ItemItem.BackPack.Price), Stupid.getOwned(1).ToString() };
            StoreListView.Items.Add(ItemItem.BackPack.Name).SubItems.AddRange(row2);

            string[] row3 = { ItemItem.CargoPants.Armor.ToString(), ItemItem.CargoPants.Capacity.ToString(), formatStringToCurrency(ItemItem.CargoPants.Price), Stupid.getOwned(2).ToString() };
            StoreListView.Items.Add(ItemItem.CargoPants.Name).SubItems.AddRange(row3);

            string[] row4 = { ItemItem.BodyArmor.Armor.ToString(), ItemItem.BodyArmor.Capacity.ToString(), formatStringToCurrency(ItemItem.BodyArmor.Price), Stupid.getOwned(3).ToString() };
            StoreListView.Items.Add(ItemItem.BodyArmor.Name).SubItems.AddRange(row4);

            string[] row5 = { ItemItem.Helmet.Armor.ToString(), ItemItem.Helmet.Capacity.ToString(), formatStringToCurrency(ItemItem.Helmet.Price), Stupid.getOwned(5).ToString() };
            StoreListView.Items.Add(ItemItem.Helmet.Name).SubItems.AddRange(row5);

            string[] row6 = { ItemItem.Kneepads.Armor.ToString(), ItemItem.Kneepads.Capacity.ToString(), formatStringToCurrency(ItemItem.Kneepads.Price), Stupid.getOwned(5).ToString() };
            StoreListView.Items.Add(ItemItem.Kneepads.Name).SubItems.AddRange(row6);

            string[] row7 = { ItemItem.SwatShield.Armor.ToString(), ItemItem.SwatShield.Capacity.ToString(), formatStringToCurrency(ItemItem.SwatShield.Price), Stupid.getOwned(6).ToString() };
            StoreListView.Items.Add(ItemItem.SwatShield.Name).SubItems.AddRange(row7);

            string[] row8 = { ItemItem.Calculator.Armor.ToString(), ItemItem.Calculator.Capacity.ToString(), formatStringToCurrency(ItemItem.Calculator.Price), Stupid.getOwned(7).ToString() };
            StoreListView.Items.Add(ItemItem.Calculator.Name).SubItems.AddRange(row8);
        }

        public string formatStringToCurrency(int NumberToStringFormat)
        {
            string NewStringValue = NumberToStringFormat.ToString("#,##0");
            NewStringValue = "$" + NewStringValue;
            return NewStringValue;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string SelectedItem = "rawr";
            int SelectedItemMisc = 0;
            for (int i = 0; i < StoreListView.Items.Count; i++)
            {
                // is i the index of the row I selected?
                if (StoreListView.Items[i].Selected == true)
                {
                    SelectedItem = StoreListView.Items[i].Text;
                    SelectedItemMisc = i;
                    break;
                }
            }

            if (BuyingWeapons == true)
            {
                if (SelectedItem == Guns.WeaponButterKnife.Name)
                {
                    if (Guns.WeaponButterKnife.Price <= Stupid.Money)
                    {
                        if (Stupid.PlayerWeapon.Name != Guns.WeaponButterKnife.Name)
                        {
                            Stupid.Money -= Guns.WeaponButterKnife.Price;
                            Stupid.Money += Stupid.PlayerWeapon.Price;
                            Stupid.PlayerWeapon.setWeapon(Guns.WeaponButterKnife.Power, Guns.WeaponButterKnife.Accuracy, Guns.WeaponButterKnife.NumberOfShotsFired, Guns.WeaponButterKnife.Name, Guns.WeaponButterKnife.Price);

                            label2.Text = formatStringToCurrency(Stupid.Money);
                            OrigMoneyLabel.Text = label2.Text;

                            label5.Text = Guns.WeaponButterKnife.Name;
                            OriglWeaponLabel.Text = label5.Text;
                        }
                    }
                }

                if (SelectedItem == Guns.WeaponSlingShot.Name)
                {
                    if (Guns.WeaponSlingShot.Price <= Stupid.Money)
                    {
                        if (Stupid.PlayerWeapon.Name != Guns.WeaponSlingShot.Name)
                        {
                            Stupid.Money -= Guns.WeaponSlingShot.Price;
                            Stupid.Money += Stupid.PlayerWeapon.Price;
                            Stupid.PlayerWeapon.setWeapon(Guns.WeaponSlingShot.Power, Guns.WeaponSlingShot.Accuracy, Guns.WeaponSlingShot.NumberOfShotsFired, Guns.WeaponSlingShot.Name, Guns.WeaponSlingShot.Price);

                            label2.Text = formatStringToCurrency(Stupid.Money);
                            OrigMoneyLabel.Text = label2.Text;

                            label5.Text = Guns.WeaponSlingShot.Name;
                            OriglWeaponLabel.Text = label5.Text;
                        }
                    }
                }

                if (SelectedItem == Guns.WeaponHuntingKnife.Name)
                {
                    if (Guns.WeaponHuntingKnife.Price <= Stupid.Money)
                    {
                        if (Stupid.PlayerWeapon.Name != Guns.WeaponHuntingKnife.Name)
                        {
                            Stupid.Money += Stupid.PlayerWeapon.Price;
                            Stupid.Money -= Guns.WeaponHuntingKnife.Price;
                            Stupid.PlayerWeapon.setWeapon(Guns.WeaponHuntingKnife.Power, Guns.WeaponHuntingKnife.Accuracy, Guns.WeaponHuntingKnife.NumberOfShotsFired, Guns.WeaponHuntingKnife.Name, Guns.WeaponHuntingKnife.Price);

                            label2.Text = formatStringToCurrency(Stupid.Money);
                            OrigMoneyLabel.Text = label2.Text;

                            label5.Text = Guns.WeaponHuntingKnife.Name;
                            OriglWeaponLabel.Text = label5.Text;
                        }
                    }
                }

                if (SelectedItem == Guns.WeaponHandGun.Name)
                {
                    if (Guns.WeaponHandGun.Price <= Stupid.Money)
                    {
                        if (Stupid.PlayerWeapon.Name != Guns.WeaponHandGun.Name)
                        {
                            Stupid.Money += Stupid.PlayerWeapon.Price;
                            Stupid.Money -= Guns.WeaponHandGun.Price;
                            Stupid.PlayerWeapon.setWeapon(Guns.WeaponHandGun.Power, Guns.WeaponHandGun.Accuracy, Guns.WeaponHandGun.NumberOfShotsFired, Guns.WeaponHandGun.Name, Guns.WeaponHandGun.Price);

                            label2.Text = formatStringToCurrency(Stupid.Money);
                            OrigMoneyLabel.Text = label2.Text;

                            label5.Text = Guns.WeaponHandGun.Name;
                            OriglWeaponLabel.Text = label5.Text;
                        }
                    }
                }

                if (SelectedItem == Guns.WeaponSMG.Name)
                {
                    if (Guns.WeaponSMG.Price <= Stupid.Money)
                    {
                        if (Stupid.PlayerWeapon.Name != Guns.WeaponSMG.Name)
                        {
                            Stupid.Money += Stupid.PlayerWeapon.Price;
                            Stupid.Money -= Guns.WeaponSMG.Price;
                            Stupid.PlayerWeapon.setWeapon(Guns.WeaponSMG.Power, Guns.WeaponSMG.Accuracy, Guns.WeaponSMG.NumberOfShotsFired, Guns.WeaponSMG.Name, Guns.WeaponSMG.Price);

                            label2.Text = formatStringToCurrency(Stupid.Money);
                            OrigMoneyLabel.Text = label2.Text;

                            label5.Text = Guns.WeaponSMG.Name;
                            OriglWeaponLabel.Text = label5.Text;
                        }
                    }
                }

                if (SelectedItem == Guns.WeaponGrenade.Name)
                {
                    if (Guns.WeaponGrenade.Price <= Stupid.Money)
                    {
                        if (Stupid.PlayerWeapon.Name != Guns.WeaponGrenade.Name)
                        {
                            Stupid.Money += Stupid.PlayerWeapon.Price;
                            Stupid.Money -= Guns.WeaponGrenade.Price;
                            Stupid.PlayerWeapon.setWeapon(Guns.WeaponGrenade.Power, Guns.WeaponGrenade.Accuracy, Guns.WeaponGrenade.NumberOfShotsFired, Guns.WeaponGrenade.Name, Guns.WeaponGrenade.Price);

                            label2.Text = formatStringToCurrency(Stupid.Money);
                            OrigMoneyLabel.Text = label2.Text;

                            label5.Text = Guns.WeaponGrenade.Name;
                            OriglWeaponLabel.Text = label5.Text;
                        }
                    }
                }

                if (SelectedItem == Guns.WeaponBazooka.Name)
                {
                    if (Guns.WeaponBazooka.Price <= Stupid.Money)
                    {
                        if (Stupid.PlayerWeapon.Name != Guns.WeaponBazooka.Name)
                        {
                            Stupid.Money += Stupid.PlayerWeapon.Price;
                            Stupid.Money -= Guns.WeaponBazooka.Price;
                            Stupid.PlayerWeapon.setWeapon(Guns.WeaponBazooka.Power, Guns.WeaponBazooka.Accuracy, Guns.WeaponBazooka.NumberOfShotsFired, Guns.WeaponBazooka.Name, Guns.WeaponBazooka.Price);

                            label2.Text = formatStringToCurrency(Stupid.Money);
                            OrigMoneyLabel.Text = label2.Text;

                            label5.Text = Guns.WeaponBazooka.Name;
                            OriglWeaponLabel.Text = label5.Text;
                        }
                    }
                }

                if (SelectedItem == Guns.WeaponSniper.Name)
                {
                    if (Guns.WeaponSniper.Price <= Stupid.Money)
                    {
                        if (Stupid.PlayerWeapon.Name != Guns.WeaponSniper.Name)
                        {
                            Stupid.Money += Stupid.PlayerWeapon.Price;
                            Stupid.Money -= Guns.WeaponSniper.Price;
                            Stupid.PlayerWeapon.setWeapon(Guns.WeaponSniper.Power, Guns.WeaponSniper.Accuracy, Guns.WeaponSniper.NumberOfShotsFired, Guns.WeaponSniper.Name, Guns.WeaponSniper.Price);

                            label2.Text = formatStringToCurrency(Stupid.Money);
                            OrigMoneyLabel.Text = label2.Text;

                            label5.Text = Guns.WeaponSniper.Name;
                            OriglWeaponLabel.Text = label5.Text;
                        }
                    }
                }

                if (SelectedItem == Guns.WeaponPlasmaRifle.Name)
                {
                    if (Guns.WeaponPlasmaRifle.Price <= Stupid.Money)
                    {
                        if (Stupid.PlayerWeapon.Name != Guns.WeaponPlasmaRifle.Name)
                        {
                            Stupid.Money += Stupid.PlayerWeapon.Price;
                            Stupid.Money -= Guns.WeaponPlasmaRifle.Price;
                            Stupid.PlayerWeapon.setWeapon(Guns.WeaponPlasmaRifle.Power, Guns.WeaponPlasmaRifle.Accuracy, Guns.WeaponPlasmaRifle.NumberOfShotsFired, Guns.WeaponPlasmaRifle.Name, Guns.WeaponPlasmaRifle.Price);

                            label2.Text = formatStringToCurrency(Stupid.Money);
                            OrigMoneyLabel.Text = label2.Text;

                            label5.Text = Guns.WeaponPlasmaRifle.Name;
                            OriglWeaponLabel.Text = label5.Text;
                        }
                    }
                }
            }

            //------------------vehicles
            if (BuyingVehicles == true)
            {
                if (SelectedItem == Vehicles.VehicleRollerblades.Name)
                {
                    if (Vehicles.VehicleRollerblades.Prices <= Stupid.Money)
                    {
                        if (Stupid.PlayerVehicle.Name != Vehicles.VehicleRollerblades.Name)
                        {
                            Stupid.Money += Stupid.PlayerVehicle.Prices;
                            Stupid.Money -= Vehicles.VehicleRollerblades.Prices;
                            Stupid.setVehicle(Vehicles.VehicleRollerblades);

                            label2.Text = formatStringToCurrency(Stupid.Money);
                            OrigMoneyLabel.Text = label2.Text;
                            OrigItem.Text = 

                            label6.Text = Stupid.PlayerVehicle.Name;
                            OrigVehicleLabel.Text = label6.Text;
                        }
                    }
                }
                if (SelectedItem == Vehicles.VehicleHorse.Name)
                {
                    if (Vehicles.VehicleHorse.Prices <= Stupid.Money)
                    {
                        if (Stupid.PlayerVehicle.Name != Vehicles.VehicleHorse.Name)
                        {
                            Stupid.Money += Stupid.PlayerVehicle.Prices;
                            Stupid.Money -= Vehicles.VehicleHorse.Prices;
                            Stupid.setVehicle(Vehicles.VehicleHorse);

                            label2.Text = formatStringToCurrency(Stupid.Money);
                            OrigMoneyLabel.Text = label2.Text;

                            label6.Text = Stupid.PlayerVehicle.Name;
                            OrigVehicleLabel.Text = label6.Text;
                        }
                    }
                }

                if (SelectedItem == Vehicles.VehicleVan.Name)
                {
                    if (Vehicles.VehicleVan.Prices <= Stupid.Money)
                    {
                        if (Stupid.PlayerVehicle.Name != Vehicles.VehicleVan.Name)
                        {
                            Stupid.Money += Stupid.PlayerVehicle.Prices;
                            Stupid.Money -= Vehicles.VehicleVan.Prices;
                            Stupid.setVehicle(Vehicles.VehicleVan);

                            label2.Text = formatStringToCurrency(Stupid.Money);
                            OrigMoneyLabel.Text = label2.Text;

                            label6.Text = Stupid.PlayerVehicle.Name;
                            OrigVehicleLabel.Text = label6.Text;
                        }
                    }
                }

                if (SelectedItem == Vehicles.VehicleGarbage.Name)
                {
                    if (Vehicles.VehicleGarbage.Prices <= Stupid.Money)
                    {
                        if (Stupid.PlayerVehicle.Name != Vehicles.VehicleGarbage.Name)
                        {
                            Stupid.Money += Stupid.PlayerVehicle.Prices;
                            Stupid.Money -= Vehicles.VehicleGarbage.Prices;
                            Stupid.setVehicle(Vehicles.VehicleGarbage);

                            label2.Text = formatStringToCurrency(Stupid.Money);
                            OrigMoneyLabel.Text = label2.Text;

                            label6.Text = Stupid.PlayerVehicle.Name;
                            OrigVehicleLabel.Text = label6.Text;
                        }
                    }
                }

                if (SelectedItem == Vehicles.VehicleBoat.Name)
                {
                    if (Vehicles.VehicleBoat.Prices <= Stupid.Money)
                    {
                        if (Stupid.PlayerVehicle.Name != Vehicles.VehicleBoat.Name)
                        {
                            Stupid.Money += Stupid.PlayerVehicle.Prices;
                            Stupid.Money -= Vehicles.VehicleBoat.Prices;
                            Stupid.setVehicle(Vehicles.VehicleBoat);

                            label2.Text = formatStringToCurrency(Stupid.Money);
                            OrigMoneyLabel.Text = label2.Text;

                            label6.Text = Stupid.PlayerVehicle.Name;
                            OrigVehicleLabel.Text = label6.Text;
                        }
                    }
                }

                if (SelectedItem == Vehicles.VehicleSportsCar.Name)
                {
                    if (Vehicles.VehicleSportsCar.Prices <= Stupid.Money)
                    {
                        if (Stupid.PlayerVehicle.Name != Vehicles.VehicleSportsCar.Name)
                        {
                            Stupid.Money += Stupid.PlayerVehicle.Prices;
                            Stupid.Money -= Vehicles.VehicleSportsCar.Prices;
                            Stupid.setVehicle(Vehicles.VehicleSportsCar);

                            label2.Text = formatStringToCurrency(Stupid.Money);
                            OrigMoneyLabel.Text = label2.Text;

                            label6.Text = Stupid.PlayerVehicle.Name;
                            OrigVehicleLabel.Text = label6.Text;
                        }
                    }
                }
                if (SelectedItem == Vehicles.VehiclePortalGun.Name)
                {
                    if (Vehicles.VehiclePortalGun.Prices <= Stupid.Money)
                    {
                        if (Stupid.PlayerVehicle.Name != Vehicles.VehiclePortalGun.Name)
                        {
                            Stupid.Money += Stupid.PlayerVehicle.Prices;
                            Stupid.Money -= Vehicles.VehiclePortalGun.Prices;
                            Stupid.setVehicle(Vehicles.VehiclePortalGun);

                            label2.Text = formatStringToCurrency(Stupid.Money);
                            OrigMoneyLabel.Text = label2.Text;

                            label6.Text = Stupid.PlayerVehicle.Name;
                            OrigVehicleLabel.Text = label6.Text;
                        }
                    }
                }
            }
            //-------------------------misc
            if (BuyingMisc == true)
            {
                Item[] ItemList = new Item[11];
                ItemList[0] = ItemItem.TrenchCoat;
                ItemList[1] = ItemItem.BackPack;
                ItemList[2] = ItemItem.CargoPants;
                ItemList[3] = ItemItem.BodyArmor;
                ItemList[4] = ItemItem.Helmet;
                ItemList[5] = ItemItem.Kneepads;
                ItemList[6] = ItemItem.SwatShield;
                ItemList[7] = ItemItem.Calculator;

                if (ItemList[SelectedItemMisc].Price <= Stupid.Money)
                {
                    if (Stupid.getOwned(SelectedItemMisc) == false)
                    {
                        if (SelectedItemMisc == 0)
                            Stupid.addTrenchCoat();
                        if (SelectedItemMisc == 1)
                            Stupid.addBackPack();
                        if (SelectedItemMisc == 2)
                            Stupid.addCargoPants();
                        if (SelectedItemMisc == 3)
                            Stupid.addBodyArmor();
                        if (SelectedItemMisc == 4)
                            Stupid.addHelmet();
                        if (SelectedItemMisc == 5)
                            Stupid.addKneepads();
                        if (SelectedItemMisc == 6)
                            Stupid.addSwatShield();
                        if (SelectedItemMisc == 7)
                            Stupid.addCalculator();

                        label2.Text = formatStringToCurrency(Stupid.Money);
                        OrigMoneyLabel.Text = label2.Text;

                        label6.Text = Stupid.PlayerVehicle.Name;
                        OrigVehicleLabel.Text = label6.Text;

                        OrigItem.Text = Stupid.Inventory.ToString() + " /kgkg " + Stupid.MaxInventory.ToString();
                        OrigHealth.Text = Stupid.Health + " / " + Stupid.MaxHealth;
                    }
                    else
                    {
                        YouAlreadyOwnThiscs Dummy = new YouAlreadyOwnThiscs();
                        Dummy.StartPosition = FormStartPosition.CenterParent;
                        Dummy.ShowDialog(this);
                    }
                }
            }

            OrigHealth.Text = Stupid.Health + " / " + Stupid.MaxHealth;
            OrigItem.Text = Stupid.Inventory.ToString() + " / " + Stupid.MaxInventory.ToString();
        }
            


        private void button3_Click(object sender, EventArgs e)
        {
            BuyingMisc = false;
            BuyingVehicles = false;
            BuyingWeapons = true;
            
            populateStoreListWeapons();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BuyingMisc = false;
            BuyingVehicles = true;
            BuyingWeapons = false;

            populateStoreListVehicles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuyingMisc = true;
            BuyingVehicles = false;
            BuyingWeapons = false;
            
            populateStoreListMisc();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Stupid.PlayerWeapon.Name != "None")
            {
                Stupid.Money += Stupid.PlayerWeapon.Price;
                Stupid.setWeapon(Guns.WeaponNone);

                label5.Text = "None";
                OriglWeaponLabel.Text = "None";
                OrigMoneyLabel.Text = formatStringToCurrency(Stupid.Money);
                label2.Text = formatStringToCurrency(Stupid.Money);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Stupid.PlayerVehicle.Name != "None")
            {
                Stupid.Money += Stupid.PlayerVehicle.Prices;
                Stupid.setVehicle(Vehicles.VehicleNone);

                label6.Text = "None";
                OrigVehicleLabel.Text = "None";
                OrigMoneyLabel.Text = formatStringToCurrency(Stupid.Money);
                label2.Text = formatStringToCurrency(Stupid.Money);
            }
        }

        private void Store_Load(object sender, EventArgs e)
        {

        }
    }
}
