using FlowerShop.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlowerShop.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("FlowerShopApiClient");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var models = await _httpClient.GetFromJsonAsync<IEnumerable<ItemListVm>>("api/item/latest");

            return View("Index", models);
        }
    }
}
