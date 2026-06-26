using AutoMapper;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler:IRequestHandler<GetCarWithBrandQuery,List<GetCarWithBrandQueryResult>>
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public GetCarWithBrandQueryHandler(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle(GetCarWithBrandQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarsListWithBrands();
            return _mapper.Map<List<GetCarWithBrandQueryResult>>(values);
        }
    }

}

