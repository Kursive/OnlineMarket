using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Application.DTOs.OrderDTOs;
using OnlineMarket.Application.Features.Order.Commands.CreateOrder;
using OnlineMarket.Application.Features.Order.Commands.DeleteOrder;
using OnlineMarket.Application.Features.Order.Queries.GetAllOrders;
using OnlineMarket.Application.Features.Order.Queries.GetOrderById;
using OnlineMarket.Domain.Entity;
using OnlineMarket.Domain.Enums;
using OnlineMarket.Infrastructure.Implementations.Auth;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediatr;
        public OrderController(IMediator mediatr,ILogger<OrderController> logger)
        {
            _mediatr = mediatr;
            _logger = logger;
        }

        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var order = await _mediatr.Send(new GetOrderByIdQuery(id));
            _logger.LogInformation("Закаказ с таким {id} найден", id);
            return Ok(order);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Orders>>> GetAll()
        {
            var orders = await _mediatr.Send(new GetAllOrdersQuery());
            _logger.LogInformation("Все заказы получены");
            return Ok(orders);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(Guid id)
        {
            var order = await _mediatr.Send(new RemoveOrderCommand(id));
            _logger.LogInformation("заказ удален");
            return NoContent();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] OrderCreateDto request)
        {
            var order= await _mediatr.Send(new CreateOrderCommand(request.Name, request.Price, request.Product));
            _logger.LogInformation("Заказ добавлен");
            return Ok(order);
        }

    }
}
