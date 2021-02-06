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
    public partial class DebtCollector : Form
    {
        Player Stupid;
        Label origMoney, origDebt, origHealth;
        public DebtCollector(ref Player aPlayerObject, ref Label OriginalMoney, ref Label OriginalDebt, ref Label OriginalHealth)
        {
            InitializeComponent();

            origDebt = OriginalDebt;
            origMoney = OriginalMoney;
            origHealth = OriginalHealth;

            Stupid = aPlayerObject;

            label5.Text = OriginalMoney.Text;
            label3.Text = OriginalDebt.Text;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public string formatStringToCurrency(int NumberToStringFormat)
        {
            string NewStringValue = NumberToStringFormat.ToString("#,##0");
            NewStringValue = "$" + NewStringValue;
            return NewStringValue;
        }

        private int getPercent(int Number, int PercentValue)
        {
            decimal c = (int)(((decimal)PercentValue / (decimal)100) * Number);
            return (int)c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stupid.Money -= Stupid.DebtPenaltyValue;
            Stupid.DebtPenaltyValue += 10000;

            if (Stupid.Money <= 0)
                Stupid.Money = 200;
            int NumToSubtract = getPercent(Stupid.Money, 20);
            Stupid.Money -= NumToSubtract;
            Stupid.Health = Stupid.Health / 2;
            if (Stupid.Health <= 1)
                Stupid.Health = 2;

            origMoney.Text = formatStringToCurrency(Stupid.Money);
            label5.Text = formatStringToCurrency(Stupid.Money);
            origHealth.Text = Stupid.Health.ToString() + " / " + Stupid.MaxHealth;

            DebtAction ChoiceHere = new DebtAction(0);
            ChoiceHere.StartPosition = FormStartPosition.CenterParent;
            ChoiceHere.ShowDialog(this);

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Stupid.Money >= Stupid.Debt)
            {
                Stupid.Money -= Stupid.Debt;
                Stupid.Debt = 0;
                
                origMoney.Text = formatStringToCurrency(Stupid.Money);
                origDebt.Text = formatStringToCurrency(Stupid.Debt);
                label5.Text = formatStringToCurrency(Stupid.Money);
                label3.Text = formatStringToCurrency(Stupid.Debt);

                DebtAction ChoiceHere = new DebtAction(1);
                ChoiceHere.StartPosition = FormStartPosition.CenterParent;
                ChoiceHere.ShowDialog(this);

                this.Hide();
            }
            else
            {
                DebtAction ChoiceHere = new DebtAction(2);
                ChoiceHere.StartPosition = FormStartPosition.CenterParent;
                ChoiceHere.ShowDialog(this);
            }
        }
    }
}
