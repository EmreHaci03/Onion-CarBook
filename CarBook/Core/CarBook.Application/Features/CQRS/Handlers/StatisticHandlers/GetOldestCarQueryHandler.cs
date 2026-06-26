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
    public class GetOldestCarQueryHandler : IRequestHandler<GetOldestCarQuery, GetOldestCarQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;

        public GetOldestCarQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }

        public async Task<GetOldestCarQueryResult> Handle(GetOldestCarQuery request, CancellationToken cancellationToken)
        {
            var values = await statisticRepository.GetOldestCarName();
            return new GetOldestCarQueryResult
            {
                BrandName = values.BrandName,
                CarModel = values.CarModel,
            };
        }
    }
}
