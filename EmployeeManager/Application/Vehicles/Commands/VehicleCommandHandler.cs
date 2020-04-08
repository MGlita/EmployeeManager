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
                VehicleType = request.VehicleType,
                Make = request.Make,
                Model = request.Model,
                RegistrationNumber = request.RegistrationNumber,
                ProductionYear = request.ProductionYear,
                TechnicalInspectionStart = request.TechnicalInspectionStart,
                TechnicalInspectionEnd = request.TechnicalInspectionEnd,
                TachographStart = request.TachographStart,
                TachographEnd = request.TachographEnd,
                InsuranceOCStart = request.InsuranceOCStart,
                InsuranceOCEnd = request.InsuranceOCEnd,
                InsuranceACStart = request.InsuranceACStart,
                InsuranceACEnd = request.InsuranceACEnd
            };

            _context.Vehicle.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateVehicle request, CancellationToken cancellationToken)
        {
            var vehicle = await _context.Vehicle.FindAsync(request.Id);

            if (vehicle == null) throw new Exception($"Vehicle with id: {request.Id} not found");

            vehicle.VehicleType = request.VehicleType;
            vehicle.Make = request.Make;
            vehicle.Model = request.Model;
            vehicle.RegistrationNumber = request.RegistrationNumber;
            vehicle.ProductionYear = request.ProductionYear;
            vehicle.TechnicalInspectionStart = request.TechnicalInspectionStart;
            vehicle.TechnicalInspectionEnd = request.TechnicalInspectionEnd;
            vehicle.TachographStart = request.TachographStart;
            vehicle.TachographEnd = request.TachographEnd;
            vehicle.InsuranceOCStart = request.InsuranceOCStart;
            vehicle.InsuranceOCEnd = request.InsuranceOCEnd;
            vehicle.InsuranceACStart = request.InsuranceACStart;
            vehicle.InsuranceACEnd = request.InsuranceACEnd;

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
