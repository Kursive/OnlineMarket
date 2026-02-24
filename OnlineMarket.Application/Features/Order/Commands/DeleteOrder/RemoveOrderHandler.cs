using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineMarket.Application.Intefaces;
using OnlineMarket.Domain.Entity;

namespace OnlineMarket.Application.Features.Order.Commands.DeleteOrder
{
    public class RemoveOrderHandler : IRequestHandler <RemoveOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        public RemoveOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Unit> Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
        {
            var order= await _orderRepository.GetByIdAsync(request.Id, cancellationToken);
            if (order== null)
            {
                throw new ArgumentException($"Ошибка удаления закаказа с {request.Id}");
            }
            _orderRepository.Remove(order);
            await _orderRepository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
