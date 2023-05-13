using System.ComponentModel.DataAnnotations;
using Idk.Domain.Models;

namespace Idk.Domain.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nickname { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        public ICollection<Subject>? Subjects { get; set; } = new List<Subject>();
    }
}
