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
            this.ResumeBtn = new System.Windows.Forms.Button();
            this.Paused = new System.Windows.Forms.Label();
            this.HighScore = new System.Windows.Forms.Button();
            this.HighscoreName = new System.Windows.Forms.TextBox();
            this.NewHighscore = new System.Windows.Forms.Label();
            this.HighscoresBox = new System.Windows.Forms.RichTextBox();
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
            this.Ground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Ground.Image = global::FlappyBird.Properties.Resources.ground;
            this.Ground.Location = new System.Drawing.Point(-9, 630);
            this.Ground.Margin = new System.Windows.Forms.Padding(0);
            this.Ground.Name = "Ground";
            this.Ground.Size = new System.Drawing.Size(696, 61);
            this.Ground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Ground.TabIndex = 1;
            this.Ground.TabStop = false;
            // 
            // PipeT
            // 
            this.PipeT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PipeT.Image = global::FlappyBird.Properties.Resources.pipedown;
            this.PipeT.Location = new System.Drawing.Point(500, 0);
            this.PipeT.Margin = new System.Windows.Forms.Padding(0);
            this.PipeT.Name = "PipeT";
            this.PipeT.Size = new System.Drawing.Size(100, 230);
            this.PipeT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PipeT.TabIndex = 2;
            this.PipeT.TabStop = false;
            // 
            // PipeB
            // 
            this.PipeB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PipeB.Image = global::FlappyBird.Properties.Resources.pipe;
            this.PipeB.Location = new System.Drawing.Point(500, 400);
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
            this.Score.TabIndex = 4;
            this.Score.Text = "Score: 0";
            this.Score.TextChanged += new System.EventHandler(this.ScoreUp);
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
            this.GameOver.Location = new System.Drawing.Point(127, 252);
            this.GameOver.Name = "GameOver";
            this.GameOver.Size = new System.Drawing.Size(422, 79);
            this.GameOver.TabIndex = 5;
            this.GameOver.Text = "GAME OVER!";
            this.GameOver.Visible = false;
            // 
            // EndScore
            // 
            this.EndScore.AutoSize = true;
            this.EndScore.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EndScore.Location = new System.Drawing.Point(197, 331);
            this.EndScore.Name = "EndScore";
            this.EndScore.Size = new System.Drawing.Size(266, 40);
            this.EndScore.TabIndex = 6;
            this.EndScore.Text = "Total Score: -";
            this.EndScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EndScore.Visible = false;
            // 
            // RetryBtn
            // 
            this.RetryBtn.Enabled = false;
            this.RetryBtn.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RetryBtn.Location = new System.Drawing.Point(267, 388);
            this.RetryBtn.Margin = new System.Windows.Forms.Padding(0);
            this.RetryBtn.Name = "RetryBtn";
            this.RetryBtn.Size = new System.Drawing.Size(117, 44);
            this.RetryBtn.TabIndex = 7;
            this.RetryBtn.Text = "Menu";
            this.RetryBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RetryBtn.UseVisualStyleBackColor = true;
            this.RetryBtn.Visible = false;
            this.RetryBtn.Click += new System.EventHandler(this.RetryBtn_Click);
            // 
            // ResumeBtn
            // 
            this.ResumeBtn.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ResumeBtn.Location = new System.Drawing.Point(267, 315);
            this.ResumeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ResumeBtn.Name = "ResumeBtn";
            this.ResumeBtn.Size = new System.Drawing.Size(117, 43);
            this.ResumeBtn.TabIndex = 8;
            this.ResumeBtn.Text = "Resume";
            this.ResumeBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ResumeBtn.UseVisualStyleBackColor = true;
            this.ResumeBtn.Visible = false;
            this.ResumeBtn.Click += new System.EventHandler(this.ResumeBtn_Click);
            // 
            // Paused
            // 
            this.Paused.AutoSize = true;
            this.Paused.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Paused.Location = new System.Drawing.Point(213, 175);
            this.Paused.Margin = new System.Windows.Forms.Padding(0);
            this.Paused.Name = "Paused";
            this.Paused.Size = new System.Drawing.Size(250, 86);
            this.Paused.TabIndex = 9;
            this.Paused.Text = "Paused";
            this.Paused.Visible = false;
            // 
            // HighScore
            // 
            this.HighScore.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HighScore.Location = new System.Drawing.Point(233, 435);
            this.HighScore.Name = "HighScore";
            this.HighScore.Size = new System.Drawing.Size(187, 46);
            this.HighScore.TabIndex = 10;
            this.HighScore.Text = "Highscores";
            this.HighScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HighScore.UseVisualStyleBackColor = true;
            this.HighScore.Click += new System.EventHandler(this.HighScore_Click);
            // 
            // HighscoreName
            // 
            this.HighscoreName.Location = new System.Drawing.Point(233, 264);
            this.HighscoreName.Name = "HighscoreName";
            this.HighscoreName.Size = new System.Drawing.Size(187, 23);
            this.HighscoreName.TabIndex = 11;
            this.HighscoreName.Visible = false;
            // 
            // NewHighscore
            // 
            this.NewHighscore.AutoSize = true;
            this.NewHighscore.Font = new System.Drawing.Font("Segoe UI Emoji", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NewHighscore.Location = new System.Drawing.Point(142, 166);
            this.NewHighscore.Name = "NewHighscore";
            this.NewHighscore.Size = new System.Drawing.Size(377, 64);
            this.NewHighscore.TabIndex = 12;
            this.NewHighscore.Text = "New Highscore!";
            this.NewHighscore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NewHighscore.Visible = false;
            // 
            // HighscoresBox
            // 
            this.HighscoresBox.Location = new System.Drawing.Point(127, 175);
            this.HighscoresBox.Name = "HighscoresBox";
            this.HighscoresBox.ReadOnly = true;
            this.HighscoresBox.Size = new System.Drawing.Size(400, 180);
            this.HighscoresBox.TabIndex = 13;
            this.HighscoresBox.Text = "";
            this.HighscoresBox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(684, 681);
            this.Controls.Add(this.HighscoresBox);
            this.Controls.Add(this.NewHighscore);
            this.Controls.Add(this.HighscoreName);
            this.Controls.Add(this.HighScore);
            this.Controls.Add(this.Paused);
            this.Controls.Add(this.ResumeBtn);
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
        private System.Windows.Forms.Button ResumeBtn;
        private System.Windows.Forms.Label Paused;
        private System.Windows.Forms.Button HighScore;
        private System.Windows.Forms.TextBox HighscoreName;
        private System.Windows.Forms.Label NewHighscore;
        private System.Windows.Forms.RichTextBox HighscoresBox;
    }
}