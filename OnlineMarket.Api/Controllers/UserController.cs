using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnlineMarket.Application.Features.Users.Queries.GetUserById;
using OnlineMarket.Domain.Entity;
using OnlineMarket.Application.Features.Users.Queries.GetAllUsers;
using OnlineMarket.Application.Features.Users.Commands.CreateUser;
using OnlineMarket.Application.DTOs.UserDTOs;
using OnlineMarket.Application.Features.Users.Commands.DeleteUser;
using OnlineMarket.Application.Features.Users.Commands.UpdateUser;
using OnlineMarket.Application.DTOs.UserDto;

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
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(user);
        }


        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await _mediator.Send(new GetAllUserQuery());
            return Ok(users);
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserCreateDto request)
        {
            var user = await _mediator.Send(new CreateUserCommand(request.Name, request.Email, request.Password));
            return Ok(user);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var user = await _mediator.Send(new RemoveUserCommand(id));
            return Ok("Пользователь удален");
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] UserCreateDto request, [FromRoute] Guid Id )
        {
            var user = await _mediator.Send(new UpdateUserCommand(Id,request.Name,request.Email,request.Password));
            if(user == null)
            {
              return  NoContent();
            }
            return Ok(user);
        }
    }
}
