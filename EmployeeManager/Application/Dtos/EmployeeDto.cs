using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Common.Department;

namespace Application.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public DateTime HiredDate { get; set; }
        public double Salary { get; set; }
        public DepartmentEnum Department { get; set; }
        public string JobTitle { get; set; }
        public bool IsActive { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public string ZipCode { get; set; }
    }
}
