using Idk.Application.Dtos.Subjects;
using Idk.Application.Model;

namespace Idk.Application.Mapper.Subject;

public interface ISubjectMapper
{
    Domain.Models.Subject Map(SubjectDto source, int userId);
    SubjectModel Map(Domain.Models.Subject source);
}