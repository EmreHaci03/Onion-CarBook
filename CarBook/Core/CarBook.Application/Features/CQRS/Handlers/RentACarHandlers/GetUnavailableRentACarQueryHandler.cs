using CarBook.Application.Features.CQRS.Queries.RentACarQueries;
using CarBook.Application.Features.CQRS.Results.RentACarResults;
using CarBook.Application.Interfaces.IRentACarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.RentACarHandlers
{
    public class GetUnavailableRentACarQueryHandler : IRequestHandler<GetUnavailableRentACarQuery, List<GetUnavailableRentACarQueryResult>>
    {
        private readonly IRentACarRepository rentACarRepository;

        public GetUnavailableRentACarQueryHandler(IRentACarRepository rentACarRepository)
        {
            this.rentACarRepository = rentACarRepository;
        }

        public async Task<List<GetUnavailableRentACarQueryResult>> Handle(GetUnavailableRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await rentACarRepository.GetByFilterAsync(x => x.PickUpLocationID == request.LocationId && x.IsAvaliable==false);

            if (values == null || !values.Any())
                return new List<GetUnavailableRentACarQueryResult>();

            return values.Select(x => new GetUnavailableRentACarQueryResult
            {
                CarId = x.CarID,
                CarName = x.Car.Brand.BrandName + " " + x.Car.Model,
                LocationId = x.PickUpLocationID,
                LocationName = x.PickUpLocation.Name,
                CarImageUrl = x.Car.MainImageUrl
            }).ToList();
            {
            }
        }
    }
}