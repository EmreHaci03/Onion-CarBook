using AutoMapper;
using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Commands.AuthorCommands;
using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Commands.BlogCommands;
using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Commands.CommentCommands;
using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Commands.FeatureCommands;
using CarBook.Application.Features.CQRS.Commands.FooterCommands;
using CarBook.Application.Features.CQRS.Commands.LocationCommands;
using CarBook.Application.Features.CQRS.Commands.PricingCommands;
using CarBook.Application.Features.CQRS.Commands.ServiceCommands;
using CarBook.Application.Features.CQRS.Commands.SocialMediaCommands;
using CarBook.Application.Features.CQRS.Commands.TagCloudCommands;
using CarBook.Application.Features.CQRS.Commands.TestimonialCommands;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Features.CQRS.Results.AuthorResults;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Features.CQRS.Results.BlogResults;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Features.CQRS.Results.CommentResults;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Features.CQRS.Results.FeatureResults;
using CarBook.Application.Features.CQRS.Results.FooterResults;
using CarBook.Application.Features.CQRS.Results.LocationResults;
using CarBook.Application.Features.CQRS.Results.PricingResults;
using CarBook.Application.Features.CQRS.Results.ReservationResults;
using CarBook.Application.Features.CQRS.Results.ServiceResults;
using CarBook.Application.Features.CQRS.Results.SocialMediaResults;
using CarBook.Application.Features.CQRS.Results.TagCloudResults;
using CarBook.Application.Features.CQRS.Results.TestimonialResults;
using CarBook.Domain.Entities;


namespace CarBook.Application.Features.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateCategoryCommand, BlogCategory>().ReverseMap();
            CreateMap<UpdateCategoryCommand, BlogCategory>().ReverseMap();
            CreateMap<GetCategoryQueryResult, BlogCategory>().ReverseMap();
            CreateMap<GetCategoryByIdQueryResult, BlogCategory>().ReverseMap();


            CreateMap<CreateCarCommand, Car>().ReverseMap();
            CreateMap<UpdateCarCommand, Car>().ReverseMap();
            CreateMap<GetCarQueryResult, Car>().ReverseMap();
            CreateMap<GetCarByIdQueryResult, Car>().ReverseMap();
            CreateMap<Car, GetCarWithBrandQueryResult>()
    .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName));

            CreateMap<Car, GetLast5CarsWithBrandsQueryResult>()
    .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName));



            //Nested property — bir class'ın içindeki başka bir class'ın property'sine erişmek demek.

            CreateMap<CreateAboutCommand, About>().ReverseMap();
            CreateMap<UpdateAboutCommand, About>().ReverseMap();
            CreateMap<GetAboutByIdQueryResult, About>().ReverseMap();
            CreateMap<GetAboutQueryResult, About>().ReverseMap();

 
            CreateMap<CreateTagCloudCommand, TagCloud>().ReverseMap();
            CreateMap<UpdateTagCloudCommand, TagCloud>().ReverseMap();
            CreateMap<GetTagCloudWithBlogNameQueryResult, TagCloud>().ReverseMap()
            .ForMember(dest => dest.BlogName, opt => opt.MapFrom(src => src.Blog.Title));


            CreateMap<CreateBannerCommand, Banner>().ReverseMap();
            CreateMap<UpdateBannerCommand, Banner>().ReverseMap();
            CreateMap<GetBannerByIdQueryResult, Banner>().ReverseMap();
            CreateMap<GetBannerQueryResult, Banner>().ReverseMap();


            CreateMap<CreateCommentCommand, Comment>().ReverseMap();
            CreateMap<GetCommentByIdQueryResult, Comment>().ReverseMap();
            CreateMap<GetCommentWithBlogNameQueryResult, Comment>().ReverseMap();
            CreateMap<GetCommentByBlogIdQueryResult, Comment>().ReverseMap()
            .ForMember(dest => dest.BlogName, opt => opt.MapFrom(src => src.Blog.Title));
            CreateMap<GetCommentWithBlogNameQueryResult, Comment>().ReverseMap()
           .ForMember(dest => dest.BlogName, opt => opt.MapFrom(src => src.Blog.Title));



            CreateMap<GetReservationQueryResult, Reservation>().ReverseMap();


            CreateMap<CreateBrandCommand, Brand>().ReverseMap();
            CreateMap<UpdateBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdQueryResult, Brand>().ReverseMap();
            CreateMap<GetBrandQueryResult, Brand>().ReverseMap();


            CreateMap<CreateContactCommand, Contact>().ReverseMap();
            CreateMap<UpdateContactCommand, Contact>().ReverseMap();
            CreateMap<GetContactByIdQueryResult, Contact>().ReverseMap();
            CreateMap<GetContactQueryResult, Contact>().ReverseMap();

            CreateMap<CreateFeatureCommand, Feature>().ReverseMap();
            CreateMap<UpdateFeatureCommand, Feature>().ReverseMap();
            CreateMap<GetFeatureQueryResult, Feature>().ReverseMap();
            CreateMap<GetFeatureByIdQueryResult, Feature>().ReverseMap();

            CreateMap<CreateFooterCommand, Footer>().ReverseMap();
            CreateMap<UpdateFooterCommand, Footer>().ReverseMap();
            CreateMap<GetFooterQueryResult, Footer>().ReverseMap();
            CreateMap<GetFooterByIdQueryResult, Footer>().ReverseMap();

            CreateMap<CreateLocationCommand, Location>().ReverseMap();
            CreateMap<UpdateLocationCommand, Location>().ReverseMap();
            CreateMap<GetLocationQueryResult, Location>().ReverseMap();
            CreateMap<GetLocationByIdQueryResult, Location>().ReverseMap();

            CreateMap<CreateSocialMediaCommand, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaCommand, SocialMedia>().ReverseMap();
            CreateMap<GetSocialMediaByIdQueryResult, SocialMedia>().ReverseMap();
            CreateMap<GetSocialMediaQueryResult, SocialMedia>().ReverseMap();

            CreateMap<CreateTestimonialCommand, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialCommand, Testimonial>().ReverseMap();
            CreateMap<GetTestimonialByIdQueryResult, Testimonial>().ReverseMap();
            CreateMap<GetTestimonialQueryResult, Testimonial>().ReverseMap();


            CreateMap<CreateServiceCommand, Service>().ReverseMap();
            CreateMap<UpdateServiceCommand, Service>().ReverseMap();
            CreateMap<GetServiceByIdQueryResult, Service>().ReverseMap();
            CreateMap<GetServiceQueryResult, Service>().ReverseMap();



            CreateMap<CreateAuthorCommand, Author>().ReverseMap();
            CreateMap<UpdateAuthorCommand, Author>().ReverseMap();
            CreateMap<GetAuthorByIdQueryResult, Author>().ReverseMap();
            CreateMap<GetAuthorQueryResult, Author>().ReverseMap();

            CreateMap<CreateBlogCommand, Blog>().ReverseMap();
            CreateMap<UpdateBlogCommand, Blog>().ReverseMap();
            CreateMap<GetBlogByIdQueryResult, Blog>().ReverseMap();
            CreateMap<GetLast3BlogsWithAuthorQueryResult, Blog>().ReverseMap()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.AuthorName))
            .ForMember(dest => dest.BlogCategoryName, opt => opt.MapFrom(src => src.BlogCategory.Name));
            CreateMap<GetBlogQueryResult, Blog>().ReverseMap()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.AuthorName))
            .ForMember(dest => dest.BlogCategoryName, opt => opt.MapFrom(src => src.BlogCategory.Name));
            CreateMap<GetBlogByIdQueryResult, Blog>().ReverseMap()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.AuthorName))
            .ForMember(dest => dest.BlogCategoryName, opt => opt.MapFrom(src => src.BlogCategory.Name));
            CreateMap<GetLast5BlogsWithAuthorQueryResult, Blog>().ReverseMap()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.AuthorName));

            CreateMap<CreatePricingCommand, Pricing>().ReverseMap();
            CreateMap<UpdatePricingCommand, Pricing>().ReverseMap();
            CreateMap<GetPricingByIdQueryResult, Pricing>().ReverseMap();
            CreateMap<GetPricingQueryResult, Pricing>().ReverseMap();



        }   
    }
}
