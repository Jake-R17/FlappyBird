using FlappyBird.context;
using FlappyBird.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        int scorePos = 1;

        public Form1()
        {
            // Load the form and game menu 
            InitializeComponent();
            Menu();

            // Connect to the database when starting; prevents lag spikes
            using SqliteContext lite = new SqliteContext();
            var lowestScore = lite.Highscores.OrderByDescending(x => x.Score).Select(z => z.Score).LastOrDefault();
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
                lives--;
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

            // Add the score to the total score
            endCount += scoreCount;

            // Default display upon death
            Score.Visible = false;

            RetryBtn.Visible = true;
            RetryBtn.Enabled = true;
            RetryBtn.Text = "Retry";

            // Logic behind the highscores and lives upon death
            if (lives > 0)
            {
                GameOver.Visible = true;
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
                using SqliteContext lite = new SqliteContext();
                var lowestScore = lite.Highscores.OrderByDescending(x => x.Score).Select(z => z.Score).LastOrDefault();

                if (endCount > lowestScore || lowestScore.ToString() == null || lite.Highscores.Count() <= 10)
                {
                    NewHighscore.Visible = true;
                    HighscoreName.Visible = true;
                    RetryBtn.Visible = true;
                    RetryBtn.Enabled = true;
                    RetryBtn.Text = "Submit";
                }
                else
                {
                    RetryBtn.Text = "Menu";

                    GameOver.Visible = true;
                    GameOver.Text = "GAME OVER!";
                    GameOver.ForeColor = Color.Red;
                }

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

                Start();
            }
            else
            {
                // On a new highscore, check the input
                if (NewHighscore.Visible == true)
                {
                    using SqliteContext lite = new SqliteContext();

                    if (string.IsNullOrWhiteSpace(HighscoreName.Text))
                    {
                        MessageBox.Show("Please enter a name!");
                    }
                    else if (!Regex.IsMatch(HighscoreName.Text, "^[a-zA-Z0-9]*$"))
                    {
                        MessageBox.Show("Name must be alphanumeric and cannot contain spaces!");
                    }
                    else if (HighscoreName.Text.Length > 16)
                    {
                        MessageBox.Show("Name cannot exceed 16 characters!");
                    }
                    else if (lite.Highscores.Any(x => x.Name.ToLower() == HighscoreName.Text.ToLower()))
                    {
                        MessageBox.Show("That name already exists!");
                    }
                    else
                    {
                        MessageBox.Show("Your highscore has been submitted!");

                        // Check highscores and delete the latest and lowest score
                        var lowestScore = lite.Highscores.OrderByDescending(x => x.Score).Select(z => z.Id).LastOrDefault();
                        if (lite.Highscores.Count() >= 10)
                        {
                            lite.Highscores.Remove(lite.Highscores.OrderByDescending(x => x.Id == lowestScore).FirstOrDefault());
                        }

                        // Create instance for the new highscore
                        var highscore = new Highscores
                        {
                            Name = HighscoreName.Text,
                            Score = endCount,
                            Time = DateTime.UtcNow
                        };

                        // Add the new highscore and save it to the database
                        lite.Highscores.Add(highscore);
                        lite.SaveChanges();

                        // Clear the text field
                        HighscoreName.Clear();

                        // Go to game menu
                        Menu();
                        Start();
                    }
                }
                else
                {
                    // Go to game menu
                    Menu();
                    Start();
                }
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

        private void Menu()
        {
            // Set text & object states
            Score.Visible = false;
            EndScore.Visible = false;
            RetryBtn.Visible = true;
            RetryBtn.Enabled = true;
            GameOver.Visible = true;
            HighScore.Visible = true;
            HighScore.Enabled = true;

            if (NewHighscore.Visible == true)
            {
                NewHighscore.Visible = false;
                HighscoreName.Visible = false;
            }

            GameOver.ForeColor = Color.FromArgb(119, 221, 119);

            GameOver.Text = "Flappy Bird!";
            RetryBtn.Text = "Play";
            HighScore.Text = "Highscores";

            // Reset the score and lives
            endCount = 0;
            lives = 3;
        }

        private void ResumeBtn_Click(object sender, EventArgs e)
        {
            // Leave the pause menu and start the timer
            if (HighscoreName.Visible == false)
            {
                // Resume the game and set object states
                ResumeBtn.Visible = false;
                ResumeBtn.Enabled = false;

                Paused.Visible = false;

                DefaultTimer.Start();
            }
        }

        private void HighScore_Click(object sender, EventArgs e)
        {
            // Initialize SQLite
            using SqliteContext lite = new SqliteContext();

            // Create a string builder for the highscores
            StringBuilder Highscores = new StringBuilder();

            // Order the highscores from highest - lowest
            var scoreList = lite.Highscores.OrderByDescending(x => x.Score);

            // Display each score in a visual format
            foreach (var sc in scoreList)
            {
                Highscores.AppendFormat($"{scorePos} - {sc.Name} - {sc.Score} - {sc.Time:G}\r\n");
                scorePos++;
            }
            
            // Set the state and text for the highscores textbox
            HighscoresBox.Text = Highscores.ToString();
            HighscoresBox.Visible = true;

            // Migrate any pending migrations (Only for updates)
            if (lite.Database.GetPendingMigrationsAsync().Result.Any())
            {
                lite.Database.MigrateAsync();
            }

            // Set text & object states
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
                HighscoresBox.Visible = false;
                scorePos = 1;

                HighScore.Text = "Highscores";
            }
        }
    }
}