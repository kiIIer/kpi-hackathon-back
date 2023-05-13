using Idk.Application.Dtos.Task;
using Idk.Application.Model;

namespace Idk.Application.Services.Task;

public interface ITaskService
{
    Task<TaskModel> GetTaskById(int? subjectId, int userId, int id);
    Task<IEnumerable<TaskModel>> GetUserTasks(int userId);
    Task<TaskModel> CreateTask(int? subjectId, int userId, TaskDto dto);
    Task<TaskModel> UpdateTask(int? subjectId, int userId, int id, TaskDto dto);
    System.Threading.Tasks.Task DeleteTaskById(int? subjectId, int userId, int id);
}