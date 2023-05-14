using Idk.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Idk.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectController : ControllerBase
{
    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<SubjectModel> GetSubjectById(int id)
    {
        return null;
    }

    [HttpGet]
    [Authorize]
    public async Task<IEnumerable<SubjectModel>> GetUserSubjects()
    {
        return null;
    }

    [HttpPost]
    [Authorize]
    public async Task<SubjectModel> CreateSubject()
    {
        return null;
    }

    [HttpPut("{id:int}")]
    [Authorize]
    public async Task<SubjectModel> UpdateSubject(int id)
    {
        return null;
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task DeleteSubject()
    {
        
    }
}