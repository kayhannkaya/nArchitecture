using Application.Features.Auths.Commands.Register;
using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]

        public async Task<ActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new()
            {
                userForRegisterDto = userForRegisterDto,
                ıpAddress = GetIpAddress()
            };

            RegisteredDto result = await Mediator.Send(registerCommand);
            SetRefreshedTokenToCookie(result.RefreshedToken);
            return Created("",result.AccessToken);
        }

        private void SetRefreshedTokenToCookie(RefreshToken refresToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true ,Expires=DateTime.Now.AddDays(7)};
            Response.Cookies.Append("refreshToken", refresToken.Token, cookieOptions);
        }
    }
}
