﻿
namespace RoadRush
{
    partial class RacingGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RacingGameForm));
            this.PlayerCar = new System.Windows.Forms.PictureBox();
            this.EnemyCar1 = new System.Windows.Forms.PictureBox();
            this.EnemyCar2 = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.EnemyCar3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyCar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyCar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyCar3)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayerCar
            // 
            this.PlayerCar.BackColor = System.Drawing.Color.Red;
            this.PlayerCar.Image = ((System.Drawing.Image)(resources.GetObject("PlayerCar.Image")));
            this.PlayerCar.Location = new System.Drawing.Point(325, 549);
            this.PlayerCar.Name = "PlayerCar";
            this.PlayerCar.Size = new System.Drawing.Size(50, 100);
            this.PlayerCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PlayerCar.TabIndex = 0;
            this.PlayerCar.TabStop = false;
            // 
            // EnemyCar1
            // 
            this.EnemyCar1.BackColor = System.Drawing.Color.Blue;
            this.EnemyCar1.Image = ((System.Drawing.Image)(resources.GetObject("EnemyCar1.Image")));
            this.EnemyCar1.Location = new System.Drawing.Point(132, 31);
            this.EnemyCar1.Name = "EnemyCar1";
            this.EnemyCar1.Size = new System.Drawing.Size(50, 100);
            this.EnemyCar1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EnemyCar1.TabIndex = 1;
            this.EnemyCar1.TabStop = false;
            // 
            // EnemyCar2
            // 
            this.EnemyCar2.BackColor = System.Drawing.Color.Green;
            this.EnemyCar2.Image = ((System.Drawing.Image)(resources.GetObject("EnemyCar2.Image")));
            this.EnemyCar2.Location = new System.Drawing.Point(522, 31);
            this.EnemyCar2.Name = "EnemyCar2";
            this.EnemyCar2.Size = new System.Drawing.Size(54, 100);
            this.EnemyCar2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EnemyCar2.TabIndex = 2;
            this.EnemyCar2.TabStop = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // EnemyCar3
            // 
            this.EnemyCar3.BackColor = System.Drawing.Color.DarkMagenta;
            this.EnemyCar3.Image = ((System.Drawing.Image)(resources.GetObject("EnemyCar3.Image")));
            this.EnemyCar3.Location = new System.Drawing.Point(325, 31);
            this.EnemyCar3.Name = "EnemyCar3";
            this.EnemyCar3.Size = new System.Drawing.Size(50, 100);
            this.EnemyCar3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EnemyCar3.TabIndex = 3;
            this.EnemyCar3.TabStop = false;
            // 
            // RacingGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(717, 661);
            this.Controls.Add(this.EnemyCar3);
            this.Controls.Add(this.EnemyCar2);
            this.Controls.Add(this.EnemyCar1);
            this.Controls.Add(this.PlayerCar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "RacingGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RacingGameForm";
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyCar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyCar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnemyCar3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PlayerCar;
        private System.Windows.Forms.PictureBox EnemyCar1;
        private System.Windows.Forms.PictureBox EnemyCar2;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.PictureBox EnemyCar3;
    }
}

