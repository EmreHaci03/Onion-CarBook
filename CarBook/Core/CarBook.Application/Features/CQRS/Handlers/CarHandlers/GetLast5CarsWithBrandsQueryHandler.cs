using AutoMapper;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandsQueryHandler : IRequestHandler<GetLast5CarsWithBrandsQuery,List<GetLast5CarsWithBrandsQueryResult>>
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public GetLast5CarsWithBrandsQueryHandler(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetLast5CarsWithBrandsQueryResult>> Handle(GetLast5CarsWithBrandsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLast5CarsWithBrands();
            return values.Select(x => new GetLast5CarsWithBrandsQueryResult
            {
                Id = x.Id,
                BrandName = x.Brand.BrandName,
                Model = x.Model,
                MainImageUrl = x.MainImageUrl,
                Mileage = x.Mileage,
                Transmission = x.Transmission,
                Seats = x.Seats,
                LuggageCapacity = x.LuggageCapacity,
                FuelType = x.FuelType,
                DetailImageUrl = x.DetailImageUrl,
                Pricings = x.CarPricing.Select(p => new CarPricingDto
                {
                    PricingName = p.Pricing.Name,
                    Amount = p.Amount
                }).ToList()
            }).ToList();
        }
}
}