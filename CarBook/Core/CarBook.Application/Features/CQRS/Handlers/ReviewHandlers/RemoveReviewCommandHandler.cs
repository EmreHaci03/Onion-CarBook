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
    public class RemoveReviewCommandHandler : IRequestHandler<RemoveReviewCommand>
    {
        private readonly IRepository<Review> repository;

        public RemoveReviewCommandHandler(IRepository<Review> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(RemoveReviewCommand request, CancellationToken cancellationToken)
        {
            var values = await repository.GetByIdAsync(request.Id);
            await repository.RemoveAsync(values);
        }
    }
}
