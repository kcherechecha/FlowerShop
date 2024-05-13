using AutoMapper;
using FlowerShop.BLL.Interfaces.Services;
using FlowerShop.BLL.Models;
using FlowerShop.BLL.Models.InputModels;
using FlowerShop.BLL.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FlowerShop.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<OrderVm>>> Get()
        {
            var models = await _orderService.GetAllAsync();

            return Ok(models);
        }

        [HttpGet("user"), Authorize]
        public async Task<ActionResult<IEnumerable<OrderVm>>> GetByUser()
        {
            var userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var models = await _orderService.GetByUser(userId);

            return Ok(models);
        }

        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<OrderVm>> GetById(Guid id)
        {
            var model = await _orderService.GetById(id);

            return Ok(model);
        }

        [HttpPost, Authorize]
        public async Task<ActionResult<Guid>> Add(OrderInputModel input)
        {
            var userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var model = OrderModel.Create(Guid.NewGuid(), input.OrderAddress,input.PhoneNumber, input.OrderPrice, input.OrderTime, userId, input.OrderStatusId);

            if(!string.IsNullOrEmpty(model.Error))
            {
                return BadRequest(model.Error);
            }

            var id = await _orderService.AddAsync(model.Item1);

            return Ok(id);
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<ActionResult> Delete(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest("Error deleting order");
            }

            await _orderService.DeleteAsync(id);

            return Ok();
        }

        [HttpPut, Authorize]
        public async Task<ActionResult> Update(OrderInputModel input)
        {
            var userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var model = OrderModel.Create(input.Id, input.OrderAddress, input.PhoneNumber, input.OrderPrice, input.OrderTime, userId, input.OrderStatusId);

            if (string.IsNullOrEmpty(model.Error))
            {
                return BadRequest(model.Error);
            }

            await _orderService.UpdateAsync(model.Item1);

            return Ok();
        }

        [HttpPatch("item/count"), Authorize]
        public async Task<ActionResult> UpdateItemOrderCount([FromBody] IEnumerable<ItemOrdersCountUpdate> itemOrders)
        {
            var userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (itemOrders.Count() < 1)
            {
                return BadRequest("Erorr updating order count");
            }

            await _orderService.ChangeItemCount(itemOrders, userId);

            return Ok();
        }
    }
}
