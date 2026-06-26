using CarBook.Application.Features.CQRS.Queries.StatisticQueries;
using CarBook.Application.Features.CQRS.Results.StatisticResults;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllStatistic")]
        public async Task<IActionResult> GetAllStatistic()
        {
            var CarValues = await _mediator.Send(new GetCarCountQuery());
            var LastBlog = await _mediator.Send(new GetLastBlogNameQuery());
            var OldestCarWithBrand = await _mediator.Send(new GetOldestCarQuery());
            var NewestCarWithBrand = await _mediator.Send(new GetNewestCarQuery());
            var GetMostCommentedBlogTitle = await _mediator.Send(new GetMostCommentedBlogTitleQuery());
            var MostCarBrand = await _mediator.Send(new GetMostCarBrandQuery());
            var HighestCar = await _mediator.Send(new GetHighestMileageCarQuery());
            var FuelType = await _mediator.Send(new GetMostUsedFuelTypeQuery());
            var CheapestCar = await _mediator.Send(new GetCheapestCarQuery());
            var HighestCarPrice = await _mediator.Send(new GetHighestCarQuery());
            var TotalReservation = await _mediator.Send(new GetReservationCountQuery());
            var ManualCarCount = await _mediator.Send(new GetManualCarCountQuery());
            var AutomaticCarCount= await _mediator.Send(new GetAutomaticCarCountQuery());
            var FuelTypeStats = await _mediator.Send(new GetFuelTypeStatsQuery());
            return Ok(new
            {
                CarCount = CarValues.CarCount,
                LastBlogName = LastBlog.BlogName,
                LastBlogAuthor = LastBlog.AuthorName,
                OldestCarBrandName = OldestCarWithBrand.BrandName,
                OldestCarModel = OldestCarWithBrand.CarModel,
                NewestCarBrandName = NewestCarWithBrand.BrandName,
                NewestCarModel = NewestCarWithBrand.CarModel,
                MostCommentedBlogTitle = GetMostCommentedBlogTitle.BlogTitle,
                MostCommentedBlogCommentCount = GetMostCommentedBlogTitle.CommentCount,
                MostCarBrandName=MostCarBrand.BrandName,
                MostCarCount=MostCarBrand.CarCount,
                HighestCarMileage=HighestCar.HighestMileageCar,
                MileageValue=HighestCar.HighestMileage,
                MostUsedFuelType=FuelType.FuelType,
                FuelTypeCount=FuelType.FuelTypeCount,
                CarNameWithBrand=CheapestCar.CarName,
                CheapestCarPriceDay=CheapestCar.CheapestCarPriceDay,
                HighestPriceCar = HighestCarPrice.HighestPriceCarName,
                HighestCarDailyPrice = HighestCarPrice.HighestCarPriceDay,
                GetReservationCount= TotalReservation.ReservationCount,
                ManualCarCount= ManualCarCount.ManualCarCount,
                AutomaticCarCount = AutomaticCarCount.AutomaticCarCount,
                CarFuelType = FuelTypeStats.FuelTypeStats
            });
        }

    }

}
