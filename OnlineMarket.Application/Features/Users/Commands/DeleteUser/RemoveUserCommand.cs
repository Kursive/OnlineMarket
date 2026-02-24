using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace OnlineMarket.Application.Features.Users.Commands.DeleteUser
{
    public record RemoveUserCommand(Guid Id) : IRequest<Unit>;
}
