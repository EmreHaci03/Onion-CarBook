using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Commands.BlogCommands;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }
        [HttpGet("GetBlogCountByCategory")]
        public async Task<IActionResult> GetBlogCountByCategory()
        {
            var value = await _mediator.Send(new GetBlogCountByCategoryQuery());
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yeni Blog Alanı Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog Alanı Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog Alanı Güncellendi");
        }
        [HttpGet("GetLast3blogsWithAuthor")]
        public async Task<IActionResult> GetLast3blogsWithAuthor()
        {
            var value=await _mediator.Send(new GetLast3BlogsWithAuthorQuery());
            return Ok(value);
        }
        [HttpGet("GetLast5blogsWithAuthor")]
        public async Task<IActionResult> GetLast5blogsWithAuthor()
        {
            var value = await _mediator.Send(new GetLast5BlogsWithAuthorQuery());
            return Ok(value);
        }
    }
}
