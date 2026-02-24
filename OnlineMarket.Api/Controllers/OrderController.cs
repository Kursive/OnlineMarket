using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnlineMarket.Application.Features.Order.Queries.GetOrderById;
using OnlineMarket.Application.Features.Order.Commands.DeleteOrder;
using OnlineMarket.Domain.Entity;
using System.Threading.Tasks;
using OnlineMarket.Application.Features.Order.Queries.GetAllOrders;
using OnlineMarket.Application.DTOs.OrderDTOs;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public OrderController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetByid(Guid id)
        {
            var order = await _mediatr.Send(new GetOrderByIdQuery(id));
            return Ok(order);
        }


        [HttpGet]
        public async Task<ActionResult<List<Orders>>> GetAll()
        {
            var orders = await _mediatr.Send(new GetAllOrdersQuery());
            return Ok(orders);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(Guid id)
        {
            var order = await _mediatr.Send(new RemoveOrderCommand(id));
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] OrderDto request)
        {
            var order= await _mediatr.Send(request);
            return Ok(order);
        }

    }
}
