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
    public class GetMostCarBrandQueryHandler:IRequestHandler<GetMostCarBrandQuery,GetMostCarBrandQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;

        public GetMostCarBrandQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }

        public async Task<GetMostCarBrandQueryResult> Handle(GetMostCarBrandQuery request, CancellationToken cancellationToken)
        {
            var MostCar = await statisticRepository.GetMostCarBrand();
            return new GetMostCarBrandQueryResult
            {
                BrandName = MostCar.BrandName,
                CarCount = MostCar.CarCount
            };
        }
    }
}
