using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineMarket.Application.Intefaces;
using OnlineMarket.Domain.Entity;

namespace OnlineMarket.Application.Commands.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order?>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository )
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order?> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var res =new Order(request.Name, request.Price, request.Product);
            res.Created();
            if (res == null)
            {
                res.NotCreated();
            }// правильно ли ? 
            await _orderRepository.CreateAsync(res, cancellationToken);
            await _orderRepository.SaveChangesAsync(cancellationToken);
            return res;
            
        }
    }
}
