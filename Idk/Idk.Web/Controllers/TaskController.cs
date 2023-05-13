using Idk.Application.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Idk.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : BaseController
{
    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<TaskModel> GetTaskById(int id)
    {
        return null;
    }

    [HttpGet]
    [Authorize]
    public async Task<IEnumerable<TaskModel>> GetUserTasks()
    {
        return null;
    }

    [HttpPost]
    [Authorize]
    public async Task<TaskModel> CreateTask()
    {
        return null;
    }

    [HttpPut("{id:int}")]
    [Authorize]
    public async Task<TaskModel> UpdateTask(int id)
    {
        return null;
    }
    
    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task DeleteTask(int id)
    {
        
    }
}