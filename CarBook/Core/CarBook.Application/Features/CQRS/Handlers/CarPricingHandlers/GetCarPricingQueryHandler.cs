using CarBook.Application.Features.CQRS.Queries.CarPricingQueries;
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
    public class GetCarPricingQueryHandler : IRequestHandler<GetCarPricingQuery, List<GetCarPricingQueryResult>>
    {
        private readonly ICarPricingRepository carPricingRepository;

        public GetCarPricingQueryHandler(ICarPricingRepository carPricingRepository)
        {
            this.carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingQueryResult>> Handle(GetCarPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await carPricingRepository.CarPricingWithBrand();
            return values.Select(x => new GetCarPricingQueryResult
            {
                Id = x.Id,
                CarId = x.CarId,
                CarWithModel = x.Car.Brand.BrandName + " " + x.Car.Model,
                PricingId = x.PricingId,
                PricingType = x.Pricing.Name,
                Amount = x.Amount
            }).ToList();
        }
    }
}
