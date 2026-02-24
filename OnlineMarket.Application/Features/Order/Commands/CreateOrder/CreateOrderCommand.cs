using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineMarket.Domain.Entity;

namespace OnlineMarket.Application.Features.Order.Commands.CreateOrder
{
    public record CreateOrderCommand(string Name, decimal Price, int Product) : IRequest<Orders>;
}
