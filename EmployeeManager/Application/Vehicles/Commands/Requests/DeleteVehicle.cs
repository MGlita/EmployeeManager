using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Vehicles.Commands.Requests
{
    public class DeleteVehicle : IRequest
    {
        public int Id { get; set; }
    }
}
