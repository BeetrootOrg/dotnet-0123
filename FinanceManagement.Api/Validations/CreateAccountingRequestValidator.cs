using FluentValidation;

using AccountingManagement.Contracts.Http;

namespace FinanceManagement.Api.Validators
{
    public class CreateAccountingRequestValidator : AbstractValidator<CreateAccountingRequest>
    {
        public CreateAccountingRequestValidator()
        {
            RuleFor(x => x.Title).Length(1, 255);
            RuleFor(x => x.Value).NotEmpty().GreaterThan(-1);
        }
    }
}