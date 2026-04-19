using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Features.Auth.Login
{
  public record LoginCommand(string Email,string Password) : IRequest<string>;
    
    
}
