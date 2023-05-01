using FluentValidation;

using TaskManagement.Contracts.Http;

namespace TaskManagement.Api.Validators
{
    public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequest>
    {
        public CreateTaskRequestValidator()
        {
            _ = RuleFor(x => x.Title).Length(1, 255);
            _ = RuleFor(x => x.Description).NotEmpty();
        }
    }
}