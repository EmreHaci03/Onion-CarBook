using CarBook.Application.Features.CQRS.Commands.CarPricingCommands;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarPricingHandlers
{
    public class UpdateCarPricingCommandHandler : IRequestHandler<UpdateCarPricingCommand>
    {
        private readonly ICarPricingRepository carPricingRepository;

        public UpdateCarPricingCommandHandler(ICarPricingRepository carPricingRepository)
        {
            this.carPricingRepository = carPricingRepository;
        }

        public async Task Handle(UpdateCarPricingCommand request, CancellationToken cancellationToken)
        {
            var entity = await carPricingRepository.GetByIdAsync(request.Id);

            if (entity == null)
                throw new Exception("Car pricing not found");

            entity.Pricing.Name = request.PricingType;
            entity.Amount = request.Amount;

            await carPricingRepository.UpdateCarPricing(entity);
        }
    }
}