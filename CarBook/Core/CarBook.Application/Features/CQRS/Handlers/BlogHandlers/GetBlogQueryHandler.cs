using AutoMapper;
using CarBook.Application.Features.CQRS.Queries.BlogQueries;
using CarBook.Application.Features.CQRS.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BlogHandlers
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;

        public GetBlogQueryHandler(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetBlogsWithDetails();
            return _mapper.Map<List<GetBlogQueryResult>>(values);
        }
    }
}
