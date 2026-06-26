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
    public class CreateFooterCommandHandler : IRequestHandler<CreateFooterCommand>
    {
        private readonly IRepository<Footer> _repository;
        private readonly IMapper _mapper;

        public CreateFooterCommandHandler(IRepository<Footer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(CreateFooterCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<Footer>(request);
            await _repository.CreateAsync(values);
        }
    }
}
