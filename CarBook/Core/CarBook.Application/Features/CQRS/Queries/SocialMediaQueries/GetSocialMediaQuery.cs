using CarBook.Application.Features.CQRS.Results.SocialMediaResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.SocialMediaQueries
{
    public class GetSocialMediaQuery:IRequest<List<GetSocialMediaQueryResult>>
    {
    }
}
