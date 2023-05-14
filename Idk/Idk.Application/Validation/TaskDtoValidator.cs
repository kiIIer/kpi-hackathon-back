using Idk.Application.Dtos.Task;
using FluentValidation;
using Idk.Application.Dependencies;

namespace Idk.Application.Validation
{
    public class TaskDtoValidator : AbstractValidator<TaskDto>
    {
        public TaskDtoValidator()
        {
            RuleFor(task => task.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(task => task.Description)
                .MaximumLength(1000);

            RuleFor(task => task.Theme)
                .MaximumLength(50);

            RuleFor(task => task.Grade)
                .InclusiveBetween(0f, 100f);

            RuleFor(task => task.Deadline)
                .GreaterThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Deadline must be in the future.");

            RuleFor(task => task.Status)
                .IsInEnum();
        }
    }
}
