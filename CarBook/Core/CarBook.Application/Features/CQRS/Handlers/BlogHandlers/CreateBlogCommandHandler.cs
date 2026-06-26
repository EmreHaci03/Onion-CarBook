using AutoMapper;
using CarBook.Application.Features.CQRS.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BlogHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IRepository<Blog> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<Blog>(request);
            await _repository.CreateAsync(values);
            
        }
    }
}
