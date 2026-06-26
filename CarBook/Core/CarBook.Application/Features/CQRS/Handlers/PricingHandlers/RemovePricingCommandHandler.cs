using AutoMapper;
using CarBook.Application.Features.CQRS.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.PricingHandlers
{
    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;
        private readonly IMapper _mapper;

        public RemovePricingCommandHandler(IRepository<Pricing> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
