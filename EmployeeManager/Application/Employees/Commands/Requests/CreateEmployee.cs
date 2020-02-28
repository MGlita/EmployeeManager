using Application.Dtos;
using MediatR;

namespace Application.Employees.Commands.Requests
{
    public class CreateEmployee : IRequest
    {
        public EmployeeDto Employee { get; set; }
    }
}
