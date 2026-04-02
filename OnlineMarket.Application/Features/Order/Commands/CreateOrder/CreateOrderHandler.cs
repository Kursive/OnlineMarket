using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineMarket.Application.Intefaces;
using OnlineMarket.Domain.Entity;

namespace OnlineMarket.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler <CreateOrderCommand, Orders?>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<CreateOrderHandler> _logger;
        public CreateOrderHandler(IOrderRepository orderRepository,ILogger<CreateOrderHandler> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }
        public async Task<Orders?> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            
            var order =new Orders(request.Name, request.Price, request.Product);
            if (order == null)
            {
                _logger.LogError("Ошибка создания заказа");
                throw new Exception("Ошибка создание заказа");
            }
            _logger.LogInformation("Заказ создан");
            await _orderRepository.CreateAsync(order, cancellationToken);
            await _orderRepository.SaveChangesAsync(cancellationToken);
            return order;
        }
    }
}
