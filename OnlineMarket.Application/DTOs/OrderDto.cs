using OnlineMarket.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.DTOs
{
    public record OrderDto(string Name,Guid Id,decimal Price,Status Status,int Product);
}
