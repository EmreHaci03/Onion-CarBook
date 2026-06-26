using CarBook.Application.Features.CQRS.Results.ServiceResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.ServiceQueries
{
    public class GetServiceByIdQuery:IRequest<GetServiceByIdQueryResult>
    {
        public GetServiceByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
