using Application.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Application.Companies.Queries.Requests
{
    public class GetAllCompanies : IRequest<List<CompanyDto>>
    {
    }
}
