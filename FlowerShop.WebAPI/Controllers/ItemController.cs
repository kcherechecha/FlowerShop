using AutoMapper;
using FlowerShop.BLL.Interfaces.Services;
using FlowerShop.BLL.Models;
using FlowerShop.BLL.Models.InputModels;
using FlowerShop.BLL.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

            var items = _mapper.Map<IEnumerable<ItemVm>>(models);

            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemVm>> GetById([FromRoute] Guid id)
        {
            var model = await _itemService.GetById(id);

            var item = _mapper.Map<ItemVm>(model);

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add(ItemInputModel input)
        {
            var model = await ItemModel.Create(input.Id, input.Name, input.Photo, input.Description, input.Price, input.CategoryId);

            if(!string.IsNullOrEmpty(model.Error))
            {
                return BadRequest(model.Error);
            }

            var id = await _itemService.AddAsync(model.Item1);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest("Error deleting item");
            }

            await _itemService.DeleteAsync(id);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ItemInputModel input)
        {
            var model = await ItemModel.Create(input.Id, input.Name, input.Photo, input.Description, input.Price, input.CategoryId);

            if (!string.IsNullOrEmpty(model.Error))
            {
                return BadRequest(model.Error);
            }

            await _itemService.UpdateAsync(model.Item1);

            return Ok();
        }

        [HttpGet("wishlist/{userId}")]
        public async Task<ActionResult<IEnumerable<ItemListVm>>> GetItemInWishlist([FromRoute] Guid userId)
        {
            var models = await _itemService.GetWishlistItem(userId);

            var itemsList = _mapper.Map<IEnumerable<ItemListVm>>(models);

            return Ok(itemsList);
        }

        [HttpPost("wishlist")]
        public async Task<ActionResult> AddItemToWishlist(Guid itemId, Guid userId)
        {
            if (userId == Guid.Empty || itemId == Guid.Empty)
            {
                return BadRequest("Error adding item to wishlist");
            }

            await _itemService.AddItemToWishlist(itemId, userId);

            return Ok();
        }

        [HttpDelete("wishlist")]
        public async Task<ActionResult> DeleteItemFromWishlist(Guid itemId, Guid userId)
        {
            if (userId == Guid.Empty || itemId == Guid.Empty)
            {
                return BadRequest("Error adding item to wishlist");
            }

            await _itemService.DeleteItemFromWishlist(itemId, userId);

            return Ok();
        }

        [HttpGet("basket/{userId}")]
        public async Task<ActionResult<IEnumerable<ItemListVm>>> GetItemInBasket([FromRoute] Guid userId)
        {
            var models = await _itemService.GetItemInBasket(userId);

            var itemList = _mapper.Map<IEnumerable<ItemListVm>>(models);

            return Ok(itemList);
        }

        [HttpPost("bakset")]
        public async Task<ActionResult> AddItemToBasket(Guid userId, Guid itemId, int count)
        {
            if(userId == Guid.Empty || itemId == Guid.Empty || count < 0)
            {
                return BadRequest("Error adding item to basket");
            }

            var id = await _itemService.AddItemToBasket(itemId, userId, count);

            return Ok(id);
        }

        [HttpDelete("basket")]
        public async Task<ActionResult> DeleteItemFromBasket(Guid itemId, Guid userId)
        {
            if (userId == Guid.Empty || itemId == Guid.Empty)
            {
                return BadRequest("Error deleting item from basket");
            }

            await _itemService.DeleteItemFromBasket(itemId, userId);

            return Ok();
        }

        [HttpPatch("basket")]
        public async Task<ActionResult> UpdateItemInBasket(Guid userId, Guid itemId, int count)
        {
            if (userId == Guid.Empty || itemId == Guid.Empty || count < 0)
            {
                return BadRequest("Error updating item in basket");
            }

            await _itemService.UpdateItemCountInBasket(userId, itemId, count);

            return Ok();
        }
    }
}
