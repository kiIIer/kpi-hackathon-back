using Idk.Application.Dtos.Task;
using Idk.Application.Models;

namespace Idk.Application.Mapper.Task;

public interface ITaskMapper
{
    Domain.Models.Task Map(string userId, TaskDto source);
    void Map(TaskDto source, Domain.Models.Task destination);
    TaskModel Map(Domain.Models.Task source);
}