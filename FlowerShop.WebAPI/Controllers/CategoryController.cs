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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryVm>>> Get()
        {
            var models = await _categoryService.GetAllAsync();

            var categories = _mapper.Map<IEnumerable<CategoryVm>>(models);

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryVm>> GetById([FromRoute] Guid id)
        {
            var model = await _categoryService.GetById(id);

            var category = _mapper.Map<CategoryVm>(model);

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add(CategoryInputModel input)
        {
            var model = CategoryModel.Create(input.Id, input.Name);

            if(!string.IsNullOrEmpty(model.Error))
            {
                return BadRequest(model.Error);
            }

            var id = await _categoryService.AddAsync(model.Item1);

            return id;
        }

        [HttpPut]
        public async Task<ActionResult> Update(CategoryInputModel input)
        {
            var model = CategoryModel.Create(input.Id, input.Name);

            if (!string.IsNullOrEmpty(model.Error))
            {
                return BadRequest(model.Error);
            }

            await _categoryService.UpdateAsync(model.Item1);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove([FromRoute] Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest("No category id");
            }

            await _categoryService.DeleteAsync(id);

            return Ok();
        }
    }
}
