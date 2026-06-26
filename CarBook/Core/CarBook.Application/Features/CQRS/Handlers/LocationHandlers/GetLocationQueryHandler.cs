using AutoMapper;
using CarBook.Application.Features.CQRS.Queries.LocationQueries;
using CarBook.Application.Features.CQRS.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        private readonly IRepository<Location> _repository;
        private readonly IMapper _mapper;

        public GetLocationQueryHandler(IRepository<Location> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetAllAsync();
            return _mapper.Map<List<GetLocationQueryResult>>(values);
        }
    }
}
