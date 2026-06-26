using CarBook.Application.Features.CQRS.Queries.StatisticQueries;
using CarBook.Application.Features.CQRS.Results.StatisticResults;
using CarBook.Application.Interfaces.IStatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.StatisticHandlers
{
    public class GetMostCommentedBlogTitleQueryHandler : IRequestHandler<GetMostCommentedBlogTitleQuery, GetMostCommentedBlogTitleQueryResult>
    {
        private readonly IStatisticRepository statisticRepository;

        public GetMostCommentedBlogTitleQueryHandler(IStatisticRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }

        public async Task<GetMostCommentedBlogTitleQueryResult> Handle(GetMostCommentedBlogTitleQuery request, CancellationToken cancellationToken)
        {
            var values = await statisticRepository.MostCommentedBlogTitle();
            return new GetMostCommentedBlogTitleQueryResult
            {
                CommentCount = values.CommentCount,
                BlogTitle = values.BlogName
            };
        }
    }
}
