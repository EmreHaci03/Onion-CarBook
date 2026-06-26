using AutoMapper;
using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler:IRequestHandler<CreateCategoryCommand>
    {
        private readonly IRepository<BlogCategory> _repository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IRepository<BlogCategory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<BlogCategory>(request);
            await _repository.CreateAsync(values);
        }
    }
}
