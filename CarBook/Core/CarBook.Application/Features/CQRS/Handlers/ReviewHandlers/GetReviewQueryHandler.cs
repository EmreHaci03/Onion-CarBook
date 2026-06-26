using CarBook.Application.Features.CQRS.Queries.ReviewQueries;
using CarBook.Application.Features.CQRS.Results.ReviewResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.IReviewInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ReviewHandlers
{
    public class GetReviewQueryHandler : IRequestHandler<GetReviewQuery, List<GetReviewQueryResult>>
    {
        private readonly IReviewRepository reviewRepository;

        public GetReviewQueryHandler(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public async Task<List<GetReviewQueryResult>> Handle(GetReviewQuery request, CancellationToken cancellationToken)
        {
            var values = await reviewRepository.GetReviewList();
            return values.Select(x => new GetReviewQueryResult
            {
                Id = x.Id,
                CarId = x.CarId,
                CarModel = x.Car.Model + "" + x.Car.Brand.BrandName,
                ReviewerName = x.ReviewerName,
                Comment = x.Comment,
                CleanlinessRating = x.CleanlinessRating,
                ComfortRating = x.ComfortRating,
                PriceRating = x.PriceRating,
                DeliveryRating = x.DeliveryRating,
                CreatedDate = x.CreatedDate
            }).ToList();
        }
    }
}
