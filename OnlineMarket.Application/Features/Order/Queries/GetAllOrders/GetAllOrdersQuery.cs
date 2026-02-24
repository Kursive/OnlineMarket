using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineMarket.Application.DTOs.OrderDTOs;

namespace OnlineMarket.Application.Features.Order.Queries.GetAllOrders
{
    public record GetAllOrdersQuery() : IRequest <List<OrderDto>>;
}
