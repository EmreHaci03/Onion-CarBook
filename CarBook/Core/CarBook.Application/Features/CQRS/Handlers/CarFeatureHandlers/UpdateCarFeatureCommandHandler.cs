using CarBook.Application.Features.CQRS.Commands.CarFeatureCommands;
using CarBook.Application.Interfaces.ICarFeatureInterfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureCommandHandler : IRequestHandler<UpdateCarFeatureCommand>
    {
        private readonly ICarFeatureRepository carFeatureRepository;
        public UpdateCarFeatureCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            this.carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(UpdateCarFeatureCommand request, CancellationToken cancellationToken)
        {
            var values = await carFeatureRepository.GetByCarIdWithDetailsAsync(request.CarId);
            var carFeature = values.FirstOrDefault(x => x.FeatureId == request.FeatureId);

            if (carFeature == null)
                throw new Exception("Araç-özellik eşleşmesi bulunamadı.");

            carFeature.Avaliable = request.Avaliable;

            await carFeatureRepository.UpdateAsync(carFeature);
        }
    }
}