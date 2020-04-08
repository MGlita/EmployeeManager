using Application.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Application.Companies.Commands.Requests
{
    public class CreateCompany : IRequest
    {
        public CreateCompany()
        {
            Customers = new List<CustomerDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public string ZipCode { get; set; }
        public List<CustomerDto> Customers { get; set; }
    }
}
