using CarBook.Application.Features.CQRS.Commands.CarDescriptionCommands;
using CarBook.Application.Features.CQRS.Queries.CarDescriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionController : ControllerBase
    {
        private readonly IMediator mediator;
        public CarDescriptionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarDescription()
        {
            var values = await mediator.Send(new GetCarDescriptionQuery());
            return Ok(values);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await mediator.Send(new GetCarDescriptionByIdQuery(id));
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarDescriptionByCarId(int id)
        {
            var values = await mediator.Send(new GetCarDescriptionByCarIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddCarDescription(CreateCarDescriptionCommand command)
        {
            await mediator.Send(command);
            return Ok("Araç Açıklaması Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarDescription(int id)
        {
            await mediator.Send(new RemoveCarDescriptionCommand(id));
            return Ok("Araç Açıklaması Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarDescription(UpdateCarDescriptionCommand command)
        {
            await mediator.Send(command);
            return Ok("Araç Açıklaması Başarıyla Güncellendi");
        }
    }
}