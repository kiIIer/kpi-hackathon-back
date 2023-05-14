using Idk.Application.Dtos.Task;

namespace Idk.Application.Models;

public class TaskModel : TaskDto
{
    public int Id { get; set; }
    public int? SubjectId { get; set; }
}