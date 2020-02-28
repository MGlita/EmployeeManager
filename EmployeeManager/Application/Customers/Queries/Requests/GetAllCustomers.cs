using Application.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Application.Customers.Queries.Requests
{
    public class GetAllCustomers : IRequest<List<CustomerDto>>
    {
    }
}
