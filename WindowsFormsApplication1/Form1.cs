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
    public partial class Form1 : Form
    {
        private Player MyPlayer = new Player();
        private BundleDrugs[] BuyDrugs = new BundleDrugs[6];
        int[] PriceGreen = new int[22];

        public Random random = new Random();

        int DayToCollectDebt;
        int LocalTravel = 0, DebtRate;
        bool Buying, SpecialEvent;
        bool GameOverYet;
        int DayOfPriceWarning = 0;
        
        bool[] PriceRise = new bool[6];
        bool[] EventLocation = new bool[6];
        int[] ChosenDrug = new int[11];
        string Location;

        bool[] Fight = new bool[6];

        public Form1()
        {
            InitializeComponent();

            resetSpecialEventItems();

            BuyDrugs[0] = new BundleDrugs();
            BuyDrugs[1] = new BundleDrugs();
            BuyDrugs[2] = new BundleDrugs();
            BuyDrugs[3] = new BundleDrugs();
            BuyDrugs[4] = new BundleDrugs();
            BuyDrugs[5] = new BundleDrugs();

            Buying = true;
            SpecialEvent = false;
            DebtRate = 20;
            GameOverYet = false;
            
            Location = "Rawr";

            Intro intro = new Intro();
            intro.StartPosition = FormStartPosition.CenterParent;
            intro.Show();
            intro.TopMost = true;
            DayToCollectDebt = 10;

            int counter = 0;
            while (counter < 11)
            {
                PriceGreen[counter] = 0;
                counter++;
            }

            advanceDay();
        }

        private void generateFightLocations()
        {
            int counter = 0;
            Random r = new Random();
            while (counter < 6)
            {
                Fight[counter] = r.Next() % 2 == 0 ? true : false;
                counter++;
            }
        }

        private void advanceDay()
        {
            getPriceGreen();

            LocalTravel++;
            if (LocalTravel == 1)
                label14.Text = "Morning";
            if (LocalTravel == 2)
                label14.Text = "Noon";
            if (LocalTravel == 3)
                label14.Text = "Afternoon";
            if (LocalTravel == 4)
                label14.Text = "Evening";
            if (LocalTravel == 5)
                label14.Text = "Night";

            if (MyPlayer.Day >= 8)
            {
                if (Fight[MyPlayer.Location] == true)
                {
                    bool DoubleJeopardy = random.Next() % 2 == 0 ? true : false;
                    if (DoubleJeopardy == false)
                        DoubleJeopardy = random.Next() % 2 == 0 ? true : false;
                    if (DoubleJeopardy == true)
                    {
                        RefBool Success = new RefBool(false);
                        Combat ComForm = new Combat(ref MyPlayer, ref label16, ref label8, ref label7, ref label2, ref Success);
                        ComForm.ControlBox = false;
                        ComForm.StartPosition = FormStartPosition.CenterParent;
                        ComForm.ShowDialog(this);
                        Fight[MyPlayer.Location] = false;

                        if (MyPlayer.Health <= 0)
                        {
                            MyPlayer.Health = 10;
                            MyPlayer.SellDrugs.Acid.Quantity = 0;
                            MyPlayer.SellDrugs.Acid.PurchasePrice = 0;
                            MyPlayer.SellDrugs.Cocaine.Quantity = 0;
                            MyPlayer.SellDrugs.Cocaine.PurchasePrice = 0;
                            MyPlayer.SellDrugs.Crack.Quantity = 0;
                            MyPlayer.SellDrugs.Crack.PurchasePrice = 0;
                            MyPlayer.SellDrugs.CrystalMeth.Quantity = 0;
                            MyPlayer.SellDrugs.CrystalMeth.PurchasePrice = 0;
                            MyPlayer.SellDrugs.Ecstasy.Quantity = 0;
                            MyPlayer.SellDrugs.Ecstasy.PurchasePrice = 0;
                            MyPlayer.SellDrugs.Hash.Quantity = 0;
                            MyPlayer.SellDrugs.Hash.PurchasePrice = 0;
                            MyPlayer.SellDrugs.Heroin.Quantity = 0;
                            MyPlayer.SellDrugs.Heroin.PurchasePrice = 0;
                            MyPlayer.SellDrugs.Mescaline.Quantity = 0;
                            MyPlayer.SellDrugs.Mescaline.PurchasePrice = 0;
                            MyPlayer.SellDrugs.Morphine.Quantity = 0;
                            MyPlayer.SellDrugs.Morphine.PurchasePrice = 0;
                            MyPlayer.SellDrugs.Mushrooms.Quantity = 0;
                            MyPlayer.SellDrugs.Mushrooms.PurchasePrice = 0;
                            MyPlayer.SellDrugs.Weed.Quantity = 0;
                            MyPlayer.SellDrugs.Weed.PurchasePrice = 0;

                            MyPlayer.Money = MyPlayer.Money / 2;
                        }
                    }
                }
            }

            if (LocalTravel >= MyPlayer.PlayerVehicle.Speeds)
            {
                LocalTravel = 0;
                label14.Text = "Early Morning";
                MyPlayer.Day++;


                MyPlayer.Bank += getPercent(MyPlayer.Bank, 5);
                MyPlayer.Debt += getPercent(MyPlayer.Debt, DebtRate);

                generateFightLocations();


                BuyDrugs[0].generateAmounts();
                BuyDrugs[0].generatePrices();
                BuyDrugs[1].generateAmounts();
                BuyDrugs[1].generatePrices();
                BuyDrugs[2].generateAmounts();
                BuyDrugs[2].generatePrices();
                BuyDrugs[3].generateAmounts();
                BuyDrugs[3].generatePrices();
                BuyDrugs[4].generateAmounts();
                BuyDrugs[4].generatePrices();
                BuyDrugs[5].generateAmounts();
                BuyDrugs[5].generatePrices();

                if ((MyPlayer.Day == (DayOfPriceWarning + 1)) && (SpecialEvent == true)) 
                {
                    specialEventAdd();
                    SpecialEvent = true;
                    richTextBox1.Clear();
                    resetSpecialEventItems();
                }
            }
            repopulateBuyList();
            repopulateSellList();
            
            if (MyPlayer.OwnCalculator == true)
            {
                hidePictures();
                showPictures();
            }
            else
                hidePictures();


            if (MyPlayer.Day == 1)
            {
                MyPlayer.Debt = 5500;
                MyPlayer.Money = 2500;
            }


            if ((MyPlayer.Day == 31) && (GameOverYet == false))
            {
                if (LocalTravel == 0)
                {
                    bool Winner = false;
                    if (((MyPlayer.Money + MyPlayer.Bank) - MyPlayer.Debt) >= 1000000)
                    {
                        Winner = true;
                    }

                    GameOverForm GameOver = new GameOverForm(Winner);
                    GameOver.StartPosition = FormStartPosition.CenterParent;
                    GameOver.ShowDialog(this);
                    GameOverYet = true;
                }
            }
            if ((((MyPlayer.Money + MyPlayer.Bank) - MyPlayer.Debt) >= 1000000) && (GameOverYet == false))
            {
                GameOverForm GameOver = new GameOverForm(true);
                GameOver.StartPosition = FormStartPosition.CenterParent;
                GameOver.ShowDialog(this);
                GameOverYet = true;
            }


            int r = random.Next(1, 10);
            if ((r > 4) && (r < 7))//in ten chance of a price rising or lowering
            {
                SpecialEvent = true;
                DayOfPriceWarning = MyPlayer.Day;
                generateSpecialEvent();
            }

            if (MyPlayer.Day == DayToCollectDebt)
            {
                DebtCollector ChoiceHere = new DebtCollector(ref MyPlayer, ref label2, ref label4, ref label16);
                ChoiceHere.ControlBox = false;
                ChoiceHere.StartPosition = FormStartPosition.CenterParent;

                ChoiceHere.ShowDialog(this);

                if (MyPlayer.Debt > 0)
                {
                    DayToCollectDebt += 5;
                }
            }

            label2.Text = formatStringToCurrency(MyPlayer.Money);
            label4.Text = formatStringToCurrency(MyPlayer.Debt);
            label21.Text = formatStringToCurrency(MyPlayer.Bank);
            label10.Text = MyPlayer.Day.ToString();
            label16.Text = MyPlayer.Health + " / " + MyPlayer.MaxHealth;
            label7.Text = MyPlayer.PlayerVehicle.Name;
            label8.Text = MyPlayer.PlayerWeapon.Name;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void resetSpecialEventItems()
        {
            SpecialEvent = false;
            DayOfPriceWarning = 0;

            int counter = 0;
            while (counter < 6)
            {
                PriceRise[counter] = false;
                EventLocation[counter] = false;
                counter++;
            }
            counter = 0;
            while (counter < 11)
            {
                ChosenDrug[counter] = 0;
                counter++;
            }

            Location = "Rawr";
        }

        private void generateSpecialEvent()
        {
            int WhereAt = random.Next(1, 5);
            while (EventLocation[WhereAt] == true)
            {
                if (EventLocation[1] == false)
                    WhereAt = 1;
                else if (EventLocation[2] == false)
                    WhereAt = 2;
                else if (EventLocation[3] == false)
                    WhereAt = 3;
                else if (EventLocation[4] == false)
                    WhereAt = 4;
                else if (EventLocation[5] == false)
                     WhereAt = 0;
            }

            Drug[] DrugList = new Drug[11];
            DrugList[0] = BuyDrugs[WhereAt].Acid;
            DrugList[1] = BuyDrugs[WhereAt].Cocaine;
            DrugList[2] = BuyDrugs[WhereAt].Crack;
            DrugList[3] = BuyDrugs[WhereAt].CrystalMeth;
            DrugList[4] = BuyDrugs[WhereAt].Ecstasy;
            DrugList[5] = BuyDrugs[WhereAt].Hash;
            DrugList[6] = BuyDrugs[WhereAt].Heroin;
            DrugList[7] = BuyDrugs[WhereAt].Mescaline;
            DrugList[8] = BuyDrugs[WhereAt].Morphine;
            DrugList[9] = BuyDrugs[WhereAt].Mushrooms;
            DrugList[10] = BuyDrugs[WhereAt].Weed;

            int DrugToModify = random.Next(0, 10);
            PriceRise[WhereAt] = random.Next() % 2 == 0 ? true : false;
            EventLocation[WhereAt] = true;
            ChosenDrug[WhereAt] = DrugToModify;

            Location = "Rawr";
            if (WhereAt == New_York.BRONX)
                Location = "Bronx";
            if (WhereAt == New_York.BROOKLYN)
                Location = "Brooklyn";
            if (WhereAt == New_York.MANHATTAN)
                Location = "Manhattan";
            if (WhereAt == New_York.STATEN_ISLAND)
                Location = "Staten Island";
            if (WhereAt == New_York.QUEENS)
                Location = "Queens";
            if (WhereAt == 0)
                Location = "Some crazy guy just ran up to you yelling, 'DANGER!  DANGER WILL ROBINSON!'";

            if (PriceRise[WhereAt] == true)
                if (WhereAt != 0)
                    richTextBox1.Text = "Word on the street is that the price of " + DrugList[DrugToModify].Name + " is going to drastically increase in " + Location + " tomorrow.";
            else
                if (WhereAt != 0)
                    richTextBox1.Text = "Word on the street is that the price of " + DrugList[DrugToModify].Name + " is going to drastically decrease in " + Location + " tomorrow.";

            if (WhereAt == 0)
            {
                richTextBox1.Text = Location;
                PriceRise[WhereAt] = false;
                EventLocation[WhereAt] = false;
                ChosenDrug[WhereAt] = 0;
            }
        }

        private void specialEventAdd()
        {
            int Counter = 1;
            while (Counter <= 5)
            {
                if (EventLocation[Counter] == true)
                {
                    bool Liars = random.Next() % 2 == 0 ? true : false;;
                    if (Liars == false)
                    {
                        Drug[] DrugList = new Drug[11];
                        DrugList[0] = BuyDrugs[Counter].Acid;
                        DrugList[1] = BuyDrugs[Counter].Cocaine;
                        DrugList[2] = BuyDrugs[Counter].Crack;
                        DrugList[3] = BuyDrugs[Counter].CrystalMeth;
                        DrugList[4] = BuyDrugs[Counter].Ecstasy;
                        DrugList[5] = BuyDrugs[Counter].Hash;
                        DrugList[6] = BuyDrugs[Counter].Heroin;
                        DrugList[7] = BuyDrugs[Counter].Mescaline;
                        DrugList[8] = BuyDrugs[Counter].Morphine;
                        DrugList[9] = BuyDrugs[Counter].Mushrooms;
                        DrugList[10] = BuyDrugs[Counter].Weed;

                        if (PriceRise[Counter] == true)
                        {
                            int Multiplier = random.Next(5, 11);
                            DrugList[ChosenDrug[Counter]].Price = DrugList[ChosenDrug[Counter]].Price * Multiplier;
                        }
                        else
                        {
                            int Dividing = random.Next(5, 11);
                            DrugList[ChosenDrug[Counter]].Price = DrugList[ChosenDrug[Counter]].Price / Dividing;
                        }
                    }
                }
                Counter++;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label13.Text = "Bronx";
            toolStripStatusLabel2.Text = "Bronx";
            MyPlayer.Location = New_York.BRONX;

            advanceDay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label13.Text = "Brooklyn";
            toolStripStatusLabel2.Text = "Brooklyn";
            MyPlayer.Location = New_York.BROOKLYN;

            advanceDay();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label13.Text = "Manhattan";
            toolStripStatusLabel2.Text = "Manhattan";
            MyPlayer.Location = New_York.MANHATTAN;


            advanceDay();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label13.Text = "Staten Island";
            toolStripStatusLabel2.Text = "Staten Island";
            MyPlayer.Location = New_York.STATEN_ISLAND;

            advanceDay();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label13.Text = "Queens";
            toolStripStatusLabel2.Text = "Queens";
            MyPlayer.Location = New_York.QUEENS;

            advanceDay();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        public string formatStringToCurrency(int NumberToStringFormat)
        {
            string NewStringValue = NumberToStringFormat.ToString("#,##0");
            NewStringValue = "$" + NewStringValue;
            return NewStringValue;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buying = true;
            button10.Text = "Buy";
            int Selected = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                // is i the index of the row I selected?
                if (listView1.Items[i].Selected == true)
                {
                    Selected = i;
                    break;
                }
            }

            int CurrentLocation = MyPlayer.Location;
            Drug[] DrugList = new Drug[11];
            DrugList[0] = BuyDrugs[CurrentLocation].Acid;
            DrugList[1] = BuyDrugs[CurrentLocation].Cocaine;
            DrugList[2] = BuyDrugs[CurrentLocation].Crack;
            DrugList[3] = BuyDrugs[CurrentLocation].CrystalMeth;
            DrugList[4] = BuyDrugs[CurrentLocation].Ecstasy;
            DrugList[5] = BuyDrugs[CurrentLocation].Hash;
            DrugList[6] = BuyDrugs[CurrentLocation].Heroin;
            DrugList[7] = BuyDrugs[CurrentLocation].Mescaline;
            DrugList[8] = BuyDrugs[CurrentLocation].Morphine;
            DrugList[9] = BuyDrugs[CurrentLocation].Mushrooms;
            DrugList[10] = BuyDrugs[CurrentLocation].Weed;

            int NumericValue = MyPlayer.Money / (DrugList[Selected].Price);
            if (NumericValue > DrugList[Selected].Quantity)
                NumericValue = DrugList[Selected].Quantity;
            if (NumericValue + MyPlayer.Inventory > MyPlayer.MaxInventory)
                NumericValue = MyPlayer.MaxInventory - MyPlayer.Inventory;
    
            numericUpDown1.Value = NumericValue;
        }

        private void repopulateBuyList()
        {
            listView1.Items.Clear();
            listView1.Items.Clear();
            int CurrentLocation = MyPlayer.Location;

            string[] row1 = { BuyDrugs[CurrentLocation].Acid.Quantity.ToString(), formatStringToCurrency(BuyDrugs[CurrentLocation].Acid.Price) };
            listView1.Items.Add(BuyDrugs[CurrentLocation].Acid.Name).SubItems.AddRange(row1);

            string[] row2 = { BuyDrugs[CurrentLocation].Cocaine.Quantity.ToString(), formatStringToCurrency(BuyDrugs[CurrentLocation].Cocaine.Price) };
            listView1.Items.Add(BuyDrugs[CurrentLocation].Cocaine.Name).SubItems.AddRange(row2);

            string[] row3 = { BuyDrugs[CurrentLocation].Crack.Quantity.ToString(), formatStringToCurrency(BuyDrugs[CurrentLocation].Crack.Price) };
            listView1.Items.Add(BuyDrugs[CurrentLocation].Crack.Name).SubItems.AddRange(row3);

            string[] row4 = { BuyDrugs[CurrentLocation].CrystalMeth.Quantity.ToString(), formatStringToCurrency(BuyDrugs[CurrentLocation].CrystalMeth.Price) };
            listView1.Items.Add(BuyDrugs[CurrentLocation].CrystalMeth.Name).SubItems.AddRange(row4);

            string[] row5 = { BuyDrugs[CurrentLocation].Ecstasy.Quantity.ToString(), formatStringToCurrency(BuyDrugs[CurrentLocation].Ecstasy.Price) };
            listView1.Items.Add(BuyDrugs[CurrentLocation].Ecstasy.Name).SubItems.AddRange(row5);

            string[] row6 = { BuyDrugs[CurrentLocation].Hash.Quantity.ToString(), formatStringToCurrency(BuyDrugs[CurrentLocation].Hash.Price) };
            listView1.Items.Add(BuyDrugs[CurrentLocation].Hash.Name).SubItems.AddRange(row6);

            string[] row7 = { BuyDrugs[CurrentLocation].Heroin.Quantity.ToString(), formatStringToCurrency(BuyDrugs[CurrentLocation].Heroin.Price) };
            listView1.Items.Add(BuyDrugs[CurrentLocation].Heroin.Name).SubItems.AddRange(row7);

            string[] row8 = { BuyDrugs[CurrentLocation].Mescaline.Quantity.ToString(), formatStringToCurrency(BuyDrugs[CurrentLocation].Mescaline.Price) };
            listView1.Items.Add(BuyDrugs[CurrentLocation].Mescaline.Name).SubItems.AddRange(row8);

            string[] row9 = { BuyDrugs[CurrentLocation].Morphine.Quantity.ToString(), formatStringToCurrency(BuyDrugs[CurrentLocation].Morphine.Price) };
            listView1.Items.Add(BuyDrugs[CurrentLocation].Morphine.Name).SubItems.AddRange(row9);

            string[] row10 = { BuyDrugs[CurrentLocation].Mushrooms.Quantity.ToString(), formatStringToCurrency(BuyDrugs[CurrentLocation].Mushrooms.Price) };
            listView1.Items.Add(BuyDrugs[CurrentLocation].Mushrooms.Name).SubItems.AddRange(row10);

            string[] row11 = { BuyDrugs[CurrentLocation].Weed.Quantity.ToString(), formatStringToCurrency(BuyDrugs[CurrentLocation].Weed.Price) };
            listView1.Items.Add(BuyDrugs[CurrentLocation].Weed.Name).SubItems.AddRange(row11);
        }

        private void repopulateSellList()
        {
            listView2.Items.Clear();
            
            string[] row1 = { MyPlayer.SellDrugs.Acid.Quantity.ToString(), formatStringToCurrency(MyPlayer.SellDrugs.Acid.PurchasePrice)};
            listView2.Items.Add("Acid").SubItems.AddRange(row1);

            string[] row2 = { MyPlayer.SellDrugs.Cocaine.Quantity.ToString(), formatStringToCurrency(MyPlayer.SellDrugs.Cocaine.PurchasePrice) };
            listView2.Items.Add("Cocaine").SubItems.AddRange(row2);

            string[] row3 = { MyPlayer.SellDrugs.Crack.Quantity.ToString(), formatStringToCurrency(MyPlayer.SellDrugs.Crack.PurchasePrice) };
            listView2.Items.Add("Crack").SubItems.AddRange(row3);

            string[] row4 = { MyPlayer.SellDrugs.CrystalMeth.Quantity.ToString(), formatStringToCurrency(MyPlayer.SellDrugs.CrystalMeth.PurchasePrice) };
            listView2.Items.Add("CrystalMeth").SubItems.AddRange(row4);

            string[] row5 = { MyPlayer.SellDrugs.Ecstasy.Quantity.ToString(), formatStringToCurrency(MyPlayer.SellDrugs.Ecstasy.PurchasePrice) };
            listView2.Items.Add("Ecstasy").SubItems.AddRange(row5);

            string[] row6 = { MyPlayer.SellDrugs.Hash.Quantity.ToString(), formatStringToCurrency(MyPlayer.SellDrugs.Hash.PurchasePrice) };
            listView2.Items.Add("Hash").SubItems.AddRange(row6);

            string[] row7 = { MyPlayer.SellDrugs.Heroin.Quantity.ToString(), formatStringToCurrency(MyPlayer.SellDrugs.Heroin.PurchasePrice) };
            listView2.Items.Add("Heroin").SubItems.AddRange(row7);

            string[] row8 = { MyPlayer.SellDrugs.Mescaline.Quantity.ToString(), formatStringToCurrency(MyPlayer.SellDrugs.Mescaline.PurchasePrice) };
            listView2.Items.Add("Mescaline").SubItems.AddRange(row8);

            string[] row9 = { MyPlayer.SellDrugs.Morphine.Quantity.ToString(), formatStringToCurrency(MyPlayer.SellDrugs.Morphine.PurchasePrice) };
            listView2.Items.Add("Morphine").SubItems.AddRange(row9);

            string[] row10 = { MyPlayer.SellDrugs.Mushrooms.Quantity.ToString(), formatStringToCurrency(MyPlayer.SellDrugs.Mushrooms.PurchasePrice) };
            listView2.Items.Add("Mushrooms").SubItems.AddRange(row10);

            string[] row11 = { MyPlayer.SellDrugs.Weed.Quantity.ToString(), formatStringToCurrency(MyPlayer.SellDrugs.Weed.PurchasePrice) };
            listView2.Items.Add("Weed").SubItems.AddRange(row11);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int Selected = 0;
            if (Buying == true)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    // is i the index of the row I selected?
                    if (listView1.Items[i].Selected == true)
                    {
                        Selected = i;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    // is i the index of the row I selected?
                    if (listView2.Items[i].Selected == true)
                    {
                        Selected = i;
                        break;
                    }
                }
            }

            int CurrentLocation = MyPlayer.Location;
            Drug[] DrugList = new Drug[11];
            DrugList[0] = BuyDrugs[CurrentLocation].Acid;
            DrugList[1] = BuyDrugs[CurrentLocation].Cocaine;
            DrugList[2] = BuyDrugs[CurrentLocation].Crack;
            DrugList[3] = BuyDrugs[CurrentLocation].CrystalMeth;
            DrugList[4] = BuyDrugs[CurrentLocation].Ecstasy;
            DrugList[5] = BuyDrugs[CurrentLocation].Hash;
            DrugList[6] = BuyDrugs[CurrentLocation].Heroin;
            DrugList[7] = BuyDrugs[CurrentLocation].Mescaline;
            DrugList[8] = BuyDrugs[CurrentLocation].Morphine;
            DrugList[9] = BuyDrugs[CurrentLocation].Mushrooms;
            DrugList[10] = BuyDrugs[CurrentLocation].Weed;

            Drug[] SellList = new Drug[11];
            SellList[0] = MyPlayer.SellDrugs.Acid;
            SellList[1] = MyPlayer.SellDrugs.Cocaine;
            SellList[2] = MyPlayer.SellDrugs.Crack;
            SellList[3] = MyPlayer.SellDrugs.CrystalMeth;
            SellList[4] = MyPlayer.SellDrugs.Ecstasy;
            SellList[5] = MyPlayer.SellDrugs.Hash;
            SellList[6] = MyPlayer.SellDrugs.Heroin;
            SellList[7] = MyPlayer.SellDrugs.Mescaline;
            SellList[8] = MyPlayer.SellDrugs.Morphine;
            SellList[9] = MyPlayer.SellDrugs.Mushrooms;
            SellList[10] = MyPlayer.SellDrugs.Weed;

            if (Buying == true)
            {
                int NumericValue = (int)numericUpDown1.Value;
                if (NumericValue > DrugList[Selected].Quantity)
                    NumericValue = DrugList[Selected].Quantity;
                if (NumericValue + MyPlayer.Inventory > MyPlayer.MaxInventory)
                    NumericValue = MyPlayer.MaxInventory - MyPlayer.Inventory;

                if (numericUpDown1.Value != 0)
                {
                    int QuantityTotal = NumericValue + SellList[Selected].Quantity;

                    int PriceOfSell = (SellList[Selected].PurchasePrice * SellList[Selected].Quantity);
                    int PriceOfBuy = (DrugList[Selected].Price * NumericValue);

                    int FinalPrice = (PriceOfSell + PriceOfBuy) / QuantityTotal;

                    SellList[Selected].PurchasePrice = FinalPrice;
                }

                MyPlayer.Money -= NumericValue * DrugList[Selected].Price;
                MyPlayer.Inventory += NumericValue;

                DrugList[Selected].Quantity -= NumericValue;
                SellList[Selected].Quantity += NumericValue;
                        

                label2.Text = formatStringToCurrency(MyPlayer.Money);
                label19.Text = MyPlayer.Inventory + " / " + MyPlayer.MaxInventory;
            }
            else if (Buying == false)
            {

                int NumericValue = (int)numericUpDown1.Value;
                if (NumericValue > SellList[Selected].Quantity)
                    NumericValue = SellList[Selected].Quantity;

                MyPlayer.Money += NumericValue * DrugList[Selected].Price;
                MyPlayer.Inventory -= NumericValue;

                DrugList[Selected].Quantity += NumericValue;
                SellList[Selected].Quantity -= NumericValue;

                if (SellList[Selected].Quantity <= 0)
                    SellList[Selected].PurchasePrice = 0;

                label2.Text = formatStringToCurrency(MyPlayer.Money);
                label19.Text = MyPlayer.Inventory + " / " + MyPlayer.MaxInventory;
            }


            repopulateSellList();
            repopulateBuyList();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            repopulateSellList();
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Store StoreForm = new Store(ref MyPlayer, ref label2, ref label8, ref label7, ref label19, ref label16);
            StoreForm.StartPosition = FormStartPosition.CenterParent;
            StoreForm.ShowDialog(this);

            if (MyPlayer.OwnCalculator == true)
                showPictures();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DoctorForm Hospital = new DoctorForm(ref MyPlayer, ref label16, ref label2);
            Hospital.StartPosition = FormStartPosition.CenterParent;
            Hospital.ShowDialog(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BankDialog Banks = new BankDialog(ref MyPlayer, ref label2, ref label21);
            Banks.StartPosition = FormStartPosition.CenterParent;
            Banks.ShowDialog(this);
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            if (Buying == true)
            {
                int Selected = 0;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    // is i the index of the row I selected?
                    if (listView1.Items[i].Selected == true)
                    {
                        Selected = i;
                        break;
                    }
                }

                int CurrentLocation = MyPlayer.Location;
                Drug[] DrugList = new Drug[11];
                DrugList[0] = MyPlayer.SellDrugs.Acid;
                DrugList[1] = MyPlayer.SellDrugs.Cocaine;
                DrugList[2] = MyPlayer.SellDrugs.Crack;
                DrugList[3] = MyPlayer.SellDrugs.CrystalMeth;
                DrugList[4] = MyPlayer.SellDrugs.Ecstasy;
                DrugList[5] = MyPlayer.SellDrugs.Hash;
                DrugList[6] = MyPlayer.SellDrugs.Heroin;
                DrugList[7] = MyPlayer.SellDrugs.Mescaline;
                DrugList[8] = MyPlayer.SellDrugs.Morphine;
                DrugList[9] = MyPlayer.SellDrugs.Mushrooms;
                DrugList[10] = MyPlayer.SellDrugs.Weed;

                int NumericValue = (int)numericUpDown1.Value;
               // if (NumericValue > DrugList[Selected].Quantity)
                    //NumericValue = DrugList[Selected].Quantity;
                if (NumericValue + MyPlayer.Inventory > MyPlayer.MaxInventory)
                    NumericValue = MyPlayer.MaxInventory - MyPlayer.Inventory;
                
                numericUpDown1.Value = NumericValue;
            }

            else if (Buying == false)
            {
                int Selected = 0;
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    // is i the index of the row I selected?
                    if (listView2.Items[i].Selected == true)
                    {
                        Selected = i;
                        break;
                    }
                }

                int CurrentLocation = MyPlayer.Location;
                Drug[] DrugList = new Drug[11];
                DrugList[0] = MyPlayer.SellDrugs.Acid;
                DrugList[1] = MyPlayer.SellDrugs.Cocaine;
                DrugList[2] = MyPlayer.SellDrugs.Crack;
                DrugList[3] = MyPlayer.SellDrugs.CrystalMeth;
                DrugList[4] = MyPlayer.SellDrugs.Ecstasy;
                DrugList[5] = MyPlayer.SellDrugs.Hash;
                DrugList[6] = MyPlayer.SellDrugs.Heroin;
                DrugList[7] = MyPlayer.SellDrugs.Mescaline;
                DrugList[8] = MyPlayer.SellDrugs.Morphine;
                DrugList[9] = MyPlayer.SellDrugs.Mushrooms;
                DrugList[10] = MyPlayer.SellDrugs.Weed;

                if (numericUpDown1.Value > DrugList[Selected].Quantity)
                    numericUpDown1.Value = DrugList[Selected].Quantity;
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buying = false;
            button10.Text = "Sell";
           
            int Selected = 0;
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                // is i the index of the row I selected?
                if (listView2.Items[i].Selected == true)
                {
                    Selected = i;
                    break;
                }
            }

            int CurrentLocation = MyPlayer.Location;
            Drug[] DrugList = new Drug[11];
            DrugList[0] = MyPlayer.SellDrugs.Acid;
            DrugList[1] = MyPlayer.SellDrugs.Cocaine;
            DrugList[2] = MyPlayer.SellDrugs.Crack;
            DrugList[3] = MyPlayer.SellDrugs.CrystalMeth;
            DrugList[4] = MyPlayer.SellDrugs.Ecstasy;
            DrugList[5] = MyPlayer.SellDrugs.Hash;
            DrugList[6] = MyPlayer.SellDrugs.Heroin;
            DrugList[7] = MyPlayer.SellDrugs.Mescaline;
            DrugList[8] = MyPlayer.SellDrugs.Morphine;
            DrugList[9] = MyPlayer.SellDrugs.Mushrooms;
            DrugList[10] = MyPlayer.SellDrugs.Weed;

            numericUpDown1.Value = DrugList[Selected].Quantity;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }


        private int getPercent(int Number, int PercentValue)
        {
            decimal c = (int)(((decimal)PercentValue / (decimal)100) * Number);
            return (int)c;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void showPictures()
        {
            int WhereAt = MyPlayer.Location;

            Drug[] DrugList = new Drug[11];
            DrugList[0] = BuyDrugs[WhereAt].Acid;
            DrugList[1] = BuyDrugs[WhereAt].Cocaine;
            DrugList[2] = BuyDrugs[WhereAt].Crack;
            DrugList[3] = BuyDrugs[WhereAt].CrystalMeth;
            DrugList[4] = BuyDrugs[WhereAt].Ecstasy;
            DrugList[5] = BuyDrugs[WhereAt].Hash;
            DrugList[6] = BuyDrugs[WhereAt].Heroin;
            DrugList[7] = BuyDrugs[WhereAt].Mescaline;
            DrugList[8] = BuyDrugs[WhereAt].Morphine;
            DrugList[9] = BuyDrugs[WhereAt].Mushrooms;
            DrugList[10] = BuyDrugs[WhereAt].Weed;

            if (PriceGreen[0] > DrugList[0].Price)
            {
                pictureBox1.Show();
            }
            else
                pictureBox12.Show();

            if (PriceGreen[1] > DrugList[1].Price)
            {
                pictureBox2.Show();
            }
            else
                pictureBox13.Show();

            if (PriceGreen[2] > DrugList[2].Price)
            {
                pictureBox3.Show();
            }
            else
                pictureBox14.Show();

            if (PriceGreen[3] > DrugList[3].Price)
            {
                pictureBox4.Show();
            }
            else
                pictureBox15.Show();

            if (PriceGreen[4] > DrugList[4].Price)
            {
                pictureBox5.Show();
            }
            else
                pictureBox16.Show();

            if (PriceGreen[5] > DrugList[5].Price)
            {
                pictureBox6.Show();
            }
            else
                pictureBox17.Show();

            if (PriceGreen[6] > DrugList[6].Price)
            {
                pictureBox7.Show();
            }
            else
                pictureBox18.Show();

            if (PriceGreen[7] > DrugList[7].Price)
            {
                pictureBox8.Show();
            }
            else
                pictureBox19.Show();

            if (PriceGreen[8] > DrugList[8].Price)
            {
                pictureBox9.Show();
            }
            else
                pictureBox20.Show();

            if (PriceGreen[9] > DrugList[9].Price)
            {
                pictureBox10.Show();
            }
            else
                pictureBox21.Show();

            if (PriceGreen[10] > DrugList[10].Price)
            {
                pictureBox11.Show();
            }
            else
                pictureBox22.Show();
        }

        private void hidePictures()
        {
            pictureBox1.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();
            pictureBox5.Hide();
            pictureBox6.Hide();
            pictureBox7.Hide();
            pictureBox8.Hide();
            pictureBox9.Hide();
            pictureBox10.Hide();
            pictureBox11.Hide();
           
            pictureBox12.Hide();
            pictureBox13.Hide();
            pictureBox14.Hide();
            pictureBox15.Hide();
            pictureBox16.Hide();
            pictureBox17.Hide();
            pictureBox18.Hide();
            pictureBox19.Hide();
            pictureBox20.Hide();
            pictureBox21.Hide();
            pictureBox22.Hide();
        }

        private void getPriceGreen()
        {
            int WhereAt = MyPlayer.Location;

            PriceGreen[0] = BuyDrugs[WhereAt].Acid.Price;
            PriceGreen[1] = BuyDrugs[WhereAt].Cocaine.Price;
            PriceGreen[2] = BuyDrugs[WhereAt].Crack.Price;
            PriceGreen[3] = BuyDrugs[WhereAt].CrystalMeth.Price;
            PriceGreen[4] = BuyDrugs[WhereAt].Ecstasy.Price;
            PriceGreen[5] = BuyDrugs[WhereAt].Hash.Price;
            PriceGreen[6] = BuyDrugs[WhereAt].Heroin.Price;
            PriceGreen[7] = BuyDrugs[WhereAt].Mescaline.Price;
            PriceGreen[8] = BuyDrugs[WhereAt].Morphine.Price;
            PriceGreen[9] = BuyDrugs[WhereAt].Mushrooms.Price;
            PriceGreen[10] = BuyDrugs[WhereAt].Weed.Price;
        }


        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }


    }
}
