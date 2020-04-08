using Application.Vehicles.Commands.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Vehicles.Commands
{
    public class VehicleUpdateValidator : AbstractValidator<UpdateVehicle>
    {
        public VehicleUpdateValidator()
        {
            RuleFor(x => x.Make).MaximumLength(50).NotNull();
            RuleFor(x => x.Model).MaximumLength(50);
            RuleFor(x => x.RegistrationNumber).MaximumLength(10).NotNull();
            RuleFor(x => x.ProductionYear).LessThanOrEqualTo(DateTime.Today.Year).GreaterThan(1900).NotEmpty();
            RuleFor(x => x.TechnicalInspectionStart).Equal(x => new DateTime(x.TechnicalInspectionEnd.Value.Ticks).AddYears(-1));
            RuleFor(x => x.TechnicalInspectionEnd).Equal(x => new DateTime(x.TechnicalInspectionStart.Value.Ticks).AddYears(1));
            RuleFor(x => x.TachographStart).Equal(x => new DateTime(x.TachographEnd.Value.Ticks).AddYears(-2));
            RuleFor(x => x.TachographEnd).Equal(x => new DateTime(x.TachographStart.Value.Ticks).AddYears(2));
            RuleFor(x => x.InsuranceOCStart).Equal(x => new DateTime(x.InsuranceOCEnd.Value.Ticks).AddYears(-1));
            RuleFor(x => x.InsuranceOCEnd).Equal(x => new DateTime(x.InsuranceOCStart.Value.Ticks).AddYears(1));
            RuleFor(x => x.InsuranceACStart).Equal(x => new DateTime(x.InsuranceACEnd.Value.Ticks).AddYears(-1));
            RuleFor(x => x.InsuranceACEnd).Equal(x => new DateTime(x.InsuranceACStart.Value.Ticks).AddYears(1));
        }
    }
}
