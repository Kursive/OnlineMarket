using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.DTOs.UserDTOs
{
    public record UserCreateDto(string Name, string Email, string Password);
    
}
