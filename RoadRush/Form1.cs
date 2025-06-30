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
        List<PictureBox> leftRoadLines = new List<PictureBox>();
        List<PictureBox> rightRoadLines = new List<PictureBox>();

        int lineWidth = 10;
        int lineHeight = 100;
        int spacing = 150; // Adjust vertical spacing as needed
        int startY = -100; // Start position above the form for looping

        int leftLaneX = 127;  // default center X for left lane (between 114 and 210)
        int rightLaneX = 274; // default center X for right lane (between 259 and 359)
        public Form1()
        {
            InitializeComponent();            
            CreateRoadLines();

            GameTimer.Interval = 30; // or however fast you want the lines to move
            GameTimer.Tick += GameTimer_Tick;
            GameTimer.Start();
        }

        private void CreateRoadLines()
        {
            int leftLaneX = (114 + 210) / 2 - lineWidth / 2;  // Center X for left lane
            int rightLaneX = (259 + 359) / 2 - lineWidth / 2; // Center X for right lane

            int numberOfLines = 5;

            for (int i = 0; i < numberOfLines; i++)
            {
                // Left lane
                PictureBox leftLine = new PictureBox();
                leftLine.BackColor = Color.White;
                leftLine.Size = new Size(lineWidth, lineHeight);
                leftLine.Location = new Point(leftLaneX, startY + (i * spacing));
                leftLine.Name = $"LeftRoadLine{i + 1}";
                leftLine.BringToFront();
                this.Controls.Add(leftLine);
                leftRoadLines.Add(leftLine);

                // Right lane
                PictureBox rightLine = new PictureBox();
                rightLine.BackColor = Color.White;
                rightLine.Size = new Size(lineWidth, lineHeight);
                rightLine.Location = new Point(rightLaneX, startY + (i * spacing));
                rightLine.Name = $"RightRoadLine{i + 1}";
                rightLine.BringToFront();
                this.Controls.Add(rightLine);
                rightRoadLines.Add(rightLine);
            }
        }      
                
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            int speed = 10;

            foreach (var line in leftRoadLines)
            {
                line.Top += speed;
                if (line.Top > this.Height)
                {
                    line.Top = -lineHeight;
                }
            }

            foreach (var line in rightRoadLines)
            {
                line.Top += speed;
                if (line.Top > this.Height)
                {
                    line.Top = -lineHeight;
                }
            }
        }
    }
}
