using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Vehicles.Commands.Requests;
using Application.Vehicles.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<VehicleDto>> GetVehicles()
        {
            return await _mediator.Send(new GetAllVehicles());
        }

        [HttpPost]
        public async Task<Unit> CreateVehicle(CreateVehicle vehicle)
        {
            return await _mediator.Send(vehicle);
        }

        [HttpPut]
        public async Task<Unit> UpdateVehicle(UpdateVehicle vehicle)
        {
            return await _mediator.Send(vehicle);
        }

        [HttpDelete("{id}")]
        public async Task<Unit> DeleteVehicle(string id)
        {
            return await _mediator.Send(new DeleteVehicle { Id = int.Parse(id) });
        }
    }
}