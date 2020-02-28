using Application.Customers.Commands.Requests;
using FluentValidation;

namespace Application.Customers.Commands
{
    public class CustomerUpdateValidator : AbstractValidator<UpdateCustomer>
    {
        public CustomerUpdateValidator()
        {
            RuleFor(x => x.Customer.FirstName).NotNull().MaximumLength(100);
            RuleFor(x => x.Customer.Surname).NotNull().MaximumLength(100);
            RuleFor(x => x.Customer.Gender).NotNull().Length(1).Matches(@"[M|F]{1}");
            RuleFor(x => x.Customer.Nationality).NotNull().MaximumLength(50);
            RuleFor(x => x.Customer.PhoneNumber).NotNull().MaximumLength(15);
            RuleFor(x => x.Customer.Email).NotNull().MaximumLength(50).EmailAddress();
            RuleFor(x => x.Customer.JobTitle).NotNull().MaximumLength(50);
            RuleFor(x => x.Customer.CompanyId).NotNull();
        }
    }
}
