using FluentValidation;
using Idk.Application.Dependencies;
using Idk.Application.Dtos.Subjects;

namespace Idk.Application.Validation
{
    public class SubjectDtoValidator : AbstractValidator<SubjectDto>
    {
        public SubjectDtoValidator()
        {
            RuleFor(subject => subject.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(subject => subject.Description)
                .MaximumLength(1000);

            RuleFor(subject => subject.MaxGrade)
                .InclusiveBetween(0f, 100f);

            RuleFor(subject => subject.Deadline)
                .GreaterThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Deadline must be in the future.");
        }
    }
}
