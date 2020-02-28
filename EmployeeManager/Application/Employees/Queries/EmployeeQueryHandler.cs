using Application.Dtos;
using Application.Employees.Queries.Requests;
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
using System.Linq;

namespace Application.Employees.Queries
{
    public class EmployeeQueryHandler : IRequestHandler<GetAllEmployees,List<EmployeeDto>>
    {
        private readonly IEmployeeManagerDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeQueryHandler(IEmployeeManagerDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }

        public async Task<List<EmployeeDto>> Handle(GetAllEmployees request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees
                .Where(x=>x.IsActive)
                .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return employees;
        }
    }
}
