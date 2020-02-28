using Application.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Application.Employees.Queries.Requests
{
    public class GetAllEmployees : IRequest<List<EmployeeDto>>
    {
    }
}
