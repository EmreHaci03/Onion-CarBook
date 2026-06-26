using CarBook.Application.Features.CQRS.Commands.CommentCommands;
using CarBook.Application.Features.CQRS.Queries.CommentQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = await _mediator.Send(new GetCommentWithBlogNameQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var value = await _mediator.Send(new GetCommentByIdQuery(id));
            return Ok(value);
        }

        [HttpGet("CommentCount/{id}")]
        public async Task<IActionResult> GetCommentCountByBlogId(int id)
        {
            var value = await _mediator.Send(new GetCommentCountByBlogIdQuery(id));
            return Ok(value);
        }

        [HttpGet("GetCommentsByBlogId/{id}")]
        public async Task<IActionResult> GetCommentsByBlogId(int id)
        {
            var value = await _mediator.Send(new GetCommentByBlogIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yorum Alanı Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _mediator.Send(new RemoveCommentCommand(id));
            return Ok("Yorum Alanı Silindi");
        }
    }
}