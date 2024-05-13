using FlowerShop.UI.Models.Order;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace FlowerShop.UI.Controllers
{
    public class OrderController : Controller
    {
        private readonly HttpClient _httpClient;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("FlowerShopApiClient");
        }

        [HttpGet]
        public async Task<IActionResult> GetUserOrders()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["AccessToken"]);

            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<OrderVm>>("api/order/user");

                return View(response);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["AccessToken"]);

            try
            {
                var response = await _httpClient.GetFromJsonAsync<IEnumerable<OrderVm>>("api/order");

                return View(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public IActionResult CreateOrder(decimal totalPriceInput)
        {
            var request = new OrderInputModel() { OrderPrice = totalPriceInput};

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderInputModel model)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["AccessToken"]);

            var response = await _httpClient.PostAsJsonAsync("api/order", model);

            if(response.IsSuccessStatusCode)
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

        [HttpPatch]
        public async Task<ActionResult> UpdateItemOrderCount([FromBody] IEnumerable<ItemOrdersUpdate> itemsCountUpdate)
        {
            if (itemsCountUpdate.Count() < 1)
            {
                return BadRequest("Erorr updating order count");
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["AccessToken"]);

            var dataToSend = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(itemsCountUpdate), Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync($"api/order/item/count", dataToSend);

            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
