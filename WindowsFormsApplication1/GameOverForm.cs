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
    public partial class GameOverForm : Form
    {
        public GameOverForm(bool DidWeWin)
        {
            InitializeComponent();

            if (DidWeWin == true)
            {
                label1.Text = "Congratulations!  You've won the game.";
                label2.Text = "Let me know what you thought about it.";
                label3.Text = "I thank you for playing, and hope you've had fun.";
            }
            else
            {
                label1.Text = "Unfortunately you've lost.  Sorry man.";
                label2.Text = "I hope you've learned your lesson.";
                label3.Text = "Drugs are bad and will lead you to nowhere but failure.  Mkay?";
            }
        }

        private void GameOverForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
