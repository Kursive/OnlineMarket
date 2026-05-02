using MediatR;
using OnlineMarket.Application.DTOs.UserDto;
using OnlineMarket.Application.DTOs.UserDTOs;
using OnlineMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Features.Auth.Register
{
     public record RegisterCommand (string Name,string Password,string Email) : IRequest<string>;
    
}
