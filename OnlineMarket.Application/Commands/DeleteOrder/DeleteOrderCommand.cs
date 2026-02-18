using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineMarket.Domain.Entity;

namespace OnlineMarket.Application.Commands.DeleteOrder
{
    public record DeleteOrderCommand(Guid Id):IRequest<Guid>;//мб лучше в  Query
}
