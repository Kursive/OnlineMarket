using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMarket.Application.DTOs;
using MediatR;
using OnlineMarket.Application.Intefaces;
namespace OnlineMarket.Application.Queries.GetAllOrders
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync(cancellationToken);
            return orders == null
                ? throw new ArgumentNullException("Ошибка заказов")
                : orders.Select(order => new OrderDto(order.Name,order.Id,order.Price,order.Status,order.Product)).ToList();
        }
    }
}
