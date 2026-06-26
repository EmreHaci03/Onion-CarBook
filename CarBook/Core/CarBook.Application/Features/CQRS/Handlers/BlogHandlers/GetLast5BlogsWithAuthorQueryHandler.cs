using AutoMapper;
using CarBook.Application.Features.CQRS.Queries.BlogQueries;
using CarBook.Application.Features.CQRS.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BlogHandlers
{
    public class GetLast5BlogsWithAuthorQueryHandler : IRequestHandler<GetLast5BlogsWithAuthorQuery, List<GetLast5BlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public GetLast5BlogsWithAuthorQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<List<GetLast5BlogsWithAuthorQueryResult>> Handle(GetLast5BlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _blogRepository.GetLast5BlogsWithAuthor();
            return _mapper.Map<List<GetLast5BlogsWithAuthorQueryResult>>(values);
        }
    }
}