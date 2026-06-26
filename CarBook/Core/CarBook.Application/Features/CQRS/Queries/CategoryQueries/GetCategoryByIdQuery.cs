using CarBook.Application.Features.CQRS.Results.CategoryResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery:IRequest<GetCategoryByIdQueryResult>
    {
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }

        public int Id {  get; set; }
    }
}
