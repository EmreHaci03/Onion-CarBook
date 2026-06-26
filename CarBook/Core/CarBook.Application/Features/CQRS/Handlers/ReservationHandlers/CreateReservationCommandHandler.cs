using CarBook.Application.Features.CQRS.Commands.ReservationCommands;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> repository;
        private readonly IRepository<Car> Carrepository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository, IRepository<Car> carrepository)
        {
            this.repository = repository;
            Carrepository = carrepository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var values = await Carrepository.GetByIdAsync(request.CarId);
            if (values == null)
                throw new Exception("Seçilen araç bulunamadı.");

            await repository.CreateAsync(new Reservation
            {
                Age = request.Age,
                CarId = request.CarId,
                Description = request.Description,
                DriverLicenseYear = request.DriverLicenseYear,
                PickUpDate = request.PickUpDate,
                DropOffDate = request.DropOffDate,
                DropOffLocationId = request.DropOffLocationId,
                Email = request.Email,
                CarPricingId = request.CarPricingId,
                Amount = request.Amount,
                ReservationName = request.ReservationName,
                ReservationSurname = request.ReservationSurname,
                PhoneNumber = request.PhoneNumber,
                PickUpLocationId = request.PickUpLocationId,
                Status = "Rezervasyon Alındı"
            });
        }
    }
}
