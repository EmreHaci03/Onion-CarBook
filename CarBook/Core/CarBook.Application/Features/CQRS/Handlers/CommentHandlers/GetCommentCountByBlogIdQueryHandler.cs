using CarBook.Application.Features.CQRS.Queries.CommentQueries;
using CarBook.Application.Features.CQRS.Results.CommentResults;
using CarBook.Application.Interfaces.CommentInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CommentHandlers
{
    public class GetCommentCountByBlogIdQueryHandler : IRequestHandler<GetCommentCountByBlogIdQuery, List<GetCommentCountByBlogIdQueryResult>>
    {
        private readonly ICommentRepository commentRepository;

        public GetCommentCountByBlogIdQueryHandler(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public async Task<List<GetCommentCountByBlogIdQueryResult>> Handle(GetCommentCountByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = commentRepository.GetCommentCountByBlogId(request.BlogId);

            return new List<GetCommentCountByBlogIdQueryResult>
            {
                new GetCommentCountByBlogIdQueryResult
                {
                    BlogId = request.BlogId,
                    CommentCount = values
                }
            };
        }
    }
}
