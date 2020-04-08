using Application.Employees.Commands.Requests;
using FluentValidation;
using System;

namespace Application.Employees.Commands
{
    public class EmployeeUpdateValidator : AbstractValidator<UpdateEmployee>
    {
        public EmployeeUpdateValidator()
        {
            RuleFor(x => x.Firstname).NotNull().MaximumLength(50);
            RuleFor(x => x.Surname).NotNull().MaximumLength(50);
            RuleFor(x => x.Gender).NotNull().Length(1).Matches(@"[M|F]{1}");
            RuleFor(x => x.Nationality).NotNull().MaximumLength(50);
            RuleFor(x => x.PhoneNumber).NotNull().MaximumLength(15);
            RuleFor(x => x.BirthDate).NotNull().LessThan(DateTime.Now.AddYears(-18).AddHours(1));
            RuleFor(x => x.Email).NotNull().MaximumLength(50).EmailAddress();
            RuleFor(x => x.HiredDate).NotNull().LessThan(DateTime.Now.AddDays(1));
            RuleFor(x => x.Salary).NotNull().GreaterThan(0);
            RuleFor(x => x.JobTitle).NotNull().MaximumLength(100);
            RuleFor(x => x.City).NotNull().MaximumLength(50);
            RuleFor(x => x.Street).NotNull().MaximumLength(50);
            RuleFor(x => x.StreetNo).NotNull().MaximumLength(10);
            RuleFor(x => x.ZipCode).NotNull().Length(6).Matches(@"\d{2}\-\d{3}");
        }
    }
}
