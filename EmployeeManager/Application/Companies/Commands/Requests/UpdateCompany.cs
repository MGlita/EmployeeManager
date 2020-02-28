using Application.Dtos;
using MediatR;

namespace Application.Companies.Commands.Requests
{
    public class UpdateCompany : IRequest
    {
        public CompanyDto Company { get; set; }
    }
}
