using CarBook.Application.Features.CQRS.Commands.CarDescriptionCommands;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarDescriptionHandlers
{
    public class UpdateCarDescriptionCommandHandler : IRequestHandler<UpdateCarDescriptionCommand>
    {
        private readonly ICarDescriptionRepository _repository;
        public UpdateCarDescriptionCommandHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            entity.CarId = request.CarId;
            entity.DetailDescription = request.DetailDescription;
            await _repository.UpdateAsync(entity);
        }
    }
}
