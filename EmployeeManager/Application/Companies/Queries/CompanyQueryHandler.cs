using Application.Companies.Queries.Requests;
using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Companies.Queries
{
    public class CompanyQueryHandler : IRequestHandler<GetAllCompanies, List<CompanyDto>>
    {
        private readonly IEmployeeManagerDbContext _context;
        private readonly IMapper _mapper;

        public CompanyQueryHandler(IEmployeeManagerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CompanyDto>> Handle(GetAllCompanies request, CancellationToken cancellationToken)
        {
            var companies = await _context.Company.
                ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return companies;
        }
    }
}
