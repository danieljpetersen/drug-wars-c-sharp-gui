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
    public partial class CombatRunLoss : Form
    {
        int AmountToBribe;
        Label OrigMoney;
        Player Stupid;
        bool CloseParent;
        public CombatRunLoss(ref Player aPlayerObject, ref Label OriginalPlayerMoney, ref bool Success)
        {
            InitializeComponent();
            OrigMoney = OriginalPlayerMoney;
            Stupid = aPlayerObject;
            CloseParent = Success;

            AmountToBribe = getPercent(aPlayerObject.Money, 20);

            if (AmountToBribe < 3000)
            {
                label1.Text = "You can't afford a bribe.";
                button1.Text = "Shit";
            }
            else
            {
                label1.Text = "It's going to cost you " + AmountToBribe;
                button1.Text = "Well, Alright.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AmountToBribe >= 3000)
            {
                Stupid.Money -= AmountToBribe;
                OrigMoney.Text = formatStringToCurrency(Stupid.Money);
                CloseParent = true;
                this.Hide();
            }
            else
            {
                CloseParent = false;
                this.Hide();
            }
        }

        private int getPercent(int Number, int PercentValue)
        {
            decimal c = (int)(((decimal)PercentValue / (decimal)100) * Number);
            return (int)c;
        }

        public string formatStringToCurrency(int NumberToStringFormat)
        {
            string NewStringValue = NumberToStringFormat.ToString("#,##0");
            NewStringValue = "$" + NewStringValue;
            return NewStringValue;
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
