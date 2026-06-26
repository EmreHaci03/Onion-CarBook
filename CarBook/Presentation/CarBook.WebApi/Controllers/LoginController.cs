using CarBook.Application.Features.CQRS.Queries.AppUserQueries;
using CarBook.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public LoginController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }


        [HttpPost]
        public async Task<IActionResult> Login(GetCheckAppUserQuery query)
        {
            if (query == null)
                throw new Exception("Böyle Bir Kayıt Bulunmamaktadır.");

            var values =await  _mediator.Send(query);
            if (values.IsExist)
            {
                var generator = new JwtTokenGenerator(_configuration);
                var token = generator.GenerateToken(values);
                return Created("", token);
            }
            else
            {
                return BadRequest("Kullanıcı Adı Veya Şifre Hatalıdır.");
            }
        }
    }
}
