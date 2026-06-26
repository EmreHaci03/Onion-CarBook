using AutoMapper;
using CarBook.Application.Features.CQRS.Queries.ServiceQueries;
using CarBook.Application.Features.CQRS.Results.ServiceResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery,GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;
        private readonly IMapper _mapper;

        public GetServiceByIdQueryHandler(IRepository<Service> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetServiceByIdQueryResult>(values);
        }
    }
}
