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
        public async Task<Unit> CreateVehicle(CreateVehicle model)
        {
            return await _mediator.Send(model);
        }

        [HttpPut]
        public async Task<Unit> UpdateVehicle(UpdateVehicle model)
        {
            return await _mediator.Send(model);
        }

        [HttpDelete("{id}")]
        public async Task<Unit> DeleteVehicle(int id)
        {
            return await _mediator.Send(new DeleteVehicle { Id = id });
        }
    }
}