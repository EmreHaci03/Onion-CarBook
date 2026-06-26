using CarBook.Application.Features.CQRS.Commands.CarFeatureCommands;
using CarBook.Application.Features.CQRS.Commands.CarPricingCommands;
using CarBook.Application.Features.CQRS.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingController : ControllerBase
    {
        private readonly IMediator mediator;
        public CarPricingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarPricings()
        {
            var values = await mediator.Send(new GetCarPricingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarPricingById(int id)
        {
            var values = await mediator.Send(new GetCarPricingByIdQuery(id));
            return Ok(values);
        }

        [HttpGet("ByCarId/{CarId}")]
        public async Task<IActionResult> GetCarPricingByCarId(int CarId)
        {
            var values = await mediator.Send(new GetCarPricingByCarIdQuery(CarId));
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarPricing(int id)
        {
            await mediator.Send(new RemoveCarPricingCommand(id));
            return Ok("Araç Fiyatı Silindi");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarPricing(CreateCarPricingCommand command)
        {
            await mediator.Send(command);
            return Ok("Fiyat başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarPricing(UpdateCarPricingCommand updateCarPricingCommand)
        {
            await mediator.Send(updateCarPricingCommand);
            return Ok("Araç Fiyatı Güncellendi");
        }
    }
}