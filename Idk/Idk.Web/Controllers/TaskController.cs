using Idk.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Idk.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : BaseController
{
    [HttpGet("{id:int}")]
    public async Task<TaskModel> GetTaskById(int id)
    {
        return null;
    }

    [HttpGet]
    public async Task<IEnumerable<TaskModel>> GetUserTasks()
    {
        return null;
    }

    [HttpPost]
    public async Task<TaskModel> CreateTask()
    {
        return null;
    }

    [HttpPut("{id:int}")]
    public async Task<TaskModel> UpdateTask(int id)
    {
        return null;
    }
    
    [HttpDelete("{id:int}")]
    public async Task DeleteTask(int id)
    {
        
    }
}