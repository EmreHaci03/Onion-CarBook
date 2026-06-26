using CarBook.Application.Features.CQRS.Queries.CarPricingQueries;
using CarBook.Application.Features.CQRS.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarPricingHandlers
{
    public class GetCarPricingByCarIdQueryHandler:IRequestHandler<GetCarPricingByCarIdQuery,List<GetCarPricingByCarIdQueryResult>>
    {
        private readonly ICarPricingRepository carPricingRepository;

        public GetCarPricingByCarIdQueryHandler(ICarPricingRepository carPricingRepository)
        {
            this.carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingByCarIdQueryResult>> Handle(GetCarPricingByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await carPricingRepository.GetByCarIdAsync(request.CarId);
            if (values == null)
                throw new Exception($"{request.CarId} Numaralı Id'ye Sahip Araçla İlgili Fiyat Bulunamadı");

            return values.Select(x => new GetCarPricingByCarIdQueryResult
            {
                Id = x.Id,
                CarId = x.CarId,
                PricingId=x.PricingId,
                CarWithModel=x.Car.Brand.BrandName + "" + x.Car.Model,
                Amount = x.Amount,
                PricingType = x.Pricing.Name 
            }).ToList();
        }
    }
}
