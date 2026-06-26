using CarBook.Application.Features.CQRS.Queries.StatisticQueries;
using CarBook.Application.Features.CQRS.Results.StatisticResults;
using CarBook.Application.Interfaces.IStatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.StatisticHandlers
{
    public class GetHighestMileageCarQueryHandler : IRequestHandler<GetHighestMileageCarQuery, GetHighestMileageCarQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;

        public GetHighestMileageCarQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }

        public async Task<GetHighestMileageCarQueryResult> Handle(GetHighestMileageCarQuery request, CancellationToken cancellationToken)
        {
            var values = await statisticRepository.GetHighestMileageCar();
            return new GetHighestMileageCarQueryResult
            {
                HighestMileageCar = values.CarName,
                HighestMileage=values.Mileage
            };
        }
    }
}
