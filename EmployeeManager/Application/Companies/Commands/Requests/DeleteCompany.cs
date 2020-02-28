using MediatR;

namespace Application.Companies.Commands.Requests
{
    public class DeleteCompany : IRequest
    {
        public int Id { get; set; }
    }
}
