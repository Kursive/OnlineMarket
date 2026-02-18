using Microsoft.AspNetCore.Mvc;
using MediatR;
using OnlineMarket.Application.Queries.GetOrderById;
using OnlineMarket.Application.Commands.DeleteOrder;
using OnlineMarket.Application.Commands.CreateOrder;
using OnlineMarket.Application.DTOs;
using OnlineMarket.Domain.Entity;
using System.Threading.Tasks;
using OnlineMarket.Application.Queries.GetAllOrders;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly IMediator _mediatR;

        public Controller(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByid(Guid id)
        {
            var result = await _mediatR.Send(new GetOrderByIdQuery(id));
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(Guid id)
        {
            var result = await _mediatR.Send(new DeleteOrderCommand(id));
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] OrderDto request)
        {
            var res= await _mediatR.Send(request);
            return Ok(res);
        }
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAll()
        {
            var result = await _mediatR.Send(new GetAllOrdersQuery());
            return Ok(result);
        }
    }
}
