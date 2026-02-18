using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineMarket.Application.Intefaces;

namespace OnlineMarket.Application.Commands.DeleteOrder
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        public DeleteOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Guid> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var res = await _orderRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new Exception("заказ не найден ");
            await _orderRepository.DeleteAsync(res.Id, cancellationToken);
            await _orderRepository.SaveChangesAsync(cancellationToken);
            return res.Id;
        }
    }
}
