using FinanceManagement.Contracts.Http;

using FluentValidation;

namespace FinanceManagement.Api.Validators
{
    public class UpdateAccountingValueValidator : AbstractValidator<UpdateAccountingValueRequest>
    {
        public UpdateAccountingValueValidator()
        {
            RuleFor(x => x.Value).GreaterThan(0).NotEmpty();
        }
    }
}