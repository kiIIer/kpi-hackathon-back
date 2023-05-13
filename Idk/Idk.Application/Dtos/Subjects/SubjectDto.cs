namespace Idk.Application.Dtos.Subjects;

public class SubjectDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public float MaxGrade { get; set; }
    public DateTime Deadline { get; set; }
}