using CarBook.Application.Features.CQRS.Commands.ReviewCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ReviewHandlers
{
    public class CreateReviewCommandHandler:IRequestHandler<CreateReviewCommand>
    {
        private readonly IRepository<Review> repository;

        public CreateReviewCommandHandler(IRepository<Review> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(new Review
            {
                CarId = request.CarId,
                ReviewerName = request.ReviewerName,
                Comment = request.Comment,
                CleanlinessRating = request.CleanlinessRating,
                ComfortRating = request.ComfortRating,
                PriceRating = request.PriceRating,
                DeliveryRating = request.DeliveryRating,
                CreatedDate = DateTime.Now
            });
        }
    }
}
