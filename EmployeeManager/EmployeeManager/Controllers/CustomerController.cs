using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Customers.Commands.Requests;
using Application.Customers.Queries.Requests;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    //[Authorize(Roles ="Sales, Marketing")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<CustomerDto>> GetCustomers()
        {
            return await _mediator.Send(new GetAllCustomers());
        }

        [HttpPost]
        public async Task<Unit> CreateCustomer(CreateCustomer model)
        {
            return await _mediator.Send(model);
        }

        [HttpPut]
        public async Task<Unit> UpdateCustomer(UpdateCustomer model)
        {
            return await _mediator.Send(model);
        }

        [HttpDelete("{id}")]
        public async Task<Unit> DeleteCustomer(int id)
        {
            return await _mediator.Send(new DeleteCustomer { Id = id });
        }
    }
}