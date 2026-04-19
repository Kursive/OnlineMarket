using OnlineMarket.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Intefaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
