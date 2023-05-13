using System.ComponentModel.DataAnnotations;
using Idk.Domain.Model;
using Task = Idk.Domain.Models.Task;

namespace Idk.Domain.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
        public float MaxGrade { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public ICollection<Task>? Tasks { get; set; } = new List<Task>();
    }
}
