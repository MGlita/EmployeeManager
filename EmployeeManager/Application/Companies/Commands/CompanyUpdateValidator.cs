using Application.Companies.Commands.Requests;
using FluentValidation;

namespace Application.Companies.Commands
{
    class CompanyUpdateValidator : AbstractValidator<UpdateCompany>
    {
        public CompanyUpdateValidator()
        {
            RuleFor(x => x.Company.Name).NotNull().MaximumLength(100);
            RuleFor(x => x.Company.Email).NotNull().MaximumLength(50).EmailAddress();
            RuleFor(x => x.Company.City).NotNull().Length(50);
            RuleFor(x => x.Company.Street).NotNull().Length(50);
            RuleFor(x => x.Company.StreetNo).NotNull().Length(10);
            RuleFor(x => x.Company.ZipCode).NotNull().Length(6).Matches(@"\d{2}\-\d{3}");
        }
    }
}
