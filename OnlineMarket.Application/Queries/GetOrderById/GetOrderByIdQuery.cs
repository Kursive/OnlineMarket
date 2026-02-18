using MediatR;
using OnlineMarket.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Queries.GetOrderById
{
    public record GetOrderByIdQuery(Guid Id):IRequest<OrderDto>;
}
