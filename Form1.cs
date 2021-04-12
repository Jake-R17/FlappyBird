using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int gravity = 5;
        int pipeSpeed = 5;
        int scoreCount = 0;
        int lives = 3;
        int endCount = 0;
        private MySqlConnection connection;

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
                // Logic behind the random pipe height
                Random ran = new Random();
                var newHeight = ran.Next(100, 360);

                var bHeight = 630 - 170 - newHeight;

                PipeT.Height = newHeight;
                PipeB.Height = bHeight;
                PipeB.Location = new Point(700, 630 - bHeight);

                // Reset pipe location after it goes off screen
                PipeT.Left = 700;
                PipeB.Left = 700;
                scoreCount++;
            }

            // Call the EndGame method upon death
            if (FlappyBird.Bounds.IntersectsWith(PipeB.Bounds)
               || FlappyBird.Bounds.IntersectsWith(PipeT.Bounds)
               || FlappyBird.Bounds.IntersectsWith(Ground.Bounds)
               || FlappyBird.Location.Y <= 0)
            {
                EndGame();
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            // Make flappy go up; key is pressed
            if (e.KeyCode == Keys.Space)
            {
                if (DefaultTimer.Enabled == false && Score.Visible == true && ResumeBtn.Visible == false)
                {
                    DefaultTimer.Start();
                }

                gravity = -5;
            }

            // Pause menu
            if (e.KeyCode == Keys.Escape && DefaultTimer.Enabled == true)
            {
                DefaultTimer.Stop();

                ResumeBtn.Visible = true;
                ResumeBtn.Enabled = true;

                Paused.Visible = true;
            }

            // Prevent windows sounds when clicking buttons
            e.SuppressKeyPress = true;
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            // Make flappy go down; key is released
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void EndGame()
        {
            DefaultTimer.Stop();

            // Remove 1 live and add score to the total score
            lives--;
            endCount += scoreCount;

            // Default display upon death
            GameOver.Visible = true;
            Score.Visible = false;

            RetryBtn.Visible = true;
            RetryBtn.Enabled = true;
            RetryBtn.Text = "Retry";

            // Logic behind the lives text upon death
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
            // Add 1 pipespeed for every 5 score, max 10
            if (scoreCount % 5 == 0 && pipeSpeed <= 10)
            {
                pipeSpeed++;
            }
        }

        private void RetryBtn_Click(object sender, EventArgs e)
        {
            Start();

            // Logic for the objects depending on the lives
            if (lives > 0)
            {
                Score.Visible = true;
                GameOver.Visible = false;
                EndScore.Visible = false;
                RetryBtn.Visible = false;
                RetryBtn.Enabled = false;
                HighScore.Visible = false;
                HighScore.Enabled = false;
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
            // Set all objects to the default location

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

        // Default screen, shown when loading and after 3 deaths
        private void Menu()
        {
            Score.Visible = false;
            EndScore.Visible = false;
            RetryBtn.Visible = true;
            RetryBtn.Enabled = true;
            GameOver.Visible = true;
            HighScore.Visible = true;
            HighScore.Enabled = true;

            GameOver.ForeColor = Color.FromArgb(119, 221, 119);

            GameOver.Text = "Flappy Bird!";
            RetryBtn.Text = "Play";
            HighScore.Text = "Highscores";

            endCount = 0;
            lives = 3;
        }

        private void ResumeBtn_Click(object sender, EventArgs e)
        {
            // Resume the game and set object states
            ResumeBtn.Visible = false;
            ResumeBtn.Enabled = false;

            Paused.Visible = false;

            DefaultTimer.Start(); 
        }

        private void HighScore_Click(object sender, EventArgs e)
        {
            if (GameOver.Visible == true) 
            {
                RetryBtn.Visible = false;
                RetryBtn.Enabled = false;
                GameOver.Visible = false;

                HighScore.Text = "Back To Menu";
            }
            else
            {
                RetryBtn.Visible = true;
                RetryBtn.Enabled = true;
                GameOver.Visible = true;

                HighScore.Text = "Highscores";
            }
            try
            {
                InitializeDatabaseConnection();

            }
            catch
            {
                MessageBox.Show("Error: Failed connection");
            }
        }
        private void InitializeDatabaseConnection()
        {
            // Connect to the database
            string server = "localhost";
            string database = "flappybird-highscores";
            string dbUsername = "root";
            string dbPassword = "";

            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + dbUsername + ";" + "PASSWORD=" + dbPassword + ";";

            connection = new MySqlConnection(connectionString);

            OpenConnection();
        }

        private bool OpenConnection()
        {
            // Break connection, failsafe for if the connection was pre-existing
            CloseConnection();

            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}