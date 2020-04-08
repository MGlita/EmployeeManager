using Application.Companies.Commands.Requests;
using FluentValidation;

namespace Application.Companies.Commands
{
    public class CompanyValidator : AbstractValidator<CreateCompany>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(100);
            RuleFor(x => x.Email).NotNull().MaximumLength(50).EmailAddress();
            RuleFor(x => x.City).NotNull().MaximumLength(50);
            RuleFor(x => x.Street).NotNull().MaximumLength(50);
            RuleFor(x => x.StreetNo).NotNull().MaximumLength(10);
            RuleFor(x => x.ZipCode).NotNull().Length(6).Matches(@"\d{2}\-\d{3}");
        }
    }
}
