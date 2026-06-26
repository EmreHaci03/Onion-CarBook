using AutoMapper;
using CarBook.Application.Features.CQRS.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ServiceHandlers
{
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
    {
        private readonly IRepository<Service> _repository;
        private readonly IMapper _mapper;

        public RemoveServiceCommandHandler(IRepository<Service> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            if (values != null)
                await _repository.RemoveAsync(values);
        }
    }
}
