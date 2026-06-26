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
    public class GetAutomaticCarCountQueryHandler : IRequestHandler<GetAutomaticCarCountQuery, GetAutomaticCarCountQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;

        public GetAutomaticCarCountQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }

        public  Task<GetAutomaticCarCountQueryResult> Handle(GetAutomaticCarCountQuery request, CancellationToken cancellationToken)
        {
            var values = statisticRepository.GetAutomaticCarCount();
            return Task.FromResult(new GetAutomaticCarCountQueryResult
            {
                AutomaticCarCount = values
            });
        }
    }
}
