using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Problem2
{
    public partial class Form1 : Form
    {
        private int guessedNumber;
        private int attemptNum = 0;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Guess a number";
            var rand = new Random();
            guessedNumber = rand.Next(1, 100);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var enteredNum = 0;
            try
            {
                enteredNum = int.Parse(textBox1.Text);
            }
            catch (Exception)
            {
                return;
            }
            attemptNum++;
            if (enteredNum == guessedNumber)
            {
                guessTip.Text = "You win!!! You typed " + attemptNum + " symbols";
            } else if (enteredNum < guessedNumber)
            {
                guessTip.Text = "Guessed number is more then yours.";
            }
            else
            {
                guessTip.Text = "Guessed number is less then yours.";
            }
        }
    }
}
