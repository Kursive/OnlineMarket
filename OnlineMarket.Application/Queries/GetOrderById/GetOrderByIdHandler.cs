using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineMarket.Application.DTOs;
using OnlineMarket.Application.Intefaces;
using OnlineMarket.Domain.Entity;

namespace OnlineMarket.Application.Queries.GetOrderById
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task <OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);
            return result == null
                ? throw new Exception("Ошибка нахождения заказа по ID")
                : new OrderDto(result.Name, result.Id, result.Price, result.Status, result.Product);
        }
    }
}
