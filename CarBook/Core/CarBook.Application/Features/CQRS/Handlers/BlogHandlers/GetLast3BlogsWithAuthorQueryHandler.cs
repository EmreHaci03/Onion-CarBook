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
    public class GetLast3BlogsWithAuthorQueryHandler:IRequestHandler<GetLast3BlogsWithAuthorQuery,List<GetLast3BlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public GetLast3BlogsWithAuthorQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<List<GetLast3BlogsWithAuthorQueryResult>> Handle(GetLast3BlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _blogRepository.GetLast3BlogsWithAuthor();
            return _mapper.Map<List<GetLast3BlogsWithAuthorQueryResult>>(values);
        }
    }
}
