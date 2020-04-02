using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Vehicles.Queries.Requests
{
    public class GetAllVehicles : IRequest<List<VehicleDto>>
    {
    }
}
