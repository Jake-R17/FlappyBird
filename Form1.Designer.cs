
using System.Drawing;

namespace FlappyBird
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FlappyBird = new System.Windows.Forms.PictureBox();
            this.Ground = new System.Windows.Forms.PictureBox();
            this.PipeT = new System.Windows.Forms.PictureBox();
            this.PipeB = new System.Windows.Forms.PictureBox();
            this.Score = new System.Windows.Forms.Label();
            this.DefaultTimer = new System.Windows.Forms.Timer(this.components);
            this.GameOver = new System.Windows.Forms.Label();
            this.EndScore = new System.Windows.Forms.Label();
            this.RetryBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FlappyBird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PipeT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PipeB)).BeginInit();
            this.SuspendLayout();
            // 
            // FlappyBird
            // 
            this.FlappyBird.Image = global::FlappyBird.Properties.Resources.bird;
            this.FlappyBird.Location = new System.Drawing.Point(38, 279);
            this.FlappyBird.Margin = new System.Windows.Forms.Padding(0);
            this.FlappyBird.Name = "FlappyBird";
            this.FlappyBird.Size = new System.Drawing.Size(74, 52);
            this.FlappyBird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FlappyBird.TabIndex = 0;
            this.FlappyBird.TabStop = false;
            // 
            // Ground
            // 
            this.Ground.Image = global::FlappyBird.Properties.Resources.ground;
            this.Ground.Location = new System.Drawing.Point(-9, 627);
            this.Ground.Name = "Ground";
            this.Ground.Size = new System.Drawing.Size(700, 56);
            this.Ground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Ground.TabIndex = 1;
            this.Ground.TabStop = false;
            // 
            // PipeT
            // 
            this.PipeT.Image = global::FlappyBird.Properties.Resources.pipedown;
            this.PipeT.Location = new System.Drawing.Point(508, -1);
            this.PipeT.Margin = new System.Windows.Forms.Padding(0);
            this.PipeT.Name = "PipeT";
            this.PipeT.Size = new System.Drawing.Size(100, 230);
            this.PipeT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PipeT.TabIndex = 2;
            this.PipeT.TabStop = false;
            // 
            // PipeB
            // 
            this.PipeB.Image = global::FlappyBird.Properties.Resources.pipe;
            this.PipeB.Location = new System.Drawing.Point(508, 397);
            this.PipeB.Margin = new System.Windows.Forms.Padding(0);
            this.PipeB.Name = "PipeB";
            this.PipeB.Size = new System.Drawing.Size(100, 230);
            this.PipeB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PipeB.TabIndex = 3;
            this.PipeB.TabStop = false;
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.BackColor = System.Drawing.Color.Aqua;
            this.Score.Font = new System.Drawing.Font("Rockwell", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Score.Location = new System.Drawing.Point(12, 9);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(210, 59);
            this.Score.TabIndex = 5;
            this.Score.Text = "Score: 0";
            // 
            // DefaultTimer
            // 
            this.DefaultTimer.Interval = 5;
            this.DefaultTimer.Tick += new System.EventHandler(this.DefaultTimer_Tick);
            // 
            // GameOver
            // 
            this.GameOver.AutoSize = true;
            this.GameOver.BackColor = System.Drawing.Color.Aqua;
            this.GameOver.Font = new System.Drawing.Font("Showcard Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GameOver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.GameOver.Location = new System.Drawing.Point(118, 252);
            this.GameOver.Name = "GameOver";
            this.GameOver.Size = new System.Drawing.Size(422, 79);
            this.GameOver.TabIndex = 6;
            this.GameOver.Text = "GAME OVER!";
            this.GameOver.Visible = false;
            // 
            // EndScore
            // 
            this.EndScore.AutoSize = true;
            this.EndScore.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EndScore.Location = new System.Drawing.Point(181, 331);
            this.EndScore.Name = "EndScore";
            this.EndScore.Size = new System.Drawing.Size(266, 40);
            this.EndScore.TabIndex = 7;
            this.EndScore.Text = "Total Score: -";
            this.EndScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EndScore.Visible = false;
            // 
            // RetryBtn
            // 
            this.RetryBtn.Enabled = false;
            this.RetryBtn.Font = new System.Drawing.Font("Segoe UI Emoji", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RetryBtn.Location = new System.Drawing.Point(242, 371);
            this.RetryBtn.Margin = new System.Windows.Forms.Padding(0);
            this.RetryBtn.Name = "RetryBtn";
            this.RetryBtn.Size = new System.Drawing.Size(115, 41);
            this.RetryBtn.TabIndex = 8;
            this.RetryBtn.Text = "Retry";
            this.RetryBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RetryBtn.UseVisualStyleBackColor = true;
            this.RetryBtn.Visible = false;
            this.RetryBtn.Click += new System.EventHandler(this.RetryBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(684, 681);
            this.Controls.Add(this.RetryBtn);
            this.Controls.Add(this.EndScore);
            this.Controls.Add(this.GameOver);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.PipeB);
            this.Controls.Add(this.PipeT);
            this.Controls.Add(this.Ground);
            this.Controls.Add(this.FlappyBird);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flappy Bird";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.FlappyBird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PipeT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PipeB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FlappyBird;
        private System.Windows.Forms.PictureBox Ground;
        private System.Windows.Forms.PictureBox PipeT;
        private System.Windows.Forms.PictureBox PipeB;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Timer DefaultTimer;
        private System.Windows.Forms.Label GameOver;
        private System.Windows.Forms.Label EndScore;
        private System.Windows.Forms.Button RetryBtn;
    }
}

