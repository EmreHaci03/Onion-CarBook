using CarBook.Application.Features.CQRS.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarController : ControllerBase
    {
        private readonly IMediator mediator;

        public RentACarController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRentACarsByLocationAsync([FromQuery]GetRentACarQuery getRentACarQuery) 
        {
            // HTTP GET isteğindeki query string parametrelerini metoda bağlamak için kullanılır.
            var values = await mediator.Send(getRentACarQuery);
            return Ok(values);
        }

        [HttpGet("GetUnavailableRentACar")]
        public async Task<IActionResult> GetUnavailableRentACarQueryHandler([FromQuery] GetUnavailableRentACarQuery getUnavailableRentACarQuery)
        {
            var values = await mediator.Send(getUnavailableRentACarQuery);
            return Ok(values);
        }
    }
}
