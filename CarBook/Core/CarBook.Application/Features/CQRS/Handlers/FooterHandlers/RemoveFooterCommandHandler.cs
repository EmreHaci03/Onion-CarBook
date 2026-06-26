using AutoMapper;
using CarBook.Application.Features.CQRS.Commands.FooterCommands;
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
    public class RemoveFooterCommandHandler : IRequestHandler<RemoveFooterCommand>
    {
        private readonly IRepository<Footer> _repository;
        private readonly IMapper _mapper;

        public RemoveFooterCommandHandler(IRepository<Footer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(RemoveFooterCommand request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
