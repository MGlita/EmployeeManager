using Application.Dtos;
using MediatR;

namespace Application.Employees.Commands.Requests
{
    public class UpdateEmployee : IRequest
    {
        public EmployeeDto Employee { get; set; }
    }
}
