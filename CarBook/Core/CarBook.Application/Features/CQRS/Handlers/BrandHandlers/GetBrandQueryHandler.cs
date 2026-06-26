using AutoMapper;
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
    public class GetBrandQueryHandler:IRequestHandler<GetBrandQuery,List<GetBrandQueryResult>>
    {
        private readonly IRepository<Brand> _repository;
        private readonly IMapper _mapper;
        public GetBrandQueryHandler(IRepository<Brand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetBrandQueryResult>> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetBrandQueryResult>>(values);
        }
    }
}
