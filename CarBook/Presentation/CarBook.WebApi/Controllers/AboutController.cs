using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _mediator.Send(new GetAboutQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var value = await _mediator.Send(new GetAboutByIdQuery(id));
            return Ok(value);  
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
        }
        await _mediator.Send(command);
            return Ok("Hakkımda Alanı Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _mediator.Send(new RemoveAboutCommand(id));
            return Ok("Hakkımda Alanı Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand updateAboutCommand)
        {
            await _mediator.Send(updateAboutCommand);
            return Ok("Hakkımda Alanı Güncellendi");
        }
    }
}
