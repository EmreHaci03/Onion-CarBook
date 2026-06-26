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
    public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionByCarIdQueryResult>
    {
        private readonly ICarDescriptionRepository carDescriptionRepository;

        public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository carDescriptionRepository)
        {
            this.carDescriptionRepository = carDescriptionRepository;
        }

        public async Task<GetCarDescriptionByCarIdQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await carDescriptionRepository.GetCarDescriptionByCarId(request.CarId);
            return new GetCarDescriptionByCarIdQueryResult
            {
                Id = values.Id,
                CarId = values.CarId,
                CarModel = values.Car.Model,
                DetailDescription = values.DetailDescription
            };
        }
    }
}
