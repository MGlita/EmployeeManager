using MediatR;

namespace Application.Employees.Commands.Requests
{
    public class DeleteEmployee : IRequest
    {
        public int Id { get; set; }
    }
}
