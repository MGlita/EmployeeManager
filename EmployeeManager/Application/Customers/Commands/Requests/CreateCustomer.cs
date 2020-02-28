using Application.Dtos;
using MediatR;

namespace Application.Customers.Commands.Requests
{
    public class CreateCustomer : IRequest
    {
        public CustomerDto Customer { get; set; }
    }
}
