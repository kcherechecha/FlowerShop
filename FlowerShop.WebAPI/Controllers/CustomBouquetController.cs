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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomBouquetVm>>> Get()
        {
            var models = await _customBouquetService.GetAllAsync();

            var customBouquets = _mapper.Map<IEnumerable<CustomBouquetVm>>(models);

            return Ok(customBouquets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomBouquetVm>> GetById([FromRoute] Guid id)
        {
            var model = await _customBouquetService.GetById(id);

            var customBouquets = _mapper.Map<CustomBouquetVm>(model);

            return Ok(customBouquets);
        }

        [HttpPost]
        public async Task<ActionResult> Add(CustomBouquetInputModel input)
        {
            var model = await CustomBouquetModel.Create(input.Id, input.Photo, input.UserId, input.UserDescription, input.RequestTime);

            if(string.IsNullOrEmpty(model.Error))
            {
                return BadRequest(model.Error);
            }

            var id = await _customBouquetService.AddAsync(model.Item1);

            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> Update(CustomBouquetInputModel input)
        {
            var model = await CustomBouquetModel.Create(input.Id, input.Photo, input.UserId, input.UserDescription, input.RequestTime);

            if (string.IsNullOrEmpty(model.Error))
            {
                return BadRequest(model.Error);
            }

            await _customBouquetService.UpdateAsync(model.Item1);

            return Ok();
        }
    }
}
