using Application.Employees.Commands.Requests;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employees.Commands
{
    public class EmployeeCommandHandler: IRequestHandler<CreateEmployee>, IRequestHandler<UpdateEmployee>, IRequestHandler<DeleteEmployee>
    {
        private readonly IEmployeeManagerDbContext _context;

        public EmployeeCommandHandler(IEmployeeManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateEmployee request, CancellationToken cancellationToken)
        {           
            var entity = new Employee
            {
                BirthDate = request.Employee.BirthDate,
                Department = request.Employee.Department,
                Email = request.Employee.Email,
                HiredDate = request.Employee.HiredDate,
                JobTitle = request.Employee.JobTitle,
                FirstName = request.Employee.Firstname,
                Salary = request.Employee.Salary,
                Surname = request.Employee.Surname,
                City = request.Employee.City,
                Gender = request.Employee.Gender,
                Nationality = request.Employee.Nationality,
                PhoneNumber = request.Employee.PhoneNumber,
                Street = request.Employee.Street,
                StreetNo = request.Employee.StreetNo,
                ZipCode = request.Employee.ZipCode
            };

            _context.Employees.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateEmployee request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(x=>x.Id==request.Employee.Id);

            if (employee == null) throw new Exception("Employee with id: " + request.Employee.Id + " not found");

            employee.BirthDate = request.Employee.BirthDate;
            employee.Department = request.Employee.Department;
            employee.Email = request.Employee.Email;
            employee.HiredDate = request.Employee.HiredDate;
            employee.JobTitle = request.Employee.JobTitle;
            employee.FirstName = request.Employee.Firstname;
            employee.Salary = request.Employee.Salary;
            employee.Surname = request.Employee.Surname;
            employee.City = request.Employee.City;
            employee.Gender = request.Employee.Gender;
            employee.Nationality = request.Employee.Nationality;
            employee.PhoneNumber = request.Employee.PhoneNumber;
            employee.Street = request.Employee.Street;
            employee.StreetNo = request.Employee.StreetNo;
            employee.ZipCode = request.Employee.ZipCode;

            _context.Employees.Update(employee);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteEmployee request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(x=>x.Id==request.Id);

            if (employee == null) throw new Exception("Employee with id: " + request.Id + " not found");

            employee.IsActive = false;

            _context.Employees.Update(employee);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
