using Idk.Application.Dtos.Task;

namespace Idk.Application.Model;

public class TaskModel : TaskDto
{
    public int Id { get; set; }
    public int? SubjectId { get; set; }
}