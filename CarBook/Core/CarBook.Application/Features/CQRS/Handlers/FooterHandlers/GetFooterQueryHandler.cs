using AutoMapper;
using CarBook.Application.Features.CQRS.Queries.FooterQueries;
using CarBook.Application.Features.CQRS.Results.FooterResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.FooterHandlers
{
    public class GetFooterQueryHandler : IRequestHandler<GetFooterQuery, List<GetFooterQueryResult>>
    {
        private readonly IRepository<Footer> _repository;
        private readonly IMapper _mapper;

        public GetFooterQueryHandler(IRepository<Footer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetFooterQueryResult>> Handle(GetFooterQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetFooterQueryResult>>(values);
        }
    }
}
