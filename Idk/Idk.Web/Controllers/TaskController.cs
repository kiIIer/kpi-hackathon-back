using Idk.Application.Model;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<TaskModel> GetTaskById(int id)
    {
        return await _taskService.GetTaskById(subjectId, UserId, id);
    }

    [HttpGet]
    [Authorize]
    public async Task<IEnumerable<TaskModel>> GetUserTasks()
    {
        return await _taskService.GetUserTasks(UserId);
    }

    [HttpPost]
    [Authorize]
    public async Task<TaskModel> CreateTask()
    {
        return await _taskService.CreateTask(subjectId, UserId, dto);
    }

    [HttpPut("{id:int}")]
    [Authorize]
    public async Task<TaskModel> UpdateTask(int id)
    {
        return await _taskService.UpdateTask(subjectId, UserId, id, dto);
    }
    
    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task DeleteTask(int id)
    {
        await _taskService.DeleteTaskById(subjectId, UserId, id);
    }
}