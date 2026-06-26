using AutoMapper;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler:IRequestHandler<GetCategoryQuery,List<GetCategoryQueryResult>>
    {
        private readonly IRepository<BlogCategory> _repository;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IRepository<BlogCategory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetCategoryQueryResult>>(values);
        }
    }
}
