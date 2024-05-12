using FlowerShop.UI.Common.Extensions;
using FlowerShop.UI.Models.CustomBouquet;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FlowerShop.UI.Controllers
{
    public class CustomBouquetController : Controller
    {
        private readonly HttpClient _httpClient;

        public CustomBouquetController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("FlowerShopApiClient");
        }


        public IActionResult CreateCustomBouquet()
        {
            var request = new CustomBouquetInputModel();

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomBouquet(CustomBouquetInputModel model)
        {

            model.Photo = await model.PhotoFile.ToByteArrayAsync();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["AccessToken"]);

            var response = await _httpClient.PostAsJsonAsync("api/CustomBouquet", model);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                var errorResponse = JsonSerializer.Deserialize<string>(responseContent);

                ModelState.AddModelError("", errorResponse);

                return View(model);
            }
        }
    }
}
