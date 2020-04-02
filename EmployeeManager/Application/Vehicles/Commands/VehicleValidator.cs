using Application.Vehicles.Commands.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Vehicles.Commands
{
    public class VehicleValidator : AbstractValidator<CreateVehicle>
    {
        public VehicleValidator()
        {
            RuleFor(x => x.Vehicle.Make).MaximumLength(50).NotNull();
            RuleFor(x => x.Vehicle.Model).MaximumLength(50);
            RuleFor(x => x.Vehicle.RegistrationNumber).MaximumLength(10).NotNull();
            RuleFor(x => x.Vehicle.ProductionYear).LessThanOrEqualTo(DateTime.Today.Year).GreaterThan(1900).NotEmpty();
            RuleFor(x => x.Vehicle.TechnicalInspectionStart).Equal(x => new DateTime(x.Vehicle.TechnicalInspectionEnd.Value.Ticks).AddYears(-1));
            RuleFor(x => x.Vehicle.TechnicalInspectionEnd).Equal(x => new DateTime(x.Vehicle.TechnicalInspectionStart.Value.Ticks).AddYears(1));
            RuleFor(x => x.Vehicle.TachographStart).Equal(x => new DateTime(x.Vehicle.TachographEnd.Value.Ticks).AddYears(-2));
            RuleFor(x => x.Vehicle.TachographEnd).Equal(x => new DateTime(x.Vehicle.TachographStart.Value.Ticks).AddYears(2));
            RuleFor(x => x.Vehicle.InsuranceOCStart).Equal(x => new DateTime(x.Vehicle.InsuranceOCEnd.Value.Ticks).AddYears(-1));
            RuleFor(x => x.Vehicle.InsuranceOCEnd).Equal(x => new DateTime(x.Vehicle.InsuranceOCStart.Value.Ticks).AddYears(1));
            RuleFor(x => x.Vehicle.InsuranceACStart).Equal(x => new DateTime(x.Vehicle.InsuranceACEnd.Value.Ticks).AddYears(-1));
            RuleFor(x => x.Vehicle.InsuranceACEnd).Equal(x => new DateTime(x.Vehicle.InsuranceACStart.Value.Ticks).AddYears(1));
        }
    }
}
