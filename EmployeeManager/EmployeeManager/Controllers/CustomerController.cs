using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Customers.Commands.Requests;
using Application.Customers.Queries.Requests;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
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
        public async Task<Unit> CreateCustomer(CreateCustomer customer)
        {
            return await _mediator.Send(customer);
        }

        [HttpPut]
        public async Task<Unit> UpdateCustomer(UpdateCustomer customer)
        {
            return await _mediator.Send(customer);
        }

        [HttpDelete("{id}")]
        public async Task<Unit> DeleteCustomer(int id)
        {
            return await _mediator.Send(new DeleteCustomer { Id = id });
        }
    }
}