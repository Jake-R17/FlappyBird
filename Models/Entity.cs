using System.ComponentModel.DataAnnotations;

namespace FlappyBird.Models
{
    public abstract class Entity
    {
        [Key] public int Id { get; set; }
    }
}
