using Idk.Application.Dtos.Subjects;
using Idk.Application.Models;

namespace Idk.Application.Services.Subject;

public interface ISubjectService
{
    Task<SubjectModel> GetSubjectById(int id, string userId);
    Task<IEnumerable<SubjectModel>> GetUserSubjects(string userId);
    Task<SubjectModel> CreateSubject(SubjectDto dto, string userId);
    Task<SubjectModel> UpdateSubject(int id, SubjectDto dto, string userId);
    System.Threading.Tasks.Task DeleteSubjectById(int id, string userId);
}