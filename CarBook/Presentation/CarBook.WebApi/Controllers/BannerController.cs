using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BannerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _mediator.Send(new GetBannerQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value = await _mediator.Send(new GetBannerByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand createBannerCommand)
        {
            await _mediator.Send(createBannerCommand);
            return Ok("Öne Çıkanlar Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _mediator.Send(new RemoveBannerCommand(id));
            return Ok("Öne Çıkanlar Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Öne Çıkan Alanı Güncellendi");

        }
    }
}
