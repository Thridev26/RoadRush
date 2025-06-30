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
        int playerCarSpeed = 35;
        int enemySpeed = 1;  // You can adjust this for difficulty
        Random random = new Random();
        int leftLaneX = 157;  // Center X for left lane
        int rightLaneX = 304; // Center X for right lane
        public Form1()
        {
            InitializeComponent();
            leftLaneX = (114 + 210) / 2 - lineWidth / 2;
            rightLaneX = (259 + 359) / 2 - lineWidth / 2;
            CreateRoadLines();

            GameTimer.Interval = 30; // or however fast you want the lines to move
            GameTimer.Tick += GameTimer_Tick;
            GameTimer.Start();
        }

        private void CreateRoadLines()
        {
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
                    line.Top = -lineHeight;
            }

            foreach (var line in rightRoadLines)
            {
                line.Top += speed;
                if (line.Top > this.Height)
                    line.Top = -lineHeight;
            }

            MoveEnemyCar(EnemyCar1);
            MoveEnemyCar(EnemyCar2);
            MoveEnemyCar(EnemyCar3);

            // Check collisions
            if (PlayerCar.Bounds.IntersectsWith(EnemyCar1.Bounds) ||
                PlayerCar.Bounds.IntersectsWith(EnemyCar2.Bounds) ||
                PlayerCar.Bounds.IntersectsWith(EnemyCar3.Bounds))
            {
                GameOver();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int minX = 0;
            int maxX = this.Width - PlayerCar.Width;

            if (keyData == Keys.Left || keyData == Keys.A)
            {
                PlayerCar.Left = Math.Max(minX, PlayerCar.Left - playerCarSpeed);
                return true;  // key handled
            }
            else if (keyData == Keys.Right || keyData == Keys.D)
            {
                PlayerCar.Left = Math.Min(maxX, PlayerCar.Left + playerCarSpeed);
                return true;  // key handled
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MoveEnemyCar(PictureBox enemyCar)
        {
            enemyCar.Top += enemySpeed;

            if (enemyCar.Top > this.Height)
                enemyCar.Top = -enemyCar.Height;
        }

        private void GameOver()
        {
            GameTimer.Stop();
            MessageBox.Show("Game Over! You crashed!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
