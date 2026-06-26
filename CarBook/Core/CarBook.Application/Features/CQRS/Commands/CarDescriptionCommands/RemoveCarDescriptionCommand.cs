using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.CarDescriptionCommands
{
    public class RemoveCarDescriptionCommand:IRequest
    {
        public RemoveCarDescriptionCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
