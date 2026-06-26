using AutoMapper;
using CarBook.Application.Features.CQRS.Queries.CommentQueries;
using CarBook.Application.Features.CQRS.Results.CommentResults;
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
    public class GetCommentByIdQueryHandler:IRequestHandler<GetCommentByIdQuery,GetCommentByIdQueryResult>
    {
        private readonly IRepository<Comment> _repository;
        private readonly IMapper _mapper;

        public GetCommentByIdQueryHandler(IRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetCommentByIdQueryResult>(values);
        }
    }
}
