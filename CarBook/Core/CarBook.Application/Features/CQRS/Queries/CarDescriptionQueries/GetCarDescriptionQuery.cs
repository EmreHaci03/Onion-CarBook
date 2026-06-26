using CarBook.Application.Features.CQRS.Results.CarDescriptionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionQuery:IRequest<List<GetCarDescriptionQueryResult>>
    {

    }
}
