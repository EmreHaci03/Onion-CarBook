using CarBook.Application.Features.CQRS.Results.PricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.PricingQueries
{
    public class GetPricingQuery:IRequest<List<GetPricingQueryResult>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
