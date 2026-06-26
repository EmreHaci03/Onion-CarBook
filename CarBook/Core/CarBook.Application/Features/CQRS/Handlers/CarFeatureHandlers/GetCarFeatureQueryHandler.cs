using CarBook.Application.Features.CQRS.Queries.CarFeatureQueries;
using CarBook.Application.Features.CQRS.Results.CarFeatureResults;
using CarBook.Application.Interfaces.ICarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureQueryHandler : IRequestHandler<GetCarFeatureQuery, List<GetCarFeatureQueryResult>>
    {
        private readonly ICarFeatureRepository carFeatureRepository;

        public GetCarFeatureQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            this.carFeatureRepository = carFeatureRepository;
        }

        public Task<List<GetCarFeatureQueryResult>> Handle(GetCarFeatureQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
