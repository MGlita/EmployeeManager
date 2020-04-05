using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Companies.Commands.Requests;
using Application.Companies.Queries.Requests;
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
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<CompanyDto>> GetCompanies()
        {
            return await _mediator.Send(new GetAllCompanies());
        }

        [HttpPost]
        public async Task<Unit> CreateCompany(CompanyDto model)
        {
            return await _mediator.Send(new CreateCompany { Company = model });
        }

        [HttpPut]
        public async Task<Unit> UpdateCompany(CompanyDto model)
        {
            return await _mediator.Send(new UpdateCompany{Company = model});
        }

        [HttpDelete("{id}")]
        public async Task<Unit> DeleteCompany(string id)
        {
            return await _mediator.Send(new DeleteCompany { Id = int.Parse(id) });
        }
    }
}