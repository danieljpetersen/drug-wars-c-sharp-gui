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
    public partial class DoctorForm : Form
    {
        Player Stupid;
        Label OrigMoney, OrigHealth;
        public DoctorForm(ref Player aPlayerObject, ref Label OrigianlHealth, ref Label OrigianlMoney)
        {
            InitializeComponent();
            label1.Text = OrigianlHealth.Text;
            Stupid = aPlayerObject;

            OrigMoney = OrigianlMoney;
            OrigHealth = OrigianlHealth;

            if (Stupid.Health > 0)
            {
                numericHeal.Value = Stupid.MaxHealth - Stupid.Health;
                numericPrice.Value = numericHeal.Value * 50;
            }

            if (Stupid.Health <= 0)
            {
                numericHeal.Value = 0;
                numericPrice.Value = 0;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
    
        }

        private void numericHeal_ValueChanged(object sender, EventArgs e)
        {
            if ((numericHeal.Value > Stupid.Health) && (Stupid.Health >= 0))
            {
                numericHeal.Value = Stupid.MaxHealth - Stupid.Health;
            }
            if (Stupid.Health >= Stupid.MaxHealth)
                numericHeal.Value = 0;

            if (Stupid.Health <= 0)
            {
                numericHeal.Value = 0;
                numericPrice.Value = 0;
            }

            numericPrice.Value = numericHeal.Value * 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericHeal.Value > Stupid.Health)
                numericHeal.Value = Stupid.Health;
            numericPrice.Value = numericHeal.Value * 50;

            if (Stupid.Health <= 0)
            {
                numericHeal.Value = 0;
                numericPrice.Value = 0;
            }

            if ((numericPrice.Value <= Stupid.Money) && (Stupid.Health + numericHeal.Value <= Stupid.MaxHealth))
            {
                Stupid.Money -= (int)numericPrice.Value;
                Stupid.Health += (int)numericHeal.Value;

                OrigMoney.Text = formatStringToCurrency(Stupid.Money);
                label1.Text = Stupid.Health.ToString() + " / " + Stupid.MaxHealth;
               
                OrigHealth.Text = label1.Text;
                
                numericHeal.Value = 0;
                numericPrice.Value = 0;
            }
        }

        public string formatStringToCurrency(int NumberToStringFormat)
        {
            string NewStringValue = NumberToStringFormat.ToString("#,##0");
            NewStringValue = "$" + NewStringValue;
            return NewStringValue;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void numericPrice_ValueChanged(object sender, EventArgs e)
        {
         
        }

        private void DoctorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
