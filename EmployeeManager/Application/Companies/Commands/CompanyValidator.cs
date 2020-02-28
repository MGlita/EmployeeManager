using Application.Companies.Commands.Requests;
using FluentValidation;

namespace Application.Companies.Commands
{
    public class CompanyValidator : AbstractValidator<CreateCompany>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.Company.Name).NotNull().MaximumLength(100);
            RuleFor(x => x.Company.Email).NotNull().MaximumLength(50).EmailAddress();
            RuleFor(x => x.Company.City).NotNull().MaximumLength(50);
            RuleFor(x => x.Company.Street).NotNull().MaximumLength(50);
            RuleFor(x => x.Company.StreetNo).NotNull().MaximumLength(10);
            RuleFor(x => x.Company.ZipCode).NotNull().Length(6).Matches(@"\d{2}\-\d{3}");
        }
    }
}
