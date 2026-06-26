using CarBook.Application.Features.CQRS.Queries.CarPricingQueries;
using CarBook.Application.Features.CQRS.Results.CarDescriptionResults;
using CarBook.Application.Features.CQRS.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarPricingHandlers
{
    public class GetCarPricingByIdQueryHandler : IRequestHandler<GetCarPricingByIdQuery, GetCarPricingByIdQueryResult>
    {
        private readonly ICarPricingRepository carPricingRepository;

        public GetCarPricingByIdQueryHandler(ICarPricingRepository carPricingRepository)
        {
            this.carPricingRepository = carPricingRepository;
        }

        public async Task<GetCarPricingByIdQueryResult> Handle( GetCarPricingByIdQuery request,CancellationToken cancellationToken)
        {
            var values = await carPricingRepository.GetByIdAsync(request.Id);

            if (values == null)
                throw new Exception("Araç Bulunamadı");

            return new GetCarPricingByIdQueryResult
            {
                Id = values.Id,
                CarId = values.CarId,
                CarWithModel = values.Car.Brand.BrandName + " " + values.Car.Model,
                PricingId = values.PricingId,
                PricingType = values.Pricing.Name,
                Amount = values.Amount
            };
        }
    }
}
