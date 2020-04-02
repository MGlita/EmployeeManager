using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Employees.Commands.Requests;
using Application.Employees.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    //[Authorize(Roles ="HR")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<List<EmployeeDto>> GetEmployees()
        {
            return await _mediator.Send(new GetAllEmployees());
        }

        [HttpPost]
        public async Task<Unit> CreateEmployee(CreateEmployee employee)
        {
            return await _mediator.Send(employee);
        }

        [HttpPut]
        public async Task<Unit> UpdateEmployee(UpdateEmployee employee)
        {
            return await _mediator.Send(employee);
        }

        [HttpDelete("{id}")]
        public async Task<Unit> DeleteEmployee(string id)
        {
            return await _mediator.Send(new DeleteEmployee { Id = int.Parse(id) });
        }
    }
}