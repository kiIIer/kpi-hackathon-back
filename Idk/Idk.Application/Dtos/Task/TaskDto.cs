using TaskStatus = Idk.Domain.Model.TaskStatus;
namespace Idk.Application.Dtos.Task;

public class TaskDto
{
    public string Name { get; set; }
    public DateTime? Deadline { get; set; }
    public string? Description { get; set; }
    public string? Theme { get; set; }
    public float Grade { get; set; }
    public TaskStatus Status { get; set; } = TaskStatus.ToDo;
}