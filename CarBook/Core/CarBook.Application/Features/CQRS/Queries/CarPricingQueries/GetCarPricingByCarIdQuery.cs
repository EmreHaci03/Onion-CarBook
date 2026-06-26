using CarBook.Application.Features.CQRS.Results.CarPricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.CarPricingQueries
{
    public class GetCarPricingByCarIdQuery:IRequest<List<GetCarPricingByCarIdQueryResult>>
    {
        public GetCarPricingByCarIdQuery(int carId)
        {
            CarId = carId;
        }

        public int CarId { get; set; }
    }
}
