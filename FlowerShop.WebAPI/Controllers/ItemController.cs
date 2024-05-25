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
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemVm>>> Get()
        {
            var models = await _itemService.GetAllAsync();

            return Ok(models);
        }
        
        [HttpGet("latest")]
        public async Task<ActionResult<IEnumerable<ItemVm>>> GetLatest()
        {
            var models = await _itemService.GetLatestAsync(6);

            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemVm>> GetById([FromRoute] Guid id)
        {
            var model = await _itemService.GetById(id);

            return Ok(model);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<Guid>> Add(ItemInputModel input)
        {
            var model = await ItemModel.Create(Guid.NewGuid(), input.Name, input.Photo, input.Description, input.Price, input.CategoryId);

            if(!string.IsNullOrEmpty(model.Error))
            {
                return BadRequest(model.Error);
            }

            var id = await _itemService.AddAsync(model.Item1);

            return Ok(id);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest("Error deleting item");
            }

            await _itemService.DeleteAsync(id);

            return Ok();
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update([FromForm] ItemInputModel input)
        {
            var model = await ItemModel.Create(input.Id, input.Name, input.Photo, input.Description, input.Price, input.CategoryId);

            if (!string.IsNullOrEmpty(model.Error))
            {
                return BadRequest(model.Error);
            }

            await _itemService.UpdateAsync(model.Item1);

            return Ok();
        }

        [HttpGet("wishlist/user"), Authorize]
        public async Task<ActionResult<IEnumerable<ItemListVm>>> GetItemInWishlist()
        {
            var userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var models = await _itemService.GetWishlistItem(userId);

            return Ok(models);
        }

        [HttpPost("wishlist/{itemId}"), Authorize]
        public async Task<ActionResult> AddItemToWishlist([FromRoute] Guid itemId)
        {
            var userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (userId == Guid.Empty || itemId == Guid.Empty)
            {
                return BadRequest("Error adding item to wishlist");
            }

            await _itemService.AddItemToWishlist(itemId, userId);

            return Ok();
        }

        [HttpDelete("wishlist/{itemId}"), Authorize]
        public async Task<ActionResult> DeleteItemFromWishlist([FromRoute] Guid itemId)
        {
            var userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (userId == Guid.Empty || itemId == Guid.Empty)
            {
                return BadRequest("Error adding item to wishlist");
            }

            await _itemService.DeleteItemFromWishlist(itemId, userId);

            return Ok();
        }

        [HttpGet("basket/user"), Authorize]
        public async Task<ActionResult<IEnumerable<ItemListVm>>> GetItemInBasket()
        {
            var userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var models = await _itemService.GetItemInBasket(userId);

            return Ok(models);
        }

        [HttpPost("bakset/{itemId}/{count}"), Authorize]
        public async Task<ActionResult> AddItemToBasket([FromRoute] Guid itemId, int count)
        {
            var userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (userId == Guid.Empty || itemId == Guid.Empty || count < 0)
            {
                return BadRequest("Error adding item to basket");
            }

            var id = await _itemService.AddItemToBasket(itemId, userId, count);

            return Ok(id);
        }

        [HttpDelete("basket/{itemId}"), Authorize]
        public async Task<ActionResult> DeleteItemFromBasket([FromRoute] Guid itemId)
        {
            var userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (userId == Guid.Empty || itemId == Guid.Empty)
            {
                return BadRequest("Error deleting item from basket");
            }

            await _itemService.DeleteItemFromBasket(itemId, userId);

            return Ok();
        }

        [HttpPatch("basket/{itemId}/{count}"), Authorize]
        public async Task<ActionResult> UpdateItemInBasket([FromRoute] Guid itemId, int count)
        {
            var userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (userId == Guid.Empty || itemId == Guid.Empty || count < 0)
            {
                return BadRequest("Error updating item in basket");
            }

            await _itemService.UpdateItemCountInBasket(userId, itemId, count);

            return Ok();
        }

        [HttpPost("wishlist-create")]
        public async Task<ActionResult> CreateWishlist()
        {
            var userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if(userId == Guid.Empty)
            {
                return BadRequest("Error creatig wishlist");
            }

            await _itemService.CreateWishlist(userId);

            return Ok();
        }
    }
}
