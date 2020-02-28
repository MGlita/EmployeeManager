using Application.Dtos;
using MediatR;

namespace Application.Companies.Commands.Requests
{
    public class CreateCompany : IRequest
    {
        public CompanyDto Company { get; set; }
    }
}
