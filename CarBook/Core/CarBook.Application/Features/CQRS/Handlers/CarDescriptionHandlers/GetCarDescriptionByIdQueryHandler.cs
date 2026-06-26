using CarBook.Application.Features.CQRS.Queries.CarDescriptionQueries;
using CarBook.Application.Features.CQRS.Results.CarDescriptionResults;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using MediatR;

public class GetCarDescriptionByIdQueryHandler : IRequestHandler<GetCarDescriptionByIdQuery, GetCarDescriptionByIdQueryResult>
{
    private readonly ICarDescriptionRepository carDescriptionRepository;
    public GetCarDescriptionByIdQueryHandler(ICarDescriptionRepository carDescriptionRepository)
    {
        this.carDescriptionRepository = carDescriptionRepository;
    }
    public async Task<GetCarDescriptionByIdQueryResult> Handle(GetCarDescriptionByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await carDescriptionRepository.GetByIdAsync(request.Id);
        if (values == null)
            throw new Exception("Araç Bulunamadı");
        return new GetCarDescriptionByIdQueryResult
        {
            Id = values.Id,
            CarId = values.CarId,
            CarModel = values.Car?.Model,
            DetailDescription = values.DetailDescription
        };
    }
}