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
    public partial class DebtAction : Form
    {
        public DebtAction(int Action)
        {
            InitializeComponent();

            if (Action == 1)
            {
                label1.Text = "You've paid the man.  He thanks you and promptly leaves";
                label2.Hide();
                label3.Hide();
            }

            else if (Action == 2)
            {
                label1.Text = "You don't have enough money....";
                label2.Hide();
                label3.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
