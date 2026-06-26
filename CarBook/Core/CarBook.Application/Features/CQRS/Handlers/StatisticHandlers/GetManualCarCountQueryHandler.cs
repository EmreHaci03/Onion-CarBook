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
    public class GetManualCarCountQueryHandler : IRequestHandler<GetManualCarCountQuery, GetManualCarCountQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;

        public GetManualCarCountQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }
        public  Task<GetManualCarCountQueryResult> Handle(GetManualCarCountQuery request, CancellationToken cancellationToken)
        {
            var values =  statisticRepository.GetManualCarCount();
            return Task.FromResult(new GetManualCarCountQueryResult
            {
                ManualCarCount = values,
            });
        }
    }
}
