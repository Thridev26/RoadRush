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
    public partial class RacingGameForm : Form
    {
        List<PictureBox> leftRoadLines = new List<PictureBox>();
        List<PictureBox> rightRoadLines = new List<PictureBox>();

        int lineWidth = 10;
        int lineHeight = 100;
        int spacing = 150; // Adjust vertical spacing as needed
        int startY = -100; // Start position above the form for looping
        int playerCarSpeed = 20;
        int enemySpeed = 2;  // You can adjust this for difficulty
        Random random = new Random();
        // Delay timers (in ticks) for each enemy spawn
        int enemy1Delay = 0;
        int enemy2Delay = 0;
        int enemy3Delay = 0;

        // Track if enemy is currently visible on screen
        bool enemy1Active = true;
        bool enemy2Active = true;
        bool enemy3Active = true;
        int leftLaneX = 157;  // Center X for left lane
        int rightLaneX = 304; // Center X for right lane
        bool moveLeft = false;
        bool moveRight = false;
        public RacingGameForm()
        {
            InitializeComponent();
            // Start enemy cars off-screen with random delays and spacing
            enemy1Active = false;
            enemy1Delay = random.Next(30, 150);
            EnemyCar1.Top = -EnemyCar1.Height * random.Next(1, 6);

            enemy2Active = false;
            enemy2Delay = random.Next(30, 150);
            EnemyCar2.Top = -EnemyCar2.Height * random.Next(1, 6);

            enemy3Active = false;
            enemy3Delay = random.Next(30, 150);
            EnemyCar3.Top = -EnemyCar3.Height * random.Next(1, 6);
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
            // Smooth player movement
            int minX = 0;
            int maxX = this.Width - PlayerCar.Width;

            if (moveLeft)
                PlayerCar.Left = Math.Max(minX, PlayerCar.Left - playerCarSpeed);

            if (moveRight)
                PlayerCar.Left = Math.Min(maxX, PlayerCar.Left + playerCarSpeed);
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

            MoveEnemyCar(EnemyCar1, ref enemy1Delay, ref enemy1Active);
            MoveEnemyCar(EnemyCar2, ref enemy2Delay, ref enemy2Active);
            MoveEnemyCar(EnemyCar3, ref enemy3Delay, ref enemy3Active);

            // Check collisions
            if (PlayerCar.Bounds.IntersectsWith(EnemyCar1.Bounds) && enemy1Active ||
                PlayerCar.Bounds.IntersectsWith(EnemyCar2.Bounds) && enemy2Active ||
                PlayerCar.Bounds.IntersectsWith(EnemyCar3.Bounds) && enemy3Active)
            {
                GameOver();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                moveLeft = true;
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                moveRight = true;

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                moveLeft = false;
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                moveRight = false;

            base.OnKeyUp(e);
        }


        private void MoveEnemyCar(PictureBox enemyCar, ref int delayCounter, ref bool isActive)
        {
            if (isActive)
            {
                enemyCar.Top += enemySpeed;
                if (enemyCar.Top > this.Height)
                {
                    // Enemy goes off screen, deactivate and set delay
                    isActive = false;
                    enemyCar.Top = -enemyCar.Height; // Move off screen

                    // Random delay between 30 and 150 ticks (~1 to 5 seconds if timer interval is 30ms)
                    delayCounter = random.Next(30, 150);
                }
            }
            else
            {
                // Waiting to respawn
                delayCounter--;
                if (delayCounter <= 0)
                {
                    // Reactivate enemy
                    isActive = true;
                    // Spawn enemy just above visible area, at the same X position (no change)
                    enemyCar.Top = -enemyCar.Height * random.Next(1, 6);
                }
            }
        }

        private void GameOver()
        {
            GameTimer.Stop();
            MessageBox.Show("Game Over! You crashed!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
