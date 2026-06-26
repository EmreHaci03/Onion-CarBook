using CarBook.Application.Features.CQRS.Queries.TagCloudQueries;
using CarBook.Application.Features.CQRS.Results.TagCloudResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.TagCloudHandlers
{
    public class GetTagCloudWithBlogNameQueryHandler : IRequestHandler<GetTagCloudWithBlogNameQuery, List<GetTagCloudWithBlogNameQueryResult>>
    {
        private readonly ITagCloudRepository _repository;

        public GetTagCloudWithBlogNameQueryHandler(ITagCloudRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudWithBlogNameQueryResult>> Handle(GetTagCloudWithBlogNameQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetTagCloudsWithBlog();
            return values.Select(x => new GetTagCloudWithBlogNameQueryResult
            {
                TagCloudId = x.TagCloudId,
                TagCloudName = x.TagCloudName,
                BlogId = x.BlogId,
                BlogName = x.Blog.Title
            }).ToList();
        }
    }
}
