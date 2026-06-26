using CarBook.Application.Features.CQRS.Results.CarResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.CarQueries
{
    public class ResultCarWithPricingForAdminQuery:IRequest<ResultCarWithPricingForAdminQueryResult>
    {
        public ResultCarWithPricingForAdminQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

       
    }
}
