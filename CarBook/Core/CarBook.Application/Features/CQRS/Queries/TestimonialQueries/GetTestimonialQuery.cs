using CarBook.Application.Features.CQRS.Results.TestimonialResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.TestimonialQueries
{
    public class GetTestimonialQuery:IRequest<List<GetTestimonialQueryResult>>
    {
    }
}
