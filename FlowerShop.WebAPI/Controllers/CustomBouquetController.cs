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
    public class CustomBouquetController : ControllerBase
    {
        private readonly ICustomBouquetService _customBouquetService;
        private readonly IMapper _mapper;

        public CustomBouquetController(ICustomBouquetService customBouquetService, IMapper mapper)
        {
            _customBouquetService = customBouquetService;
            _mapper = mapper;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<CustomBouquetVm>>> Get()
        {
            var models = await _customBouquetService.GetAllAsync();

            return Ok(models);
        }

        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<CustomBouquetVm>> GetById([FromRoute] Guid id)
        {
            var model = await _customBouquetService.GetById(id);

            return Ok(model);
        }

        [HttpPost, Authorize]
        public async Task<ActionResult> Add([FromForm] CustomBouquetInputModel input)
        {
            var userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var model = await CustomBouquetModel.Create(Guid.NewGuid(), input.Photo, userId, input.UserDescription, input.RequestTime);

            if(!string.IsNullOrEmpty(model.Error))
            {
                return BadRequest(model.Error);
            }

            var id = await _customBouquetService.AddAsync(model.Item1);

            return Ok(id);
        }

        [HttpPut, Authorize]
        public async Task<ActionResult> Update(CustomBouquetInputModel input)
        {
            var userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var model = await CustomBouquetModel.Create(input.Id, input.Photo, userId, input.UserDescription, input.RequestTime);

            if (!string.IsNullOrEmpty(model.Error))
            {
                return BadRequest(model.Error);
            }

            await _customBouquetService.UpdateAsync(model.Item1);

            return Ok();
        }
    }
}
