using System.ComponentModel.DataAnnotations;

namespace DiscordBotHGuild.Models
{
    public abstract class Entity
    {
        [Key] public int Id { get; set; }
    }
}
