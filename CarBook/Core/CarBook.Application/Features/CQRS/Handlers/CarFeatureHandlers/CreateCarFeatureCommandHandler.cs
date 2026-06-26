using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.ICarFeatureInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarFeatureHandlers
{
    public class CreateCarFeatureCommandHandler:IRequestHandler<CreateCarFeatureCommand>
    {
        private readonly ICarFeatureRepository carFeatureRepository;

        public CreateCarFeatureCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            this.carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(CreateCarFeatureCommand request, CancellationToken cancellationToken)
        {
            await carFeatureRepository.CreateAsync(new CarFeature
            {
                CarId = request.CarId,
                FeatureId = request.FeatureId,
                Avaliable = request.Avaliable,
            });
        }
    }
}
