using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values =await _mediator.Send(new GetBrandQuery());
            return Ok(values);  
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var value = await _mediator.Send(new GetBrandByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand createBrandCommand)
        {
            await _mediator.Send(createBrandCommand);
            return Ok("Marka Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _mediator.Send(new RemoveBrandCommand(id));
            return Ok("Marka Alanı Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand updateBrandCommand)
        {
            await _mediator.Send(updateBrandCommand);
            return Ok("Marka Alanı Güncellendi");

        }
        
    }
}
