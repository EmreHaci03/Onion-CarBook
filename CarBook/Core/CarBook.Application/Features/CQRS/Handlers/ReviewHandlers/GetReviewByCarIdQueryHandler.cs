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
    public class GetReviewByCarIdQueryHandler:IRequestHandler<GetReviewByCarIdQuery,List<GetReviewByCarIdQueryResult>>
    {
        private readonly IReviewRepository reviewRepository;

        public GetReviewByCarIdQueryHandler(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await reviewRepository.GetReviewListByCarId(request.CarId);
            if (values == null || !values.Any())
                throw new Exception("Bu Araca Ait Yorum Bulunamadı");
            return values.Select(x => new GetReviewByCarIdQueryResult
            {
                Id = x.Id,
                CarId = x.CarId,
                CarModel=x.Car.Model + " " +x.Car.Brand.BrandName,
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
