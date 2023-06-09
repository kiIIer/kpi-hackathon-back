using Idk.Application.Dtos.Task;
using Idk.Application.Models;
using Idk.Application.Services.Task;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    [Authorize]
    [HttpGet("tasks/{id:int}")]
    public async Task<TaskModel> GetTaskById(int id)
    {
        return await _taskService.GetTaskById(UserId, id);
    }
    
    [Authorize]
    [HttpGet("subjects/{subjectId:int}/tasks")]
    public async Task<IEnumerable<TaskModel>> GetTasksBySubjectId(int subjectId)
    {
        return await _taskService.GetTasksBySubjectId(subjectId, UserId);
    }

    [Authorize]
    [HttpGet("tasks")]
    public async Task<IEnumerable<TaskModel>> GetUserTasks()
    {
        return await _taskService.GetUserTasks(UserId);
    }

    [Authorize]
    [HttpPost("tasks")]
    public async Task<TaskModel> CreateTask(TaskDto dto)
    {
        return await _taskService.CreateTask(UserId, dto);
    }

    [Authorize]
    [HttpPut("tasks/{id:int}")]
    public async Task<TaskModel> UpdateTask(int id, TaskDto dto)
    {
        return await _taskService.UpdateTask(UserId, id, dto);
    }

    [Authorize]
    [HttpDelete("tasks/{id:int}")]
    public async Task DeleteTask(int id)
    {
        await _taskService.DeleteTaskById(UserId, id);
    }
}