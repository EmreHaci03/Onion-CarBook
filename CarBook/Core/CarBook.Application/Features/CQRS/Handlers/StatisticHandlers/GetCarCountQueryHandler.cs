using CarBook.Application.Features.CQRS.Queries.StatisticQueries;
using CarBook.Application.Features.CQRS.Results.StatisticResults;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.IStatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.StatisticHandlers
{
    public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;

        public GetCarCountQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }

        public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            var count= statisticRepository.GetCarCount();
            return new GetCarCountQueryResult
            {
                CarCount = count
            };
        }
    }
}
