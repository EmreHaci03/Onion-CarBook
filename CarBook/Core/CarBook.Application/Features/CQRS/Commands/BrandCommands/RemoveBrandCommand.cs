using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.BrandCommands
{
    public class RemoveBrandCommand : IRequest
    {
        public RemoveBrandCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
