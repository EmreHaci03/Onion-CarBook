using AutoMapper;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler:IRequestHandler<GetCarByIdQuery,GetCarByIdQueryResult>
    {
        private readonly IRepository<Car> _repository;
        private readonly IMapper _mapper;

        public GetCarByIdQueryHandler(IRepository<Car> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.id);
            return _mapper.Map<GetCarByIdQueryResult>(values);
        }
    }
}
