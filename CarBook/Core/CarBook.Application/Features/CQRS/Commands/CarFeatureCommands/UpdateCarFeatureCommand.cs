using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureCommand : IRequest
    {
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public bool Avaliable { get; set; }
    }
}
