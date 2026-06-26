using AutoMapper;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler:IRequestHandler<GetBrandByIdQuery,GetBrandByIdQueryResult>
    {
        private readonly IRepository<Brand> _repository;
        private readonly IMapper _mapper;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.id);
            return _mapper.Map<GetBrandByIdQueryResult>(values);
        }
    }
}
