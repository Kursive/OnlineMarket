using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMarket.Domain.Entity;

namespace OnlineMarket.Application.Features.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(Guid Id ,string Name,string Email,string Password) : IRequest<User>;
    
}
