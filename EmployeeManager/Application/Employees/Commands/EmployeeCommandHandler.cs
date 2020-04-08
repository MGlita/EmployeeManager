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
                BirthDate = request.BirthDate,
                Department = request.Department,
                Email = request.Email,
                HiredDate = request.HiredDate,
                JobTitle = request.JobTitle,
                FirstName = request.Firstname,
                Salary = request.Salary,
                Surname = request.Surname,
                City = request.City,
                Gender = request.Gender,
                Nationality = request.Nationality,
                PhoneNumber = request.PhoneNumber,
                Street = request.Street,
                StreetNo = request.StreetNo,
                ZipCode = request.ZipCode
            };

            _context.Employees.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateEmployee request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(x=>x.Id==request.Id);

            if (employee == null) throw new Exception("Employee with id: " + request.Id + " not found");

            employee.BirthDate = request.BirthDate;
            employee.Department = request.Department;
            employee.Email = request.Email;
            employee.HiredDate = request.HiredDate;
            employee.JobTitle = request.JobTitle;
            employee.FirstName = request.Firstname;
            employee.Salary = request.Salary;
            employee.Surname = request.Surname;
            employee.City = request.City;
            employee.Gender = request.Gender;
            employee.Nationality = request.Nationality;
            employee.PhoneNumber = request.PhoneNumber;
            employee.Street = request.Street;
            employee.StreetNo = request.StreetNo;
            employee.ZipCode = request.ZipCode;

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
