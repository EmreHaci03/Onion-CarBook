using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Domain.Entities;
using CarBook.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.CarQueries
{
    public class GetLast5CarsWithBrandsQuery: IRequest<List<GetLast5CarsWithBrandsQueryResult>>
    {

    }
}
