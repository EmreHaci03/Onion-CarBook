using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandByIdQueryHandler : IRequestHandler<GetCarWithBrandByIdQuery, GetCarWithBrandByIdQueryResult>
    {
        private readonly ICarRepository carRepository;

        public GetCarWithBrandByIdQueryHandler(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public async Task<GetCarWithBrandByIdQueryResult> Handle(GetCarWithBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var value = carRepository.GetCarWithBrandByIdAsync(request.Id);
            return new GetCarWithBrandByIdQueryResult
            {
                Id = value.Id,
                BrandId = value.BrandId,
                BrandName = value.Brand.BrandName,
                Model = value.Model,
                MainImageUrl = value.MainImageUrl,
                Mileage = value.Mileage,
                Transmission = value.Transmission,
                Seats = value.Seats,
                LuggageCapacity = value.LuggageCapacity,
                FuelType = value.FuelType,
                DetailImageUrl = value.DetailImageUrl,
                Pricings = value.CarPricing.Select(p => new CarPricingDto
                {
                    PricingName = p.Pricing.Name,
                    Amount = p.Amount
                }).ToList()

            };
        }
    }
}
