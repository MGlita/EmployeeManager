using Application.Customers.Commands.Requests;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Commands
{
    public class CustomerCommandHandler : IRequestHandler<CreateCustomer>, IRequestHandler<UpdateCustomer>, IRequestHandler<DeleteCustomer>
    {
        private readonly IEmployeeManagerDbContext _context;

        public CustomerCommandHandler(IEmployeeManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateCustomer request, CancellationToken cancellationToken)
        {
            var company = await _context.Company.FindAsync(request.CompanyId);

            if (company == null) throw new Exception($"Company with id: {request.CompanyId} not found");

            var entity = new Customer
            {
                FirstName = request.FirstName,
                Surname = request.Surname,
                Email = request.Email,
                Gender = request.Gender,
                JobTitle = request.JobTitle,
                Nationality = request.Nationality,
                PhoneNumber = request.PhoneNumber,
                Company = company
            };

            _context.Customer.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateCustomer request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customer.FindAsync(request.Id);

            if (customer == null) throw new Exception($"Customer with id: {request.Id} not found");

            customer.FirstName = request.FirstName;
            customer.Surname = request.Surname;
            customer.Email = request.Email;
            customer.Gender = request.Gender;
            customer.JobTitle = request.JobTitle;
            customer.Nationality = request.Nationality;
            customer.PhoneNumber = request.PhoneNumber;
            customer.CompanyId = request.CompanyId;

            _context.Customer.Update(customer);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteCustomer request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customer.FindAsync(request.Id);

            if (customer == null) throw new Exception($"Customer with id: {request.Id} not found");

            _context.Customer.Remove(customer);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
