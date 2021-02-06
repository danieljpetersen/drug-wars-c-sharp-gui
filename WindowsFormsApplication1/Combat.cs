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
    public partial class Combat : Form
    {
        int NumberOfEnemies, HealthOfEnemy;
        BundleOfGuns EnemyWeapons = new BundleOfGuns();
        Weapon WeaponOfEnemy = new Weapon(0, 0, 0, "Default", 0);
        Player Stupid;
        Random random = new Random();
        int RunHelper, EnemiesLeft;
        Label OrigHealth, OrigMoney;
        RefBool Cops;

        public Combat(ref Player aPlayerObject, ref Label HealthLabel, ref Label WeaponLabel, ref Label VehicleLabel, ref Label OriginalMoney, ref RefBool Lose)
        {
            InitializeComponent();
            PlayerHealth.Text = "Health:  " + aPlayerObject.Health.ToString() + " / " + aPlayerObject.MaxHealth.ToString(); 
            PlayerWeapon.Text = "Weapon:  " + WeaponLabel.Text;
            PlayerVehicle.Text = "Vehicle:  " + VehicleLabel.Text;
            Stupid = aPlayerObject;
            OrigMoney = OriginalMoney;
            Cops = Lose;

            RunHelper = 0;

            OrigHealth = HealthLabel;

            
            Random random = new Random();
            if (aPlayerObject.Day <= 12)
            {
                generateEnemyWeaponNone();
            }
            else
            {
                generateEnemyWeaponWeak();
            }

            EnemiesLeft = NumberOfEnemies;
            HealthOfEnemy = 100;
            label1.Text = "Number of Enemies:  " + NumberOfEnemies.ToString();
            EnemyWeapon.Text = "Enemy Weapon:  " + WeaponOfEnemy.Name;
        }

        private void generateEnemyWeaponWeak()
        {
            random.Next(1, 5);
            NumberOfEnemies = random.Next(1, 2);
            int Temp = random.Next(1, 5);
            if (Temp == 1)
            {
                WeaponOfEnemy = EnemyWeapons.WeaponNone;
            }
            if (Temp == 2)
            {
                WeaponOfEnemy = EnemyWeapons.WeaponButterKnife;
            }
            if (Temp == 3)
            {
                WeaponOfEnemy = EnemyWeapons.WeaponHuntingKnife;
            }
            if (Temp == 4)
            {
                WeaponOfEnemy = EnemyWeapons.WeaponHandGun;
            }
            if (Temp == 5)
            {
                WeaponOfEnemy = EnemyWeapons.WeaponSlingShot;
            }
        }

        private void generateEnemyWeaponStrong()
        {
            NumberOfEnemies = random.Next(1, 5);
            int Temp = random.Next(1, 5);
            if (Temp == 1)
            {
                WeaponOfEnemy = EnemyWeapons.WeaponNone;
            }
            if (Temp == 2)
            {
                WeaponOfEnemy = EnemyWeapons.WeaponSMG;
            }
            if (Temp == 3)
            {
                WeaponOfEnemy = EnemyWeapons.WeaponHuntingKnife;
            }
            if (Temp == 4)
            {
                WeaponOfEnemy = EnemyWeapons.WeaponHandGun;
            }
            if (Temp == 5)
            {
                WeaponOfEnemy = EnemyWeapons.WeaponSlingShot;
            }
        }

        private void generateEnemyWeaponNone()
        {
           WeaponOfEnemy = EnemyWeapons.WeaponNone;
        }

        private void PlayerHealth_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EnemyWeapon_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            int Counter = 0;
            while (Counter < Stupid.PlayerWeapon.NumberOfShotsFired)
            {
                int Chance = random.Next(1, 10);

                if (Stupid.PlayerWeapon.Accuracy >= Chance)
                {
                    HealthOfEnemy -= Stupid.PlayerWeapon.Power;
                    EnemyHealth.Text = "Health:  " + HealthOfEnemy;
                    richTextBox1.Text += "\nYou did " + Stupid.PlayerWeapon.Power.ToString() + " damage!";
                }
                else
                {
                    richTextBox1.Text += "\nYou missed!";
                }

                Counter++;
            }

            if (HealthOfEnemy > 0)
            {
                int TimesToAttack = WeaponOfEnemy.NumberOfShotsFired;
                Counter = 0;
                while (Counter < TimesToAttack)
                {
                    int Chance = random.Next(1, 10);
                    if (WeaponOfEnemy.Accuracy >= Chance)
                    {
                        richTextBox1.Text += "\nOpponent attacked you for " + WeaponOfEnemy.Power.ToString() + " damage!";
                        Stupid.Health -= WeaponOfEnemy.Power;
                        PlayerHealth.Text = "Health:  " + Stupid.Health.ToString() + " / " + Stupid.MaxHealth.ToString();
                        OrigHealth.Text = Stupid.Health.ToString() + " / " + Stupid.MaxHealth.ToString();
                    }
                    else
                    {
                        richTextBox1.Text += "\nOpponent missed!";
                    }
                    Counter++;
                }
            }


            if (HealthOfEnemy <= 0)
            {
                if (NumberOfEnemies > EnemiesLeft)
                {
                    EnemiesLeft--;
                    label1.Text = "Number of Enemies:  " + EnemiesLeft.ToString();
                    richTextBox1.Text += "Got one of them!";

                    HealthOfEnemy = 100;
                    EnemyHealth.Text = "Health:  " + HealthOfEnemy.ToString();
                    generateEnemyWeaponNone();
                    EnemyWeapon.Text = "Weapon:  " + WeaponOfEnemy.Name;
                }
                else
                    this.Hide();
            }
            checkForAndHandleDeath();
        }

        private void checkForAndHandleDeath()
        {
            if (Stupid.Health <= 0)
            {
                Cops.Value = random.Next() % 2 == 0 ? true : false;
                Cops.Value = true;
                if (Cops.Value == true)
                {
                    Busted Caught = new Busted();
                    Caught.StartPosition = FormStartPosition.CenterParent;
                    Caught.ShowDialog();
                }
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int RandomChance = Stupid.PlayerVehicle.Speeds;
            int Number = random.Next(1, 10);
            if (RandomChance + RunHelper > Number)
            {
                this.Hide();
            }
            else
            {
                RunHelper++;
                richTextBox1.Text = "Shit!  You couldn't get away.";

                int TimesToAttack = WeaponOfEnemy.NumberOfShotsFired;
                int Counter = 0;
                while (Counter < TimesToAttack)
                {
                    int Chance = random.Next(1, 10);
                    if (WeaponOfEnemy.Accuracy >= Chance)
                    {
                        richTextBox1.Text += "\nOpponent attacked you for " + WeaponOfEnemy.Power.ToString() + " damage!\n";
                        Stupid.Health -= WeaponOfEnemy.Power;
                        PlayerHealth.Text = "\nHealth:  " + Stupid.Health.ToString() + " / " + Stupid.MaxHealth.ToString();
                        OrigHealth.Text = Stupid.Health.ToString() + " / " + Stupid.MaxHealth.ToString();
                    }
                    Counter++;
                }
                checkForAndHandleDeath();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void EnemyHealth_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool Close = false;
            int curMoney = Stupid.Money;
            CombatRunLoss BribeDialog = new CombatRunLoss(ref Stupid, ref OrigMoney, ref Close);
            BribeDialog.StartPosition = FormStartPosition.CenterParent;
            BribeDialog.ShowDialog(this);

            if (curMoney != Stupid.Money)
                this.Hide();
        }

        private void PlayerInfo_Enter(object sender, EventArgs e)
        {

        }

       
    }
}
