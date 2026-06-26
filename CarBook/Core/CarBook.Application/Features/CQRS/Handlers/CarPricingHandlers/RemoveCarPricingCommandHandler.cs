using CarBook.Application.Features.CQRS.Commands.CarPricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarPricingHandlers
{
    public class RemoveCarPricingCommandHandler : IRequestHandler<RemoveCarPricingCommand>
    {
        private readonly ICarPricingRepository carPricingRepository;

        public RemoveCarPricingCommandHandler(ICarPricingRepository carPricingRepository)
        {
            this.carPricingRepository = carPricingRepository;
        }

        public async Task Handle(RemoveCarPricingCommand request, CancellationToken cancellationToken)
        {
            var entity = await carPricingRepository.GetByIdAsync(request.Id);
            await carPricingRepository.RemoveAsync(entity);
        }
    }
}
