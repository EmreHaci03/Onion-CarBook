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
    public class GetCommentWithBlogNameQueryHandler : IRequestHandler<GetCommentWithBlogNameQuery, List<GetCommentWithBlogNameQueryResult>>
    {
        private readonly ICommentRepository commentRepository;
        private readonly IMapper _mapper;

        public GetCommentWithBlogNameQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _mapper = mapper;
            this.commentRepository = commentRepository;
        }

        public async Task<List<GetCommentWithBlogNameQueryResult>> Handle(GetCommentWithBlogNameQuery request, CancellationToken cancellationToken)
        {
            var values = commentRepository.GetCommentWithBlogName();
            return _mapper.Map<List<GetCommentWithBlogNameQueryResult>>(values);
        }
    }
}
