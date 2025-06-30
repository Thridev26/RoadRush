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
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void PlayGame_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the menu

            RacingGameForm gameForm = new RacingGameForm();
            gameForm.FormClosed += (s, args) => this.Close(); // Close menu when game ends
            gameForm.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
