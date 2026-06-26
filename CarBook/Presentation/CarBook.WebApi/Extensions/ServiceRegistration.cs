using CarBook.Application.Features.CQRS.Handlers.FeatureHandlers;
using CarBook.Application.Features.Mapping;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.Interfaces.CommentInterfaces;
using CarBook.Application.Interfaces.IAppUserInterfaces;
using CarBook.Application.Interfaces.ICarFeatureInterfaces;
using CarBook.Application.Interfaces.IRentACarInterfaces;
using CarBook.Application.Interfaces.IReservationInterfaces;
using CarBook.Application.Interfaces.IReviewInterfaces;
using CarBook.Application.Interfaces.IStatisticInterfaces;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Persistance.Context;
using CarBook.Persistance.Repositories.BlogRepositories;
using CarBook.Persistance.Repositories.CarPricingRepositories;
using CarBook.Persistance.Repositories.CarRepositories;
using CarBook.Persistance.Repositories.CommentRepositories;
using CarBook.Persistance.Repositories.IAppUserRepositories;
using CarBook.Persistance.Repositories.RentACarRepositories;
using CarBook.Persistance.Repositories.ReservationRepositories;
using CarBook.Persistance.Repositories.ReviewRepositories;
using CarBook.Persistance.Repositories.StatisticRepositories;
using CarBook.Persistance.Repositories.TagCloudRepositories;
using CarBook.Persistance.Repository;

namespace CarBook.WebApi.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ITagCloudRepository, TagCloudRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IStatisticRepository, StatisticRepository>();
            services.AddScoped<IRentACarRepository, RentACarRepository>();
            services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
            services.AddScoped<ICarDescriptionRepository, CarDescriptionRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<ICarPricingRepository, CarPricingRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
        }
    }
}
