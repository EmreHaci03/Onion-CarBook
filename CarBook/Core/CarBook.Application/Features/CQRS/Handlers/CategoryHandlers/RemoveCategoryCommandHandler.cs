using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler:IRequestHandler<RemoveCategoryCommand>
    {
        private readonly IRepository<BlogCategory> _repository;

        public RemoveCategoryCommandHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            if (values != null)
                await _repository.RemoveAsync(values);
        }
    }
}
