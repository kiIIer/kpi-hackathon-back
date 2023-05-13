using Idk.Application.Dtos.Subjects;

namespace Idk.Application.Model;

public class SubjectModel : SubjectDto
{
    public int Id { get; set; }
    public IEnumerable<TaskModel> Tasks { get; set; }
}