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
    public partial class Form1 : Form
    {
        List<PictureBox> roadLines = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
        }

        private void RacingGameForm_Load(object sender, EventArgs e)
        {
            int lineCount = 6;
            int spacing = 120; // vertical gap between lines
            int startY = 0;

            for (int i = 0; i < lineCount; i++)
            {
                PictureBox line = new PictureBox();
                line.BackColor = Color.White;
                line.Size = new Size(10, 100);
                line.Location = new Point(240, startY + (i * spacing));
                line.Name = $"RoadLine{i + 1}";
                line.BringToFront();

                this.Controls.Add(line);
                roadLines.Add(line);
            }
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
