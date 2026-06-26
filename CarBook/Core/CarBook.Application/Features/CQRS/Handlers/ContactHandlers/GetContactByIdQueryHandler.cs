using AutoMapper;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler:IRequestHandler<GetContactByIdQuery,GetContactByIdQueryResult>
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;
        public GetContactByIdQueryHandler(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetContactByIdQueryResult>(value);
        }
    }
}
