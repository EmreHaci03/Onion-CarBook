using AutoMapper;
using CarBook.Application.Features.CQRS.Commands.CommentCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CommentHandlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IRepository<Comment> repository;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IRepository<Comment> repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
           var values=_mapper.Map<Comment>(request);
            values.CreatedDate = DateTime.Now;
           await repository.CreateAsync(values);
        }
    }
}
