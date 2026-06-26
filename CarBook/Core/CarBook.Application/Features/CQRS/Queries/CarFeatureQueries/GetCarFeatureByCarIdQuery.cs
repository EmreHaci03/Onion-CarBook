using CarBook.Application.Features.CQRS.Results.CarFeatureResults;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.CarFeatureQueries
{
    public class GetCarFeatureByCarIdQuery: IRequest<List<GetCarFeatureByCarIdQueryResult>>
    {
        public GetCarFeatureByCarIdQuery(int carId)
        {
            CarId = carId;
        }

        public int CarId { get; set; }
    }
}