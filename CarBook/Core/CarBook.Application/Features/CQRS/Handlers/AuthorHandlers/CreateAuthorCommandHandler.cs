using AutoMapper;
using CarBook.Application.Features.CQRS.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AuthorHandlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
    {
        private readonly IRepository<Author> _repository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<Author>(request);
            await _repository.CreateAsync(values);
        }
    }
}
