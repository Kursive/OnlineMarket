using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineMarket.Application.DTOs.UserDto;

namespace OnlineMarket.Application.Features.Users.Queries.GetAllUsers
{
    public record GetAllUserQuery() : IRequest<List<UserDto>>; 
    
}
