using CarBook.Application.Features.CQRS.Queries.CarDescriptionQueries;
using CarBook.Application.Features.CQRS.Results.CarDescriptionResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionQueryHandler : IRequestHandler<GetCarDescriptionQuery, List<GetCarDescriptionQueryResult>>
    {
        private readonly ICarDescriptionRepository carDescriptionRepository;

        public GetCarDescriptionQueryHandler(ICarDescriptionRepository carDescriptionRepository)
        {
            this.carDescriptionRepository = carDescriptionRepository;
        }

        public async Task<List<GetCarDescriptionQueryResult>> Handle(GetCarDescriptionQuery request, CancellationToken cancellationToken)
        {
            var values = carDescriptionRepository.GetCarDescription();
            return values.Select(x => new GetCarDescriptionQueryResult
            {
                Id = x.Id,
                CarId = x.CarId,
                MainImageUrl=x.Car.MainImageUrl,
                CarModel = x.Car.Model,
                DetailDescription = x.DetailDescription
            }).ToList();
        }
    }
}
