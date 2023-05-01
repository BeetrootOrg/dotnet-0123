using FluentValidation;

using TaskManagement.Contracts.Http;

namespace TaskManagement.Api.Validators
{
    public class AssignTaskRequestValidator : AbstractValidator<AssignTaskRequest>
    {
        public AssignTaskRequestValidator()
        {
            _ = RuleFor(x => x.Email).EmailAddress().NotNull();
        }
    }
}