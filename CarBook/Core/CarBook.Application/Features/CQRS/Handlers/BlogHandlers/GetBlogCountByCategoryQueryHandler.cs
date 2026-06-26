using CarBook.Application.Features.CQRS.Queries.BlogQueries;
using CarBook.Application.Features.CQRS.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BlogHandlers
{
    public class GetBlogCountByCategoryQueryHandler : IRequestHandler<GetBlogCountByCategoryQuery, List<GetBlogCountByCategoryQueryResult>>
    {
        private readonly IBlogRepository blogRepository;

        public GetBlogCountByCategoryQueryHandler(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public async Task<List<GetBlogCountByCategoryQueryResult>> Handle(GetBlogCountByCategoryQuery request, CancellationToken cancellationToken)
        {
            var values = blogRepository.GetBlogCountByCategoryQuery();
            return values.GroupBy(x => x.BlogCategory.Name)
                .Select(g => new GetBlogCountByCategoryQueryResult
                {
                    CategoryName = g.Key,
                    BlogCount = g.Count()
                }).ToList();
        }
    }
}
