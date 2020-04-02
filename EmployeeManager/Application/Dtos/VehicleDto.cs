using System;
using System.Collections.Generic;
using System.Text;
using static Domain.Common.VehicleType;

namespace Application.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public VehicleTypeEnum VehicleType { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public int ProductionYear { get; set; }
        public DateTime? TechnicalInspectionStart { get; set; }
        public DateTime? TechnicalInspectionEnd { get; set; }
        public DateTime? TachographStart { get; set; }
        public DateTime? TachographEnd { get; set; }
        public DateTime? InsuranceOCStart { get; set; }
        public DateTime? InsuranceOCEnd { get; set; }
        public DateTime? InsuranceACStart { get; set; }
        public DateTime? InsuranceACEnd { get; set; }
    }
}
