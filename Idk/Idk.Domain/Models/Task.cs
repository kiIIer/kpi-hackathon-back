﻿using System.ComponentModel.DataAnnotations;
using Idk.Domain.Model;
using TaskStatus = Idk.Domain.Model.TaskStatus;

namespace Idk.Domain.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
        [Range(0, 1000)]
        public float Grade { get; set; }
        public DateTime? Deadline { get; set; }
        [StringLength(100)]
        public string? Theme { get; set; }
        public int? UserId { get; set; }

        public TaskStatus Status { get; set; } = TaskStatus.ToDo;
        public Subject? Subject { get; set; }
        public int? SubjectId { get; set; }
    }
}
