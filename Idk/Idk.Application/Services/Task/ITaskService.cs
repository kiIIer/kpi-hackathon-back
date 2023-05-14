using Idk.Application.Dtos.Task;
using Idk.Application.Models;

namespace Idk.Application.Services.Task;

public interface ITaskService
{
    Task<TaskModel> GetTaskById(string userId, int id);
    Task<IEnumerable<TaskModel>> GetHotTAsks(string userId);
    Task<IEnumerable<TaskModel>> GetTasksBySubjectId(int subjectId, string userId);
    Task<IEnumerable<TaskModel>> GetUserTasks(string userId);
    Task<TaskModel> CreateTask(string userId, TaskDto dto);
    Task<TaskModel> UpdateTask(string userId, int id, TaskDto dto);
    System.Threading.Tasks.Task DeleteTaskById(string userId, int id);
}