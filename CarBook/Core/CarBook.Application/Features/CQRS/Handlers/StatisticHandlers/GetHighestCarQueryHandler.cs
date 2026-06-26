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
    public class GetHighestCarQueryHandler:IRequestHandler<GetHighestCarQuery,GetHighestCarQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;

        public GetHighestCarQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }

        public async Task<GetHighestCarQueryResult> Handle(GetHighestCarQuery request, CancellationToken cancellationToken)
        {
            var HighestCarPrice = await statisticRepository.GetHighestPriceCar();
            return new GetHighestCarQueryResult
            {
                HighestPriceCarName = HighestCarPrice.CarName,
                HighestCarPriceDay = HighestCarPrice.HighestCarPriceDay
            };
        }
    }
}
