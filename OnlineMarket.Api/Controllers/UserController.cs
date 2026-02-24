using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnlineMarket.Application.Features.Users.Queries.GetUserById;
using OnlineMarket.Domain.Entity;
using OnlineMarket.Application.Features.Users.Queries.GetAllUsers;
using OnlineMarket.Application.Features.Users.Commands.CreateUser;
using OnlineMarket.Application.DTOs.UserDto;
using OnlineMarket.Application.Features.Users.Commands.DeleteUser;

namespace OnlineMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

       public UserController(IMediator mediator)
       {
            _mediator = mediator;
       }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var user= await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(user);
        }


        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users= await _mediator.Send(new GetAllUserQuery());
            return Ok(users);
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserDto command)
        {
            var user = await _mediator.Send(command);
            return Ok(user);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id )
        {
            var user = await _mediator.Send(new RemoveUserCommand(id));
            return NoContent();
        }
    }
}
