using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineMarket.Application.DTOs.OrderDTOs;
using OnlineMarket.Application.Intefaces;
using OnlineMarket.Domain.Entity;

namespace OnlineMarket.Application.Features.Order.Queries.GetOrderById
{
    public class GetOrderByIdHandler : IRequestHandler <GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task <OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
          var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new Exception("Ошибка нахождения заказа по ID");
          return new OrderDto(order.Name, order.Id, order.Price, order.Status, order.Product);  
        }
    }
}
