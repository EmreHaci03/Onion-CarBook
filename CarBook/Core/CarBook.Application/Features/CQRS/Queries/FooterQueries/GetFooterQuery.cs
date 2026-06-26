using CarBook.Application.Features.CQRS.Results.FeatureResults;
using CarBook.Application.Features.CQRS.Results.FooterResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.FooterQueries
{
    public class GetFooterQuery: IRequest<List<GetFooterQueryResult>>
    {
    }
}
