using FlappyBird.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscordBotHGuild.DBContext
{
    public class SqliteContext : DbContext
    {
        public DbSet<Highscores> Highscores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Sqlite.db");
    }
}