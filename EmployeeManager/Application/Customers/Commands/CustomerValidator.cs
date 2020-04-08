using Application.Customers.Commands.Requests;
using FluentValidation;

namespace Application.Customers.Commands
{
    public class CustomerValidator : AbstractValidator<CreateCustomer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName).NotNull().MaximumLength(100);
            RuleFor(x => x.Surname).NotNull().MaximumLength(100);
            RuleFor(x => x.Gender).NotNull().Length(1).Matches(@"[M|F]{1}");
            RuleFor(x => x.Nationality).NotNull().MaximumLength(50);
            RuleFor(x => x.PhoneNumber).NotNull().MaximumLength(15);
            RuleFor(x => x.Email).NotNull().MaximumLength(50).EmailAddress();
            RuleFor(x => x.JobTitle).NotNull().MaximumLength(50);
            RuleFor(x => x.CompanyId).NotNull();
        }
    }
}
