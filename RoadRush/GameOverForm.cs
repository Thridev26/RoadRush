using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoadRush
{
    public partial class GameOverForm : Form
    {
        public GameOverForm()
        {
            InitializeComponent();
        }

        private void PlayAgain_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide game over screen

            RacingGameForm newGame = new RacingGameForm();
            newGame.FormClosed += (s, args) => this.Close(); // Close GameOverForm when game ends
            newGame.Show();
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            this.Hide();

            MainMenuForm menu = new MainMenuForm();
            menu.FormClosed += (s, args) => this.Close(); // Close GameOverForm when menu is closed
            menu.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
