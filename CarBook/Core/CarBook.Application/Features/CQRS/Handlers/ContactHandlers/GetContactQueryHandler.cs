using AutoMapper;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler:IRequestHandler<GetContactQuery,List<GetContactQueryResult>>
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public GetContactQueryHandler(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetContactQueryResult>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetContactQueryResult>>(values);
        }
    }
}
