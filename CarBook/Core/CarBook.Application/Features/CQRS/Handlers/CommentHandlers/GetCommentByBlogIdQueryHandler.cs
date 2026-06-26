using AutoMapper;
using CarBook.Application.Features.CQRS.Queries.CommentQueries;
using CarBook.Application.Features.CQRS.Results.CommentResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CommentInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CommentHandlers
{
    public class GetCommentByBlogIdQueryHandler : IRequestHandler<GetCommentByBlogIdQuery,List<GetCommentByBlogIdQueryResult>>
    {

        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;

        public GetCommentByBlogIdQueryHandler(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCommentByBlogIdQueryResult>> Handle(GetCommentByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCommentByBlogId(request.BlogId);
            return values.Select(x => new GetCommentByBlogIdQueryResult
            {
                CommentId = x.CommentId,
                Content = x.Content,
                CreatedDate = x.CreatedDate,
                Name = x.Name,
                BlogId = x.BlogId,
                BlogName=x.Blog.Title
            }).ToList();
        }
    }
}
