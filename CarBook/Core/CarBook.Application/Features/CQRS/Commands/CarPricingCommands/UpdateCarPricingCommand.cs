using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.CarPricingCommands
{
    public class UpdateCarPricingCommand:IRequest
    {
        public int Id { get; set; }
        public string PricingType { get; set; }
        public decimal Amount { get; set; }
    }
}
