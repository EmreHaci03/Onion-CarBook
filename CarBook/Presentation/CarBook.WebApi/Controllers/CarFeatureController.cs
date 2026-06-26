using CarBook.Application.Features.CQRS.Commands.CarFeatureCommands;
using CarBook.Application.Features.CQRS.Queries.CarFeatureQueries;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.FeatureResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetByCarId/{carId}")]
        public async Task<IActionResult> GetByCarId(int carId)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(carId));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCarId(CreateCarFeatureCommand createCarFeatureCommand)
        {
            await _mediator.Send(createCarFeatureCommand);
            return Ok("Araç Özelliği Eklendi");
        }
        [HttpPut("UpdateByCarId")]
        public async Task<IActionResult> UpdateByCarId(UpdateCarFeatureCommand updateCarFeatureCommand)
        {
            await _mediator.Send(updateCarFeatureCommand);
            return Ok("Araç Özelliği Güncellendi");
        }
    }
}
