using Idk.Domain.Dtos.Subjects;

namespace Idk.Domain.Model;

public class SubjectModel : SubjectDto
{
    public IEnumerable<TaskModel> Tasks { get; set; }
}