using CarBook.Application.Features.CQRS.Results.FeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.FeatureQueries
{
    public class GetFeatureByIdQuery:IRequest<GetFeatureByIdQueryResult>
    {
        public GetFeatureByIdQuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }

       
    }
}
