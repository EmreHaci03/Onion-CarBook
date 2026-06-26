using AutoMapper;
using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler:IRequestHandler<UpdateAboutCommand>
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public UpdateAboutCommandHandler(IRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
           var values=_mapper.Map<About>(request);
           await _repository.UpdateAsync(values);
        }
    }
}
