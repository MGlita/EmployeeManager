using Application.Customers.Queries.Requests;
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

namespace Application.Customers.Queries
{
    public class CustomerQueryHandler : IRequestHandler<GetAllCustomers,List<CustomerDto>>
    {
        private readonly IEmployeeManagerDbContext _context;
        private readonly IMapper _mapper;

        public CustomerQueryHandler(IEmployeeManagerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> Handle(GetAllCustomers request, CancellationToken cancellationToken)
        {
            var customers = await _context.Customer
                .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return customers;
        }
    }
}
