using Application.Dtos;
using MediatR;

namespace Application.Customers.Commands.Requests
{
    public class UpdateCustomer : IRequest
    {
        public CustomerDto Customer { get; set; }
    }
}
