using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;

public class GetCarsWithPricingsQueryHandler : IRequestHandler<GetCarWithPricingsQuery, List<GetCarWithPricingsQueryResult>>
{
    private readonly ICarRepository _repository;
    public GetCarsWithPricingsQueryHandler(ICarRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<GetCarWithPricingsQueryResult>> Handle(GetCarWithPricingsQuery request, CancellationToken cancellationToken)
    {
        var values = _repository.GetCarsWithPricings();
        return values.Select(x => new GetCarWithPricingsQueryResult
        {
            Id = x.Id,
            BrandId = x.BrandId,
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