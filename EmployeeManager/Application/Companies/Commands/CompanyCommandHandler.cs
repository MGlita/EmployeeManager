using Application.Companies.Commands.Requests;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Companies.Commands
{
    public class CompanyCommandHandler :IRequestHandler<CreateCompany>, IRequestHandler<UpdateCompany>, IRequestHandler<DeleteCompany>
    {
        private readonly IEmployeeManagerDbContext _context;

        public CompanyCommandHandler(IEmployeeManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateCompany request, CancellationToken cancellationToken)
        {
            var entity = new Company
            {
                Name = request.Company.Name,
                Email = request.Company.Email,
                City = request.Company.City,
                Street = request.Company.Street,
                StreetNo = request.Company.StreetNo,
                ZipCode = request.Company.ZipCode
            };

            _context.Company.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateCompany request, CancellationToken cancellationToken)
        {
            var company = await _context.Company.FindAsync(request.Company.Id);

            if (company == null) throw new Exception($"Company with id: {request.Company.Id} not found");

            company.Name = request.Company.Name;
            company.Email = request.Company.Email;
            company.City = request.Company.City;
            company.Street = request.Company.Street;
            company.StreetNo = request.Company.StreetNo;
            company.ZipCode = request.Company.ZipCode;

            _context.Company.Update(company);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteCompany request, CancellationToken cancellationToken)
        {
            var company = await _context.Company.FindAsync(request.Id);
            var companyCustCount = _context.Customer.Count(x=>x.CompanyId==request.Id);

            if (company == null) throw new Exception($"Company with id: {request.Id} not found");

            if(companyCustCount != 0) throw new Exception($"Company has {companyCustCount} employees assigned");

            _context.Company.Remove(company);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
