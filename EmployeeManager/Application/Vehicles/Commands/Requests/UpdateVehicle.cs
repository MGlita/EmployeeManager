using Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Vehicles.Commands.Requests
{
    public class UpdateVehicle : IRequest
    {
        public VehicleDto Vehicle { get; set; }
    }
}
