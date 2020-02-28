using MediatR;

namespace Application.Customers.Commands.Requests
{
    public class DeleteCustomer : IRequest
    {
        public int Id { get; set; }
    }
}
