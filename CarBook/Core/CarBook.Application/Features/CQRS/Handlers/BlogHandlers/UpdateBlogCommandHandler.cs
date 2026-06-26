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
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;
        private readonly IMapper _mapper;

        public UpdateBlogCommandHandler(IRepository<Blog> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);
            if (blog == null)
                throw new Exception("Blog bulunamadı.");

            blog.Title = request.Title;
            blog.Description = request.Description;
            blog.CoverImageUrl = request.CoverImageUrl;
            blog.AuthorId = request.AuthorId;
            blog.BlogCategoryId = request.BlogCategoryId;

            await _repository.UpdateAsync(blog);
        }
    }
}
