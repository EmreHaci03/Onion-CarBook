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
    public class GetFooterByIdQueryHandler : IRequestHandler<GetFooterByIdQuery, GetFooterByIdQueryResult>
    {
        private readonly IRepository<Footer> _repository;
        private readonly IMapper _mapper;

        public GetFooterByIdQueryHandler(IRepository<Footer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetFooterByIdQueryResult> Handle(GetFooterByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetFooterByIdQueryResult>(values);
        }
    }
}
