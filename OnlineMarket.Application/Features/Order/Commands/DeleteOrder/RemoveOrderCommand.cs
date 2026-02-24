using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineMarket.Domain.Entity;

namespace OnlineMarket.Application.Features.Order.Commands.DeleteOrder
{
    public record RemoveOrderCommand(Guid Id) : IRequest<Unit>;
}
