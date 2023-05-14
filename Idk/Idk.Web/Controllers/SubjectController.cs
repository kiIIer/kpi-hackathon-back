using Idk.Application.Dtos.Subjects;
using Idk.Application.Model;
using Idk.Application.Services.Subject;
using Microsoft.AspNetCore.Mvc;

namespace Idk.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectController : BaseController
{
    private readonly ISubjectService _subjectService;

    public SubjectController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpGet("{id:int}")]
    public async Task<SubjectModel> GetSubjectById(int id)
    {
        return await _subjectService.GetSubjectById(id, UserId);
    }

    [HttpGet]
    public async Task<IEnumerable<SubjectModel>> GetUserSubjects()
    {
        return await _subjectService.GetUserSubjects(UserId);
    }

    [HttpPost]
    public async Task<SubjectModel> CreateSubject(SubjectDto dto)
    {
        return await _subjectService.CreateSubject(dto, UserId);
    }

    [HttpPut("{id:int}")]
    public async Task<SubjectModel> UpdateSubject(int id, SubjectDto dto)
    {
        return await _subjectService.UpdateSubject(id, dto, UserId);
    }

    [HttpDelete("{id:int}")]
    public async Task DeleteSubjectById(int id)
    {
        await _subjectService.DeleteSubjectById(id, UserId);
    }
}