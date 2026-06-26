using AutoMapper;
using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler:IRequestHandler<UpdateBannerCommand>
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;

        public UpdateBannerCommandHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<Banner>(request);
            await _repository.UpdateAsync(values);
        }
    }
}
