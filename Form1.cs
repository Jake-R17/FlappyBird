using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 5;
        int gravity = 5;
        int scoreCount = 0;
        int lives = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void DefaultTimer_Tick(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            PipeB.Left -= pipeSpeed;
            PipeT.Left -= pipeSpeed;
            Score.Text = "Score: " + scoreCount;

            if (PipeB.Left < -100 || PipeT.Left < -100)
            {
                PipeB.Left = 700;
                PipeT.Left = 700;
                scoreCount++;
            }

            if (FlappyBird.Bounds.IntersectsWith(PipeB.Bounds)
               || FlappyBird.Bounds.IntersectsWith(PipeT.Bounds)
               || FlappyBird.Bounds.IntersectsWith(Ground.Bounds))
            {
                EndGame();
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (DefaultTimer.Enabled == false && Score.Visible == true)
                {
                    DefaultTimer.Start();
                }
                gravity = -5;
            }
        }

        private void EndGame()
        {
            DefaultTimer.Stop();

            lives--;

            GameOver.Visible = true;
            Score.Visible = false;

            if (lives >= 1)
            {
                RetryBtn.Visible = true;
                RetryBtn.Enabled = true;

                if (lives == 2)
                {
                    GameOver.Text = $"{lives} lives left!";
                    GameOver.ForeColor = Color.Green;
                }
                if (lives == 1)
                {
                    GameOver.Text = $"{lives} live left!";
                    GameOver.ForeColor = Color.Orange;
                }
            }
            else
            {
                GameOver.Text = "GAME OVER!";
                GameOver.ForeColor = Color.Red;

                EndScore.Visible = true;
                EndScore.Text = "Total Score: " + scoreCount;
            }
        }

        private void ScoreUp(object sender, EventArgs e)
        {
            if (scoreCount % 1 == 0 && !(pipeSpeed >= 15))
            {
                pipeSpeed++;
            }
        }

        private void RetryBtn_MouseClick(object sender, MouseEventArgs e)
        {
            PipeB.Left = 500;
            PipeT.Left = 500;
            scoreCount = 0;
            pipeSpeed = 5;

            Score.Visible = true;
            GameOver.Visible = false;
            EndScore.Visible = false;
            RetryBtn.Visible = false;
            RetryBtn.Enabled = false;

            FlappyBird.Location = new Point(38, 279);
        }
    }
}
