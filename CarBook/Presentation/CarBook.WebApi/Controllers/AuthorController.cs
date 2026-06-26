using CarBook.Application.Features.CQRS.Commands.AuthorCommands;
using CarBook.Application.Features.CQRS.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AuthorList()
        {
            var values = await _mediator.Send(new GetAuthorQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var value = await _mediator.Send(new GetAuthorByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommand createAuthorCommand)
        {
            await _mediator.Send(createAuthorCommand);
            return Ok("Yeni Yazar Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _mediator.Send(new RemoveAuthorCommand(id));
            return Ok("İlgili Yazar Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand updateAuthorCommand)
        {
            await _mediator.Send(updateAuthorCommand);
            return Ok("İlgili Yazar Alanı Güncellendi");

        }
    }
}
