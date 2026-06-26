using CarBook.Application.Features.CQRS.Queries.CarFeatureQueries;
using CarBook.Application.Features.CQRS.Results.CarFeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.ICarFeatureInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository carFeatureRepository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            this.carFeatureRepository = carFeatureRepository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await carFeatureRepository.GetByCarIdWithDetailsAsync(request.CarId);

            if (values == null || !values.Any())
                return new List<GetCarFeatureByCarIdQueryResult>();

            return values.Select(x => new GetCarFeatureByCarIdQueryResult
            {
                Id = x.Id,
                CarId = x.CarId,
                CarName = x.Car.Model,
                BrandId = x.Car.BrandId,
                BrandName = x.Car.Brand.BrandName,
                FeatureId = x.FeatureId,
                FeatureName = x.Feature.Name,
                Avaliable = x.Avaliable
            }).ToList();
        }
    }
}