using AutoMapper;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler:IRequestHandler<GetCategoryByIdQuery,GetCategoryByIdQueryResult>
    {
            private readonly IRepository<BlogCategory> _repository;
            private readonly IMapper _mapper;

            public GetCategoryByIdQueryHandler(IRepository<BlogCategory> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetCategoryByIdQueryResult>(values);
        }
    }
}

