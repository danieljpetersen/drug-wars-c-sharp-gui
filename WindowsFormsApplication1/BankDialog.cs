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
    public partial class BankDialog : Form
    {
        public Player Stupid = new Player();
        public Label LabelMoney = new Label();
        public Label LabelBank = new Label();
        public BankDialog(ref Player aPlayerObject, ref Label MoneyLabel, ref Label BankLabel)
        {
            InitializeComponent();
            Stupid = aPlayerObject;

            label4.Text = formatStringToCurrency(Stupid.Money);
            label5.Text = formatStringToCurrency(Stupid.Debt);
            label6.Text = formatStringToCurrency(Stupid.Bank);
            numericUpDown1.Value = Stupid.Bank;
            numericUpDown2.Value = Stupid.Money;

            LabelMoney = MoneyLabel;
            LabelBank = BankLabel;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        public string formatStringToCurrency(int NumberToStringFormat)
        {
            string NewStringValue = NumberToStringFormat.ToString("#,##0");
            NewStringValue = "$" + NewStringValue;
            return NewStringValue;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //withdraw
            if (numericUpDown1.Value > Stupid.Bank)
                numericUpDown1.Value = Stupid.Bank;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            //deposit
            if (numericUpDown2.Value > Stupid.Money)
                numericUpDown2.Value = Stupid.Money;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //withdraw
            if (numericUpDown1.Value > 0)
            {
                Stupid.Bank -= (int)numericUpDown1.Value;
                Stupid.Money += (int)numericUpDown1.Value;
            }

            //deposit
            if (numericUpDown2.Value > 0)
            {
                Stupid.Bank += (int)numericUpDown2.Value;
                Stupid.Money -= (int)numericUpDown2.Value;
            }

            label4.Text = formatStringToCurrency(Stupid.Money);
            label5.Text = formatStringToCurrency(Stupid.Debt);
            label6.Text = formatStringToCurrency(Stupid.Bank);
          
            numericUpDown1.Value = Stupid.Bank;
            numericUpDown2.Value = Stupid.Money;

            LabelMoney.Text = formatStringToCurrency(Stupid.Money);
            LabelBank.Text = formatStringToCurrency(Stupid.Bank);
        }
    }
}
