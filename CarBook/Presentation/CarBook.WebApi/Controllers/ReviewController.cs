using CarBook.Application.Features.CQRS.Commands.ReviewCommands;
using CarBook.Application.Features.CQRS.Queries.ReviewQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator mediator;
        public ReviewController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var values = await mediator.Send(new GetReviewQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var values = await mediator.Send(new GetReviewByIdQuery(id));
            return Ok(values);
        }

        [HttpGet("GetReviewsByCarId/{carId}")]
        public async Task<IActionResult> GetReviewsByCarId(int carId)
        {
            var values = await mediator.Send(new GetReviewByCarIdQuery(carId));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await mediator.Send(command);
            return Ok("Yorum başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            await mediator.Send(new RemoveReviewCommand(id));
            return Ok("Yorum başarıyla silindi.");
        }

    }
}