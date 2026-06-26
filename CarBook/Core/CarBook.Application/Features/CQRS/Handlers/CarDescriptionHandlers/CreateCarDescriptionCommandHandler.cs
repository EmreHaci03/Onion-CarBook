using AutoMapper;
using CarBook.Application.Features.CQRS.Commands.CarDescriptionCommands;
using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarDescriptionHandlers
{
    public class CreateCarDescriptionCommandHandler : IRequestHandler<CreateCarDescriptionCommand>
    {
        private readonly ICarDescriptionRepository _repository;
        public CreateCarDescriptionCommandHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var entity = new CarDescription
            {
                CarId = request.CarId,
                DetailDescription = request.DetailDescription
            };
            await _repository.CreateAsync(entity);
        }
    }
}