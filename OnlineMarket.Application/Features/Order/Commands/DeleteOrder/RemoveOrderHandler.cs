using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineMarket.Application.Intefaces;
using OnlineMarket.Domain.Entity;

namespace OnlineMarket.Application.Features.Order.Commands.DeleteOrder
{
    public class RemoveOrderHandler : IRequestHandler <RemoveOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<RemoveOrderHandler> _logger;
        public RemoveOrderHandler(IOrderRepository orderRepository,ILogger<RemoveOrderHandler> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }
        public async Task<Unit> Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Нахождения заказа для удаления");
            var order= await _orderRepository.GetByIdAsync(request.Id, cancellationToken);
            if (order== null)
            {
                _logger.LogError("Ошибка удаления заказа");
                throw new ArgumentException($"Ошибка удаления закаказа с {request.Id}");
            }
            _orderRepository.Remove(order);
            await _orderRepository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
