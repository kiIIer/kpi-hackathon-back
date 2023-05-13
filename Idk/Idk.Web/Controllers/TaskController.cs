using Idk.Application.Dtos.Task;
using Idk.Application.Model;
using Idk.Application.Services.Task;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Idk.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : BaseController
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    [HttpGet("{id:int}")]
    [HttpGet("{subjectId:int}/{id:int}")]
    public async Task<TaskModel> GetTaskById(int? subjectId, int id)
    {
        return await _taskService.GetTaskById(subjectId, UserId, id);
    }

    [HttpGet]
    public async Task<IEnumerable<TaskModel>> GetUserTasks()
    {
        return await _taskService.GetUserTasks(UserId);
    }

    [HttpPost]
    [HttpPost("{subjectId:int}")]
    public async Task<TaskModel> CreateTask(TaskDto dto, int? subjectId)
    {
        return await _taskService.CreateTask(subjectId, UserId, dto);
    }

    [HttpPut("{id:int}")]
    [HttpPut("{subjectId:int}/{id:int}")]
    public async Task<TaskModel> UpdateTask(int? subjectId, int id, TaskDto dto)
    {
        return await _taskService.UpdateTask(subjectId, UserId, id, dto);
    }
    
    [HttpDelete("{id:int}")]
    [HttpDelete("{subjectId:int}/{id:int}")]
    public async Task DeleteTask(int? subjectId, int id)
    {
        await _taskService.DeleteTaskById(subjectId, UserId, id);
    }
}