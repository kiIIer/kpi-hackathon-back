using Idk.Application.Dtos.Task;
using Idk.Application.Model;
using Idk.Application.Services.Task;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Idk.Web.Controllers;

[ApiController]
[Route("api")]
public class TaskController : BaseController
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    [HttpGet("tasks/{id:int}")]
    [HttpGet("subjects/{subjectId:int}/tasks/{id:int}")]
    public async Task<TaskModel> GetTaskById(int? subjectId, int id)
    {
        return await _taskService.GetTaskById(subjectId, UserId, id);
    }

    [HttpGet("tasks/hot")]
    public async Task<IEnumerable<TaskModel>> GetHotTasks()
    {
        return await _taskService.GetHotTAsks(UserId);
    }
    [HttpGet("tasks")]
    public async Task<IEnumerable<TaskModel>> GetUserTasks()
    {
        return await _taskService.GetUserTasks(UserId);
    }

    [HttpPost("tasks")]
    [HttpPost("subjects/{subjectId:int}/tasks")]
    public async Task<TaskModel> CreateTask(TaskDto dto, int? subjectId)
    {
        return await _taskService.CreateTask(subjectId, UserId, dto);
    }

    [HttpPut("tasks/{id:int}")]
    [HttpPut("subjects/{subjectId:int}/tasks/{id:int}")]
    public async Task<TaskModel> UpdateTask(int? subjectId, int id, TaskDto dto)
    {
        return await _taskService.UpdateTask(subjectId, UserId, id, dto);
    }
    
    [HttpDelete("tasks/{id:int}")]
    [HttpDelete("subjects/{subjectId:int}/tasks/{id:int}")]
    public async Task DeleteTask(int? subjectId, int id)
    {
        await _taskService.DeleteTaskById(subjectId, UserId, id);
    }
}