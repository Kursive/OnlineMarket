using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Application.Features.Auth.Login;
using OnlineMarket.Application.Features.Auth.Register;


namespace OnlineMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginCommand command)
        {
            var token = await _mediator.Send(command);

           HttpContext.Response.Cookies.Append("tasty-Cookies", token);
            return Ok(token);
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] RegisterCommand command)
        {
            var token = await _mediator.Send(command);

            HttpContext.Response.Cookies.Append("tasty-Cookies", token);
            return Ok(token);
        }
    }
}
