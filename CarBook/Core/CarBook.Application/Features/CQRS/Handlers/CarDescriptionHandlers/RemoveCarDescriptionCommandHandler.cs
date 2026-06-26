using CarBook.Application.Features.CQRS.Commands.CarDescriptionCommands;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.CarDescriptionHandlers
{
    public class RemoveCarDescriptionCommandHandler : IRequestHandler<RemoveCarDescriptionCommand>
    {
        private readonly ICarDescriptionRepository _repository;
        public RemoveCarDescriptionCommandHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(entity);
        }
    }
}