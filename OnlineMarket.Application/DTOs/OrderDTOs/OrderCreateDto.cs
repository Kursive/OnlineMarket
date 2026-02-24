using OnlineMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.DTOs.OrderDTOs
{
    public record OrderCreateDto(string Name, int Product);
}
