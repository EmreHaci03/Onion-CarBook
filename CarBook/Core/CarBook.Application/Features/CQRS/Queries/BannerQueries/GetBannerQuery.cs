using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.BannerQueries
{
    public class GetBannerQuery:IRequest<List<GetBannerQueryResult>>
    {
    }
}
