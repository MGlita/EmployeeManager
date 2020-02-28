using System.Collections.Generic;

namespace Domain.Entities
{
    public class Company
    {
        public Company()
        {
            Customers = new List<Customer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public string ZipCode { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
