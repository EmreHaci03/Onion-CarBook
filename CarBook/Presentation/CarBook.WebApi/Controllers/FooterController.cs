using CarBook.Application.Features.CQRS.Commands.FooterCommands;
using CarBook.Application.Features.CQRS.Queries.FooterQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FooterList()
        {
            var values = await _mediator.Send(new GetFooterQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooter(int id)
        {
            var values = await _mediator.Send(new GetFooterByIdQuery(id));
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFooter(int id)
        {
            await _mediator.Send(new RemoveFooterCommand(id));
            return Ok("Footer Alanı Silindi");
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooter(CreateFooterCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Alanı Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooter(UpdateFooterCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Alanı Güncellendi");
        }
        
    }
}
