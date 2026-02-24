using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineMarket.Application.Intefaces;
using OnlineMarket.Application.DTOs.OrderDTOs;

namespace OnlineMarket.Application.Features.Order.Queries.GetAllOrders
{
    public class GetAllOrdersHandler : IRequestHandler <GetAllOrdersQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync(cancellationToken) ?? throw new ArgumentNullException("Ошибка получения всех заказов");
            return orders.Select(order => new OrderDto(order.Name, order.Id, order.Price,  order.Product))
                .ToList();
        }
    }
}
