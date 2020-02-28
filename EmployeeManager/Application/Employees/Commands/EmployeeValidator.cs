using Application.Employees.Commands.Requests;
using FluentValidation;
using System;

namespace Application.Employees.Commands
{
    public class EmployeeValidator : AbstractValidator<CreateEmployee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Employee.Firstname).NotNull().MaximumLength(50);
            RuleFor(x => x.Employee.Surname).NotNull().MaximumLength(50);
            RuleFor(x => x.Employee.Gender).NotNull().Length(1).Matches(@"[M|F]{1}");
            RuleFor(x => x.Employee.Nationality).NotNull().MaximumLength(50);
            RuleFor(x => x.Employee.PhoneNumber).NotNull().MaximumLength(15);
            RuleFor(x => x.Employee.BirthDate).NotNull().LessThan(DateTime.Now.AddYears(-18).AddHours(1));
            RuleFor(x => x.Employee.Email).NotNull().MaximumLength(50).EmailAddress();
            RuleFor(x => x.Employee.HiredDate).NotNull().LessThan(DateTime.Now.AddDays(1));
            RuleFor(x => x.Employee.Salary).NotNull().GreaterThan(0);
            RuleFor(x => x.Employee.JobTitle).NotNull().MaximumLength(100);
            RuleFor(x => x.Employee.City).NotNull().MaximumLength(50);
            RuleFor(x => x.Employee.Street).NotNull().MaximumLength(50);
            RuleFor(x => x.Employee.StreetNo).NotNull().MaximumLength(10);
            RuleFor(x => x.Employee.ZipCode).NotNull().Length(6).Matches(@"\d{2}\-\d{3}");
        }
    }
}
