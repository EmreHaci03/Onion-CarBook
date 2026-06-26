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
    public class GetNewestCarQueryHandler : IRequestHandler<GetNewestCarQuery, GetNewestCarQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;

        public GetNewestCarQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }

        public async Task<GetNewestCarQueryResult> Handle(GetNewestCarQuery request, CancellationToken cancellationToken)
        {
            var values = await  statisticRepository.GetNewestCarName();
            return new GetNewestCarQueryResult
            {
                BrandName = values.BrandName,
                CarModel = values.CarModel,
            };
        }
    }
}
