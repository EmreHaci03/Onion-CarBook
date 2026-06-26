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
    public class GetMostUsedFuelTypeQueryHandler : IRequestHandler<GetMostUsedFuelTypeQuery, GetMostUsedFuelTypeQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;

        public GetMostUsedFuelTypeQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }

        public async Task<GetMostUsedFuelTypeQueryResult> Handle(GetMostUsedFuelTypeQuery request, CancellationToken cancellationToken)
        {
            var FuelType = await statisticRepository.GetMostUsedFuelType();
            return new GetMostUsedFuelTypeQueryResult
            {
                FuelType = FuelType.FuelType,
                FuelTypeCount=FuelType.FuelTypeCount
            };
        }
    }
}
