using Idk.Application.Model;
using Microsoft.AspNetCore.Mvc;

namespace Idk.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectController : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<SubjectModel> GetSubjectById(int id)
    {
        return null;
    }

    [HttpGet]
    public async Task<IEnumerable<SubjectModel>> GetUserSubjects()
    {
        return null;
    }

    [HttpPost]
    public async Task<SubjectModel> CreateSubject()
    {
        return null;
    }

    [HttpPut("{id:int}")]
    public async Task<SubjectModel> UpdateSubject(int id)
    {
        return null;
    }

    [HttpDelete("{id:int}")]
    public async Task DeleteSubject()
    {
        
    }
}