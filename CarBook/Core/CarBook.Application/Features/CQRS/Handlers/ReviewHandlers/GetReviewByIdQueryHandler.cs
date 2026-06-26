using CarBook.Application.Features.CQRS.Queries.ReviewQueries;
using CarBook.Application.Features.CQRS.Results.ReviewResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.IReviewInterfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.ReviewHandlers
{
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, GetReviewByIdQueryResult>
    {
        private readonly IReviewRepository reviewRepository;

        public GetReviewByIdQueryHandler(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public async Task<GetReviewByIdQueryResult> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await reviewRepository.GetReviewWithCarById(request.Id);
            if (value == null)
                throw new Exception("Aradığınız Yorum Bulunamadı");

            return new GetReviewByIdQueryResult
            {
                Id = value.Id,
                CarId = value.CarId,
                CarModel = value.Car.Model + " " + value.Car.Brand.BrandName,
                ReviewerName = value.ReviewerName,
                Comment = value.Comment,
                CleanlinessRating = value.CleanlinessRating,
                ComfortRating = value.ComfortRating,
                PriceRating = value.PriceRating,
                DeliveryRating = value.DeliveryRating,
                CreatedDate = value.CreatedDate
            };
        }
    }
}