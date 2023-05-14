using Idk.Application.Dtos.Subjects;
using Idk.Application.Model;

namespace Idk.Application.Services.Subject;

public interface ISubjectService
{
    Task<SubjectModel> GetSubjectById(int id, int userId);
    Task<IEnumerable<SubjectModel>> GetUserSubjects(int userId);
    Task<SubjectModel> CreateSubject(SubjectDto dto, int userId);
    Task<SubjectModel> UpdateSubject(int id, SubjectDto dto, int userId);
    System.Threading.Tasks.Task DeleteSubjectById(int id, int userId);
}