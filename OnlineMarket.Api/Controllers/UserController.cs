using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Application.DTOs.UserDto;
using OnlineMarket.Application.DTOs.UserDTOs;
using OnlineMarket.Application.Features.Users.Commands.CreateUser;
using OnlineMarket.Application.Features.Users.Commands.DeleteUser;
using OnlineMarket.Application.Features.Users.Commands.UpdateUser;
using OnlineMarket.Application.Features.Users.Queries.GetAllUsers;
using OnlineMarket.Application.Features.Users.Queries.GetUserById;
using OnlineMarket.Domain.Entity;
using OnlineMarket.Domain.Enums;
using OnlineMarket.Infrastructure.Cache;
using OnlineMarket.Infrastructure.Implementations.Auth;
using System.Reflection.Metadata.Ecma335;

namespace OnlineMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;
        private readonly UsersCache _usersCache;

        public UserController(IMediator mediator, ILogger<UserController> logger, UsersCache usersCache)
        {
            _mediator = mediator;
            _logger = logger;
            _usersCache = usersCache;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            _logger.LogInformation("пользователь по {id} ",id);
            return Ok(user);
        }

        [HasPermission(Permissions.Read)]
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await _mediator.Send(new GetAllUserQuery());
            _logger.LogInformation("получение всех пользователей");
           return Ok(users);

        }

        [HttpGet("cache")]
        public async Task<ActionResult<List<User>>> GetAllCache()
        {
            var users = await _mediator.Send(new GetAllUserQuery());
            _logger.LogInformation("получение всех пользователей с помощью кэша");
            return await _usersCache.GetByAllUsers();
        }

        [HasPermission(Permissions.Create)]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserCreateDto request)
        {
            var user = await _mediator.Send(new CreateUserCommand(request.Name, request.Email, request.Password));
            _logger.LogInformation("создание пользователя");
            return Ok(user);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var user = await _mediator.Send(new RemoveUserCommand(id));
            _logger.LogInformation("удаление пользователя с {id}",id);
            return Ok("Пользователь удален");
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] UserCreateDto request, [FromRoute] Guid Id )
        {
            var user = await _mediator.Send(new UpdateUserCommand(Id,request.Name,request.Email,request.Password));
            _logger.LogInformation("обновление пользователя");
            if (user == null)
            {
              return  NoContent();
            }
            return Ok(user);
        }// либо написать отдельный контроллер выдачи роли при регистрации 
        //либо чтобы первый пользователь получал роль админа 
    }
}
