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
    public class GetFuelTypeStatsQueryHandler:IRequestHandler<GetFuelTypeStatsQuery,GetFuelTypeStatsQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;

        public GetFuelTypeStatsQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }

        public Task<GetFuelTypeStatsQueryResult> Handle(GetFuelTypeStatsQuery request, CancellationToken cancellationToken)
        {
            var values = statisticRepository.GetFuelTypeStats();
            return Task.FromResult(new GetFuelTypeStatsQueryResult
            {
                FuelTypeStats=values
            });

        }
    }
}
