using FlappyBird.Models;
using Microsoft.EntityFrameworkCore;

namespace FlappyBird.context
{
    public class SqliteContext : DbContext
    {
        public DbSet<Highscores> Highscores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Sqlite.db");
    }
}
