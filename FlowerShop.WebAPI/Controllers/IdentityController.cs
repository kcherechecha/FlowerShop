using FlowerShop.WebAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlowerShop.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var model = await _identityService.GetUser(userId);

            return Ok(model);
        }

        [HttpPatch, Authorize]
        public async Task<IActionResult> AddPhoneNumber(string number)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var confirm = await _identityService.AddPhoneNumber(number, userId);

            return Ok(confirm);
        }

        [HttpGet("role"), Authorize]
        public async Task<IActionResult> GetRole()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var role = await _identityService.GetRole(userId);

            return Ok(role);
        }
    }
}
