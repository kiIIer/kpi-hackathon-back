using Idk.Application.Dtos.Subjects;
using Idk.Application.Models;

namespace Idk.Application.Mapper.Subject;

public interface ISubjectMapper
{
    Domain.Models.Subject Map(SubjectDto source, string userId);
    SubjectModel Map(Domain.Models.Subject source);
    void Map(SubjectDto source, Domain.Models.Subject destination);
}