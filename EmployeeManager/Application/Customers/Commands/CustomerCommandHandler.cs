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
            var company = await _context.Company.FindAsync(request.Customer.CompanyId);

            if (company == null) throw new Exception($"Company with id: {request.Customer.CompanyId} not found");

            var entity = new Customer
            {
                FirstName = request.Customer.FirstName,
                Surname = request.Customer.Surname,
                Email = request.Customer.Email,
                Gender = request.Customer.Gender,
                JobTitle = request.Customer.JobTitle,
                Nationality = request.Customer.Nationality,
                PhoneNumber = request.Customer.PhoneNumber,
                Company = company
            };

            _context.Customer.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateCustomer request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customer.FindAsync(request.Customer.Id);

            if (customer == null) throw new Exception($"Customer with id: {request.Customer.Id} not found");

            customer.FirstName = request.Customer.FirstName;
            customer.Surname = request.Customer.Surname;
            customer.Email = request.Customer.Email;
            customer.Gender = request.Customer.Gender;
            customer.JobTitle = request.Customer.JobTitle;
            customer.Nationality = request.Customer.Nationality;
            customer.PhoneNumber = request.Customer.PhoneNumber;
            customer.CompanyId = request.Customer.CompanyId;

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
