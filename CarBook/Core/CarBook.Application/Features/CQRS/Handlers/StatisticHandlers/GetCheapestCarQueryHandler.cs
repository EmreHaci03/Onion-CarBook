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
    public class GetCheapestCarQueryHandler:IRequestHandler<GetCheapestCarQuery,GetCheapestCarQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;

        public GetCheapestCarQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }

        public async Task<GetCheapestCarQueryResult> Handle(GetCheapestCarQuery request, CancellationToken cancellationToken)
        {
            var CheapestCar = await statisticRepository.GetCheapestPriceCar();
            return new GetCheapestCarQueryResult
            {
                CarName = CheapestCar.CarName,
                CheapestCarPriceDay = CheapestCar.CheapestCarPriceDay
            };
        }
    }
}
