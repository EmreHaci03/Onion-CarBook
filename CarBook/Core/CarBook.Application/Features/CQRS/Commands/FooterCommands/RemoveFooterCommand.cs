using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.FooterCommands
{
    public class RemoveFooterCommand:IRequest
    {
        public RemoveFooterCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
