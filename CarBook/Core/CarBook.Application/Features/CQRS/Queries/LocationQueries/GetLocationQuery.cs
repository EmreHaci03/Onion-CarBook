using CarBook.Application.Features.CQRS.Results.FooterResults;
using CarBook.Application.Features.CQRS.Results.LocationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.LocationQueries
{
    public class GetLocationQuery: IRequest<List<GetLocationQueryResult>>
    {
    }
}
