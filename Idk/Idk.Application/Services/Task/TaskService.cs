using Idk.Application.Dependencies;
using Idk.Application.Dtos.Task;
using Idk.Application.Exceptions.Common;
using Idk.Application.Mapper.Task;
using Idk.Application.Models;
using Idk.Domain.Data;
using Idk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Idk.Application.Services.Task;
[DefaultTransientImplementation]
public class TaskService : ITaskService
{
    private readonly IdkContext _dbContext;
    private readonly ITaskMapper _taskMapper;

    public TaskService(IdkContext dbContext, ITaskMapper taskMapper)
    {
        _dbContext = dbContext;
        _taskMapper = taskMapper;
    }

    public async Task<TaskModel> GetTaskById(int? subjectId, string userId, int id)
    {
        var task = await _dbContext.Tasks
            .FirstOrDefaultAsync(t => t.Id == id && t.SubjectId == subjectId && t.UserId == userId);
        if (task is null)
        {
            throw new EntityNotFoundException(nameof(Domain.Models.Task), id);
        }

        return _taskMapper.Map(task);
    }

    public Task<IEnumerable<TaskModel>> GetHotTAsks(string userId)
    {
        return null;
    }

    public async Task<IEnumerable<TaskModel>> GetTasksBySubjectId(int subjectId, string userId)
    {
        var subject = await _dbContext.Subjects
            .Include(s => s.Tasks)
            .FirstOrDefaultAsync(s => s.Id == subjectId && s.UserId == userId);
        if (subject is null)
        {
            throw new EntityNotFoundException(nameof(Subject), subjectId);
        }
        return subject.Tasks!.Select(_taskMapper.Map);
    }

    public async Task<IEnumerable<TaskModel>> GetUserTasks(string userId)
    {
        var tasks = await _dbContext.Tasks
            .Where(t => t.UserId == userId)
            .ToListAsync();
        return tasks.Select(_taskMapper.Map);
    }

    public async Task<TaskModel> CreateTask(int? subjectId, string userId, TaskDto dto)
    {
        if (subjectId is not null)
        {
            var subject = await _dbContext.Subjects.FirstOrDefaultAsync(s => s.UserId == userId && s.Id == subjectId);
            if (subject is null)
            {
                throw new EntityNotFoundException(nameof(Subject), subjectId.Value);
            }
        }
        var taskToAdd = _taskMapper.Map(subjectId, userId, dto);
        await _dbContext.Tasks.AddAsync(taskToAdd);
        await _dbContext.SaveChangesAsync();
        return _taskMapper.Map(taskToAdd);
    }

    public async Task<TaskModel> UpdateTask(int? subjectId, string userId, int id, TaskDto dto)
    {
        var task = await _dbContext.Tasks
            .FirstOrDefaultAsync(t => t.Id == id && t.SubjectId == subjectId && t.UserId == userId);
        if (task is null)
        {
            throw new EntityNotFoundException(nameof(Domain.Models.Task), id);
        }

        _taskMapper.Map(subjectId, dto, task);
        await _dbContext.SaveChangesAsync();
        return _taskMapper.Map(task);
    }

    public async System.Threading.Tasks.Task DeleteTaskById(int? subjectId, string userId, int id)
    {
        var task = await _dbContext.Tasks
            .FirstOrDefaultAsync(t => t.Id == id && t.SubjectId == subjectId && t.UserId == userId);
        if (task is null)
        {
            throw new EntityNotFoundException(nameof(Domain.Models.Task), id);
        }

        _dbContext.Tasks.Remove(task);
        await _dbContext.SaveChangesAsync();
    }
}