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
    public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommand>
    {
        private readonly IRepository<Comment> _repository;
        private readonly IMapper _mapper;

        public RemoveCommentCommandHandler(IRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            if (values != null) 
            await _repository.RemoveAsync(values);
        }
    }
}
