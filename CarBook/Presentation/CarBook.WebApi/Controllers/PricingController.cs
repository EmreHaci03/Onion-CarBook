using CarBook.Application.Features.CQRS.Commands.PricingCommands;
using CarBook.Application.Features.CQRS.Queries.PricingQueries;
using CarBook.Application.Features.CQRS.Results.PricingResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            var values = await _mediator.Send(new GetPricingQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricing(int id)
        {
            var values = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePricing(int id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return Ok("Ödeme Türü Başarıyla Silindi");
        }
        [HttpPost]
        public async Task<IActionResult> AddPricing(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ödeme Türü Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ödeme Türü Başarıyla Güncellendi");
        }
    }
}
