using System.Collections;
using FlowerShop.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using FlowerShop.UI.Common.Extensions;
using FlowerShop.UI.Models.Category;
using FlowerShop.UI.Models.Item;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlowerShop.UI.Controllers
{
    public class ItemController : Controller
    {
        private readonly HttpClient _httpClient;

        public ItemController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("FlowerShopApiClient");
        }
        
        [HttpGet]
        public async Task<IActionResult> ShowFlowers()
        {
            var models = await _httpClient.GetFromJsonAsync<IEnumerable<ItemListVm>>("api/item/category/Flower");

            return View(models);
        }
        
        [HttpGet]
        public async Task<IActionResult> ShowBouquets()
        {
            var models = await _httpClient.GetFromJsonAsync<IEnumerable<ItemListVm>>("api/item/category/Bouquet");

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> CreateItem()
        {
            var categories = await _httpClient.GetFromJsonAsync<IEnumerable<CategoryVm>>("api/category");
            
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(InputItemModel model)
        {
            model.Photo = await model.PhotoFile.ToByteArrayAsync();
            
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["AccessToken"]);

            var response = await _httpClient.PostAsJsonAsync("api/item", model);

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
