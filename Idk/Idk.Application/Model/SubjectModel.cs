using Idk.Application.Dtos.Subjects;

namespace Idk.Application.Model;

public class SubjectModel : SubjectDto
{
    public IEnumerable<TaskModel> Tasks { get; set; }
}