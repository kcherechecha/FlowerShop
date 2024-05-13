using FlowerShop.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

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
                    return StatusCode((int)response.StatusCode);
                }
                
            }

            return BadRequest();
        }

        public async Task<IActionResult> DeleteItemFromBasket(Guid itemId)
        {
            if (itemId != Guid.Empty)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["AccessToken"]);

                var response = await _httpClient.DeleteAsync($"api/item/basket/{itemId}");

                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }

            }

            return BadRequest();
        }

        public async Task<IActionResult> AddItemToWishlist(Guid itemId)
        {
            if (itemId != Guid.Empty)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["AccessToken"]);

                var response = await _httpClient.PostAsync($"api/item/wishlist/{itemId}", null);

                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }

            }

            return BadRequest();
        }

        public async Task<IActionResult> DeleteItemFromWishlist(Guid itemId)
        {
            if (itemId != Guid.Empty)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["AccessToken"]);

                var response = await _httpClient.DeleteAsync($"api/item/wishlist/{itemId}/");

                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }

            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> ShowBasket()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["AccessToken"]);

            try
            {
                var items = await _httpClient.GetFromJsonAsync<IEnumerable<ItemListVm>>($"api/item/basket/user");

                return View(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ShowWishlist()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["AccessToken"]);

            try
            {
                var items = await _httpClient.GetFromJsonAsync<IEnumerable<ItemListVm>>($"api/item/wishlist/user");

                return View(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
