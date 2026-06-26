using CarBook.Application.Features.CQRS.Handlers.StatisticHandlers;
using CarBook.Application.Features.CQRS.Results.StatisticResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.StatisticQueries
{
    public class GetMostCommentedBlogTitleQuery:IRequest<GetMostCommentedBlogTitleQueryResult>
    {
    }
}
