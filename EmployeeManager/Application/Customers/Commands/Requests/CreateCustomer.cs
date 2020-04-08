using Application.Dtos;
using MediatR;

namespace Application.Customers.Commands.Requests
{
    public class CreateCustomer : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }
    }
}
