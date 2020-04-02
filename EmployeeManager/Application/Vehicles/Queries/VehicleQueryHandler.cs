using Application.Dtos;
using Application.Interfaces;
using Application.Vehicles.Queries.Requests;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Vehicles.Queries
{
    public class VehicleQueryHandler : IRequestHandler<GetAllVehicles, List<VehicleDto>>
    {
        private readonly IEmployeeManagerDbContext _context;
        private readonly IMapper _mapper;

        public VehicleQueryHandler(IEmployeeManagerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<VehicleDto>> Handle(GetAllVehicles request, CancellationToken cancellationToken)
        {
            var vehicles = await _context.Vehicle
                .ProjectTo<VehicleDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return vehicles;
        }
    }
}
