using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Commands.TagCloudCommands;
using CarBook.Application.Features.CQRS.Handlers.TagCloudHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Queries.TagCloudQueries;
using CarBook.Application.Features.CQRS.Results.TagCloudResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TagCloudList()
        {
            var values = await _mediator.Send(new GetTagCloudWithBlogNameQuery());
            return Ok(values);
        }


        [HttpGet("GetTagCloudByBlogId/{id}")]
        public async Task<IActionResult> GetTagCloudByBlogId(int id)
        {
            var values = await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddTagCloud(CreateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTagCloud(int id)
        {
            await _mediator.Send(new RemoveTagCloudCommand(id));
            return Ok("Etiket Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket Başarıyla Güncellendi");
        }
    }
}
