using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineMarket.Application.Intefaces;
using OnlineMarket.Domain.Entity;

namespace OnlineMarket.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler <CreateOrderCommand, Orders?>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Orders?> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order =new Orders(request.Name, request.Price, request.Product);
            if (order == null)
            {
                order.NotCreated();
                throw new Exception("заказ не создан");
            }
            order.Created();
            await _orderRepository.CreateAsync(order, cancellationToken);
            await _orderRepository.SaveChangesAsync(cancellationToken);
            return order;
        }
    }
}
