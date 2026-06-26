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
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand>
    {
        private readonly IRepository<Author> _repository;
        private readonly IMapper _mapper;

        public RemoveAuthorCommandHandler(IRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
