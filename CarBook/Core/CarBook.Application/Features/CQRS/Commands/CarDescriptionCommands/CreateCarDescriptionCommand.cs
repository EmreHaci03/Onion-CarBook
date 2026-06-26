using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.CarDescriptionCommands
{
    public class CreateCarDescriptionCommand: IRequest
    {
        public int CarId { get; set; }
        public string DetailDescription { get; set; }
    }
}
