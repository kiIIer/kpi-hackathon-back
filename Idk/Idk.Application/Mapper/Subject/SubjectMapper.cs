using Idk.Application.Dependencies;
using Idk.Application.Dtos.Subjects;
using Idk.Application.Mapper.Task;
using Idk.Application.Model;

namespace Idk.Application.Mapper.Subject;
[DefaultTransientImplementation]
public class SubjectMapper : ISubjectMapper
{
    private readonly ITaskMapper _taskMapper;

    public SubjectMapper(ITaskMapper taskMapper)
    {
        _taskMapper = taskMapper;
    }

    public Domain.Models.Subject Map(SubjectDto source, int userId)
    {
        return new Domain.Models.Subject
        {
            Name = source.Name,
            Description = source.Description,
            MaxGrade = source.MaxGrade,
            Deadline = source.Deadline,
            UserId = userId
        };
    }

    public SubjectModel Map(Domain.Models.Subject source)
    {
        return new SubjectModel
        {
            Name = source.Name,
            Description = source.Description,
            MaxGrade = source.MaxGrade,
            Deadline = source.Deadline,
            Id = source.Id,
            Tasks = source.Tasks == null ? new List<TaskModel>() : source.Tasks.Select(_taskMapper.Map)
        };
    }

    public void Map(SubjectDto source, Domain.Models.Subject destination)
    {
        destination.Name = source.Name;
        destination.Description = source.Description;
        destination.Deadline = source.Deadline;
        destination.MaxGrade = source.MaxGrade;
    }
}