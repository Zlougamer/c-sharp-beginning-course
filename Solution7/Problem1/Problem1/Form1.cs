using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*


Селютин Александр
*/

namespace Problem1
{
    public partial class Form1 : Form
    {
        private int minCommandsGuess;
        private Stack<(string, string, string)> commandsHistory;
        public Form1()
        {
            InitializeComponent();
            totalCommandsNum.Text = "0";
            lblNumber.Text = "0";
            var rand = new Random();
            var randNum = rand.Next(0, 100);
            enterNum.Text = randNum.ToString();
            minCommandsGuess = calculateMinCommands(randNum);
            this.Text = "Doubler";
            commandsHistory = new Stack<(string, string, string)>();
        }

        private int calculateMinCommands(int enterNum)
        {
            int minCommands = 0;
            while (enterNum != 0)
            {
                if (enterNum % 2 == 0)
                {
                    enterNum /= 2;
                } else
                {
                    enterNum -= 1;
                }
                minCommands++;
            }

            return minCommands;
        }

        private void btnCommand_1_Click(object sender, EventArgs e)
        {
            saveHistory();
            lblNumber.Text = (int.Parse(lblNumber.Text) + 1).ToString();
            totalCommandsNum.Text = (int.Parse(totalCommandsNum.Text) + 1).ToString();

            checkGameOver();
        }

        private void btnCommand_2_Click(object sender, EventArgs e)
        {
            saveHistory();
            lblNumber.Text = (int.Parse(lblNumber.Text) * 2).ToString();
            totalCommandsNum.Text = (int.Parse(totalCommandsNum.Text) + 1).ToString();

            checkGameOver();
        }

        private void saveHistory()
        {
            var historyEntry = (lblNumber.Text, totalCommandsNum.Text, gameOver.Text);
            commandsHistory.Push(historyEntry);
        }

        private void checkGameOver()
        {
            if (enterNum.Text != lblNumber.Text)
            {
                return;
            }
            if (int.Parse(totalCommandsNum.Text) == minCommandsGuess)
            {
                gameOver.Text = "You win!!!";
            } else
            {
                gameOver.Text = "You lose... Min commands: " + minCommandsGuess;

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "0";
            totalCommandsNum.Text = "0";
            gameOver.Text = "";
        }

        private void undoBtn_Click(object sender, EventArgs e)
        {
            if (commandsHistory.Count != 0)
            {
                var historyEntry = commandsHistory.Pop();
                lblNumber.Text = historyEntry.Item1;
                totalCommandsNum.Text = historyEntry.Item2;
                gameOver.Text = historyEntry.Item3;
            }
        }
    }
}
