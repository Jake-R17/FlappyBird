using DiscordBotHGuild.Models;
using System;

namespace FlappyBird.Models
{
    public class Highscores : Entity
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime Time { get; set; }
    }
}
