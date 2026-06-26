using CarBook.Application.Features.CQRS.Queries.TagCloudQueries;
using CarBook.Application.Features.CQRS.Results.TagCloudResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository tagCloudRepository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository tagCloudRepository)
        {
            this.tagCloudRepository = tagCloudRepository;
        }

        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = tagCloudRepository.GetTagCloudsByBlogId(request.Id);
            return values.Select(x=>new GetTagCloudByBlogIdQueryResult
            {
                TagCloudId=x.TagCloudId,
                TagCloudName=x.TagCloudName,
                BlogId = x.BlogId
            }).ToList();
        }
    }
}
