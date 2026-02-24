using OnlineMarket.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMarket.Domain.Enums;

namespace OnlineMarket.Application.DTOs.OrderDTOs
{
    public sealed record OrderDto(string Name, Guid Id, decimal Price, Status Status, int Product);
}
