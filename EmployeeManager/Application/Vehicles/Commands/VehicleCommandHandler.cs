using Application.Interfaces;
using Application.Vehicles.Commands.Requests;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Vehicles.Commands
{
    public class VehicleCommandHandler : IRequestHandler<CreateVehicle>, IRequestHandler<UpdateVehicle>, IRequestHandler<DeleteVehicle>
    {
        private readonly IEmployeeManagerDbContext _context;

        public VehicleCommandHandler(IEmployeeManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateVehicle request, CancellationToken cancellationToken)
        {
            var entity = new Vehicle
            {
                VehicleType = request.Vehicle.VehicleType,
                Make = request.Vehicle.Make,
                Model = request.Vehicle.Model,
                RegistrationNumber = request.Vehicle.RegistrationNumber,
                ProductionYear = request.Vehicle.ProductionYear,
                TechnicalInspectionStart = request.Vehicle.TechnicalInspectionStart,
                TechnicalInspectionEnd = request.Vehicle.TechnicalInspectionEnd,
                TachographStart = request.Vehicle.TachographStart,
                TachographEnd = request.Vehicle.TachographEnd,
                InsuranceOCStart = request.Vehicle.InsuranceOCStart,
                InsuranceOCEnd = request.Vehicle.InsuranceOCEnd,
                InsuranceACStart = request.Vehicle.InsuranceACStart,
                InsuranceACEnd = request.Vehicle.InsuranceACEnd
            };

            _context.Vehicle.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateVehicle request, CancellationToken cancellationToken)
        {
            var vehicle = await _context.Vehicle.FindAsync(request.Vehicle.Id);

            if (vehicle == null) throw new Exception($"Vehicle with id: {request.Vehicle.Id} not found");

            vehicle.VehicleType = request.Vehicle.VehicleType;
            vehicle.Make = request.Vehicle.Make;
            vehicle.Model = request.Vehicle.Model;
            vehicle.RegistrationNumber = request.Vehicle.RegistrationNumber;
            vehicle.ProductionYear = request.Vehicle.ProductionYear;
            vehicle.TechnicalInspectionStart = request.Vehicle.TechnicalInspectionStart;
            vehicle.TechnicalInspectionEnd = request.Vehicle.TechnicalInspectionEnd;
            vehicle.TachographStart = request.Vehicle.TachographStart;
            vehicle.TachographEnd = request.Vehicle.TachographEnd;
            vehicle.InsuranceOCStart = request.Vehicle.InsuranceOCStart;
            vehicle.InsuranceOCEnd = request.Vehicle.InsuranceOCEnd;
            vehicle.InsuranceACStart = request.Vehicle.InsuranceACStart;
            vehicle.InsuranceACEnd = request.Vehicle.InsuranceACEnd;

            _context.Vehicle.Update(vehicle);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteVehicle request, CancellationToken cancellationToken)
        {
            var vehicle = _context.Vehicle.Find(request.Id);

            if(vehicle==null) throw new Exception($"Vehicle with id: {request.Id} not found");

            _context.Vehicle.Remove(vehicle);
             await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
