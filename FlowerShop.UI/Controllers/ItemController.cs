using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace FlowerShop.UI.Controllers
{
    public class ItemController : Controller
    {
        private readonly HttpClient _httpClient;

        public ItemController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("FlowerShopApiClient");
        }

        public async Task<IActionResult> AddItemToBasket(Guid itemId, int count = 1)
        {
            if(itemId != Guid.Empty && count > 0)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["AccessToken"]);

                var response = await _httpClient.PostAsync($"api/item/bakset/{itemId}/{count}", null);

                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}
