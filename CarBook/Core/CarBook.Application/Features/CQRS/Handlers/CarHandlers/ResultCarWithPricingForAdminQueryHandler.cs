using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class ResultCarWithPricingForAdminQueryHandler : IRequestHandler<ResultCarWithPricingForAdminQuery, ResultCarWithPricingForAdminQueryResult>
    {
        private readonly ICarRepository carRepository;

        public ResultCarWithPricingForAdminQueryHandler(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public async Task<ResultCarWithPricingForAdminQueryResult> Handle(ResultCarWithPricingForAdminQuery request, CancellationToken cancellationToken)
        {
            var values = carRepository.ResultCarWithPricingForAdmin(request.Id);
            return new ResultCarWithPricingForAdminQueryResult
            {
                Id = request.Id,
                Pricings = values.CarPricing.Select(p => new CarPricingDto
                {
                    PricingName = p.Pricing.Name,
                    Amount = p.Amount
                }).ToList()
            };
        }
    }
}
