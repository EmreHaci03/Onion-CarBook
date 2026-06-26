using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.BannerCommands
{
    public class RemoveBannerCommand : IRequest
    {
        public RemoveBannerCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
