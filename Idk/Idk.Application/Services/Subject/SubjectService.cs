using Idk.Application.Dependencies;
using Idk.Application.Dtos.Subjects;
using Idk.Application.Exceptions.Common;
using Idk.Application.Mapper.Subject;
using Idk.Application.Model;
using Idk.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace Idk.Application.Services.Subject;

[DefaultTransientImplementation]
public class SubjectService : ISubjectService
{
    private readonly IdkContext _dbContext;
    private readonly ISubjectMapper _subjectMapper;

    public SubjectService(IdkContext dbContext, ISubjectMapper subjectMapper)
    {
        _dbContext = dbContext;
        _subjectMapper = subjectMapper;
    }

    public async Task<SubjectModel> GetSubjectById(int id, int userId)
    {
        var subject = await GetSubject(id, userId);
        return _subjectMapper.Map(subject);
    }

    public async Task<IEnumerable<SubjectModel>> GetUserSubjects(int userId)
    {
        var subjects = await _dbContext.Subjects
            .Where(s => s.UserId == userId)
            .ToListAsync();
        return subjects.Select(_subjectMapper.Map);
    }

    public async Task<SubjectModel> CreateSubject(SubjectDto dto, int userId)
    {
        var subject = _subjectMapper.Map(dto, userId);
        await _dbContext.Subjects.AddAsync(subject);
        await _dbContext.SaveChangesAsync();
        return _subjectMapper.Map(subject);
    }

    public async Task<SubjectModel> UpdateSubject(int id, SubjectDto dto, int userId)
    {
        var subject = await GetSubject(id, userId);
        _subjectMapper.Map(dto, subject);
        await _dbContext.SaveChangesAsync();
        return _subjectMapper.Map(subject);
    }

    public async System.Threading.Tasks.Task DeleteSubjectById(int id, int userId)
    {
        var subject = await GetSubject(id, userId);
        _dbContext.Subjects.Remove(subject);
        await _dbContext.SaveChangesAsync();
    }

    private async Task<Domain.Models.Subject> GetSubject(int id, int userId)
    {
        var subject = await _dbContext.Subjects
            .FirstOrDefaultAsync(s => s.Id == id && s.UserId == userId);
        if (subject is null)
        {
            throw new EntityNotFoundException(nameof(Domain.Models.Subject), id);
        }

        return subject;
    }
}