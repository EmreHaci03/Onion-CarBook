using AutoMapper;
using CarBook.Application.Features.CQRS.Commands.ReservationCommands;
using CarBook.Application.Features.CQRS.Queries.ReservationQueries;
using CarBook.Application.Features.CQRS.Results.ReservationResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.IReservationInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ReservationHandlers
{
    public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery ,List<GetReservationQueryResult>>
    {
        private readonly IReservationRepository reservationRepository;

        public GetReservationQueryHandler(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }


        public async Task<List<GetReservationQueryResult>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var values = await reservationRepository.ReservationList();
            return values.Select(x => new GetReservationQueryResult
            {
                ReservationId = x.ReservationId,
                ReservationName = x.ReservationName,
                ReservationSurname = x.ReservationSurname,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                CarId = x.CarId,
                CarModel = x.Car.Brand.BrandName + " " + x.Car.Model,
                CarPricingId = x.CarPricingId,
                PricingType = x.Car.CarPricing.FirstOrDefault(p => p.Id == x.CarPricingId) ? .Pricing?.Name ?? "Bulunamadı",
                Amount = x.Amount,
                PickUpDate = x.PickUpDate,
                DropOffDate = x.DropOffDate,
                PickUpLocationId = x.PickUpLocationId,
                DropOffLocationId = x.DropOffLocationId,
                PickUpLocationName = x.PickUpLocation?.Name,
                DropOffLocationName = x.DropOffLocation?.Name,
                Age = x.Age,
                DriverLicenseYear = x.DriverLicenseYear,
                Description = x.Description,
                Status = x.Status
            }).ToList();
        }
    }
}
