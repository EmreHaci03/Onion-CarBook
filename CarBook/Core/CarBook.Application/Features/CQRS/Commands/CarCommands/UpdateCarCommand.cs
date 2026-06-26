using CarBook.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.CarCommands
{
    public class UpdateCarCommand : IRequest
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string? Model { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
        public int Mileage { get; set; }
        public TransmissionType Transmission { get; set; }
        public byte Seats { get; set; }
        public byte LuggageCapacity { get; set; }
        public FuelType FuelType { get; set; }
        public string DetailImageUrl { get; set; } = string.Empty;
    }
}
