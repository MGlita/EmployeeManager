using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class CompanyDto
    {
        public CompanyDto()
        {
            Customers = new List<CustomerDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public string ZipCode { get; set; }
        public List<CustomerDto> Customers { get; set; }
    }
}
