using AutoMapper;
using CarBook.Application.Features.CQRS.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler:IRequestHandler<RemoveFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;
        private readonly IMapper _mapper;

        public RemoveFeatureCommandHandler(IRepository<Feature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
        }

       
    }
}
