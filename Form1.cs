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

            Score.Visible = false;
            GameOver.Visible = true;
            RetryBtn.Visible = true;
            RetryBtn.Enabled = true;

            EndScore.Visible = true;
            EndScore.Text = "Total Score: " + scoreCount;
        }

        private void RetryBtn_Click(object sender, EventArgs e)
        {
            PipeB.Left = 700;
            PipeT.Left = 700;
            scoreCount = 0;
            pipeSpeed = 5;

            Score.Visible = true;
            GameOver.Visible = false;
            EndScore.Visible = false;
            RetryBtn.Visible = false;
            RetryBtn.Enabled = false;

            FlappyBird.Location = new Point(38, 279);
            
            DefaultTimer.Start();
        }

        private void ScoreUp(object sender, EventArgs e)
        {
            if (scoreCount % 5 == 0 && pipeSpeed != 15)
            {
                pipeSpeed++;
            }
        }
    }
}
