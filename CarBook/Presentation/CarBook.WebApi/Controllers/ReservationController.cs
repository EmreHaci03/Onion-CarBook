using CarBook.Application.Features.CQRS.Commands.ReservationCommands;
using CarBook.Application.Features.CQRS.Queries.ReservationQueries;
using CarBook.Application.Features.CQRS.Results.ReservationResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ReservationList()
        {
            var values=await _mediator.Send(new GetReservationQuery());
            return Ok(values);

        }
        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand createReservationCommand)
        {
            await _mediator.Send(createReservationCommand);
            return Ok("Rezervasyon Başarıyla Eklendi");
        }
    }
}
