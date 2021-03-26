using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 5;
        int gravity = 5;
        int scoreCount = 0;
        int lives = 3;
        int endCount = 0;

        public Form1()
        {
            InitializeComponent();
            Menu();
        }

        private void DefaultTimer_Tick(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            PipeB.Left -= pipeSpeed;
            PipeT.Left -= pipeSpeed;
            Score.Text = "Score: " + scoreCount;

            if (PipeB.Left < -100 || PipeT.Left < -100)
            {
                Random ran = new Random();
                var newHeight = ran.Next(100, 360);

                var bHeight = 630 - 170 - newHeight;

                PipeT.Height = newHeight;
                PipeB.Height = bHeight;
                PipeB.Location = new Point(700, 630 - bHeight);

                PipeT.Left = 700;
                PipeB.Left = 700;
                scoreCount++;
            }

            if (FlappyBird.Bounds.IntersectsWith(PipeB.Bounds)
               || FlappyBird.Bounds.IntersectsWith(PipeT.Bounds)
               || FlappyBird.Bounds.IntersectsWith(Ground.Bounds)
               || FlappyBird.Location.Y <= 0)
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
            e.SuppressKeyPress = true;

            if (e.KeyCode == Keys.Space)
            {
                if (DefaultTimer.Enabled == false && Score.Visible == true)
                {
                    DefaultTimer.Start();
                }

                gravity = -5;
            }

            if (e.KeyCode == Keys.Escape && DefaultTimer.Enabled == true)
            {
                DefaultTimer.Stop();

                ResumeBtn.Visible = true;
                ResumeBtn.Enabled = true;

                Paused.Visible = true;
            }
        }

        private void EndGame()
        {
            DefaultTimer.Stop();

            lives--;
            endCount += scoreCount;

            GameOver.Visible = true;
            Score.Visible = false;

            RetryBtn.Visible = true;
            RetryBtn.Enabled = true;
            RetryBtn.Text = "Retry";

            if (lives > 0)
            {
                GameOver.Text = $"{lives} lives left!";

                if (lives == 2)
                {
                    GameOver.ForeColor = Color.Green;
                }
                if (lives == 1)
                {
                    GameOver.ForeColor = Color.Orange;
                }
            }
            else
            {
                RetryBtn.Text = "Menu";

                GameOver.Text = "GAME OVER!";
                GameOver.ForeColor = Color.Red;

                EndScore.Visible = true;
                EndScore.Text = "Total Score: " + endCount;
            }
        }

        private void ScoreUp(object sender, EventArgs e)
        {
            if (scoreCount % 5 == 0 && pipeSpeed <= 10)
            {
                pipeSpeed++;
            }
        }

        private void RetryBtn_MouseClick(object sender, MouseEventArgs e)
        {
            Start();

            if (lives > 0)
            {
                Score.Visible = true;
                GameOver.Visible = false;
                EndScore.Visible = false;
                RetryBtn.Visible = false;
                RetryBtn.Enabled = false;

                FlappyBird.Visible = true;
                PipeT.Visible = true;
                PipeB.Visible = true;
            }
            else
            {
                Menu();
            }
        }

        private void Start()
        {
            FlappyBird.Location = new Point(38, 279);

            scoreCount = 0;
            Score.Text = "Score: " + scoreCount;

            PipeT.Height = 230;
            PipeB.Height = 230;
            PipeT.Location = new Point(500, 0);
            PipeB.Location = new Point(500, 400);
            PipeT.Left = 500;
            PipeB.Left = 500;
            pipeSpeed = 5;
        }

        private void Menu()
        {
            Score.Visible = false;
            EndScore.Visible = false;
            RetryBtn.Visible = true;
            RetryBtn.Enabled = true;
            GameOver.Visible = true;

            GameOver.ForeColor = Color.FromArgb(119, 221, 119);

            GameOver.Text = "Flappy Bird!";
            RetryBtn.Text = "Play";

            endCount = 0;
            lives = 3;
        }

        private void ResumeBtn_Click(object sender, EventArgs e)
        {
            ResumeBtn.Enabled = false;
            ResumeBtn.Visible = false;

            Paused.Visible = false;

            DefaultTimer.Start();
        }
    }
}
