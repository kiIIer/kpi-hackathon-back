﻿using System.ComponentModel.DataAnnotations;

namespace Idk.Domain.Model
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Range(0, 1000)]
        public float Grade { get; set; }
        public DateTime Deadline { get; set; }
        [StringLength(100)]
        public string Theme { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
    }
}