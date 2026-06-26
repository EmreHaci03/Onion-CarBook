using CarBook.Application.Features.CQRS.Queries.BlogQueries;
using CarBook.Application.Features.CQRS.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IBlogRepository _repository;

        public GetBlogByIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.id == 0)
                return new GetBlogByIdQueryResult();

            var x = _repository.GetBlogsWithDetailsByBlogId(request.id);
            if (x == null)
                return new GetBlogByIdQueryResult();

            return new GetBlogByIdQueryResult
            {
                Id = x.Id,
                AuthorId = x.AuthorId,
                AuthorName = x.Author?.AuthorName,
                Title = x.Title,
                CreateDate = x.CreateDate,
                Description = x.Description,
                CoverImageUrl = x.CoverImageUrl,
                BlogCategoryId = x.BlogCategoryId,
                BlogCategoryName = x.BlogCategory?.Name
            };
        }
    }
}