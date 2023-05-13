using Idk.Application.Dtos.Task;
using Idk.Application.Model;

namespace Idk.Application.Mapper.Task;

public interface ITaskMapper
{
    Domain.Models.Task Map(int? subjectId, int userId, TaskDto source);
    void Map(int? subjectId, TaskDto source, Domain.Models.Task destination);
    TaskModel Map(Domain.Models.Task source);
}