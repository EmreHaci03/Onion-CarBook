using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Queries.StatisticQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _mediator.Send(new GetCarQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var values = await _mediator.Send(new GetCarByIdQuery(id));
            return Ok(values);
        }

        [HttpGet("GetCarWithBrand")]
        public async Task<IActionResult> GetCarWithBrand()
        {
            var values = await _mediator.Send(new GetCarWithBrandQuery());
            return Ok(values);
        }
        [HttpGet("GetCarWithBrandById/{id}")]
        public async Task<IActionResult> GetCarWithBrand(int id)
        {
            var values = await _mediator.Send(new GetCarWithBrandByIdQuery(id));
            return Ok(values);
        }
        [HttpGet("GetLast5CarsWithBrands")]
        public async Task<IActionResult> GetLast5CarsWithBrands()
        {
            var values = await _mediator.Send(new GetLast5CarsWithBrandsQuery());
            return Ok(values);
        }
        [HttpGet("GetCarsWithPricings")]
        public async Task<IActionResult> GetCarsWithPricings()
        {
            var values = await _mediator.Send(new GetCarWithPricingsQuery());
            return Ok(values);
        }
        [HttpGet("ResultCarWithPricingForAdmin")]
        public async Task<IActionResult> ResultCarWithPricingForAdmin(int id)
        {
            var values = await _mediator.Send(new ResultCarWithPricingForAdminQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddCar(CreateCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Araba Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _mediator.Send(new RemoveCarCommand(id));
            return Ok("Araba Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Araba Başarıyla Güncellendi");
        }
    }
}