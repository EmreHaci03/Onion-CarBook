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
    public class GetReservationCountQueryHandler : IRequestHandler<GetReservationCountQuery, GetReservationCountQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;

        public GetReservationCountQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }

        public async Task<GetReservationCountQueryResult> Handle(GetReservationCountQuery request, CancellationToken cancellationToken)
        {
            int values =statisticRepository.GetReservationCount();
            return new GetReservationCountQueryResult
            {
                ReservationCount = values,
            };
        }
    }
}
