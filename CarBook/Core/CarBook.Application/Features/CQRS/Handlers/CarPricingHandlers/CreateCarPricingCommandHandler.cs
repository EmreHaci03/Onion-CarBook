using CarBook.Application.Features.CQRS.Commands.CarPricingCommands;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarPricingHandlers
{
    public class CreateCarPricingCommandHandler : IRequestHandler<CreateCarPricingCommand>
    {
        private readonly ICarPricingRepository carPricingRepository;

        public CreateCarPricingCommandHandler(ICarPricingRepository carPricingRepository)
        {
            this.carPricingRepository = carPricingRepository;
        }

        public async Task Handle(CreateCarPricingCommand request, CancellationToken cancellationToken)
        {
            await carPricingRepository.CreateCarPricingAsync(new CarPricing
            {
                CarId = request.CarId,
                PricingId = request.PricingId,
                Amount = request.Amount
            });
        }
    }
}
