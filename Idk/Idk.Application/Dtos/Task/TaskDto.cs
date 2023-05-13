using Idk.Application.Dtos.Enums;

namespace Idk.Application.Dtos.Task;

public class TaskDto
{
    public string Name { get; set; }
    public int? SubjectId { get; set; }
    public DateTime Deadline { get; set; }
    public string? Description { get; set; }
    public float MaxGrade { get; set; }
    public Status Status { get; set; } = Status.ToDo;
}