using Idk.Application.Dtos.Task;
using Idk.Application.Model;

namespace Idk.Application.Mapper.Task;

public interface ITaskMapper
{
    Domain.Models.Task Map(TaskDto source);
    TaskModel Map(Domain.Models.Task source);
}