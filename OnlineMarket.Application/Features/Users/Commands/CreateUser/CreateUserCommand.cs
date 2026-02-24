using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineMarket.Domain.Entity;

namespace OnlineMarket.Application.Features.Users.Commands.CreateUser
{
    public record CreateUserCommand(string Name, string Email, string Password) : IRequest<User>;
}
