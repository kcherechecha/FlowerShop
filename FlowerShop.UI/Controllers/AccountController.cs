using FlowerShop.UI.Models;
using FlowerShop.UI.Models.ErrorModel;
using FlowerShop.UI.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FlowerShop.UI.Controllers
{
    public class AccountController : Controller
    {

        private readonly HttpClient _httpClient;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("FlowerShopApiClient");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            if (string.IsNullOrEmpty(Request.Cookies["AccessToken"]))
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["AccessToken"]);

                var user = await _httpClient.GetFromJsonAsync<UserVm>("api/identity");

                return View(user);
            }
        }


        [HttpGet]
        public IActionResult Login()
        {
            if (!string.IsNullOrEmpty(Request.Cookies["AccessToken"]))
            {
                return RedirectToAction(nameof(Profile));
            }

            var request = new LoginUser();

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUser model)
        {
            if (!string.IsNullOrEmpty(Request.Cookies["AccessToken"]))
            {
                return RedirectToAction(nameof(Profile));
            }

            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/login", model);
                if (response.IsSuccessStatusCode)
                {
                    string tokenAsString = await response.Content.ReadAsStringAsync();

                    var token = JsonSerializer.Deserialize<Token>(tokenAsString);

                    Response.Cookies.Append("AccessToken", token.accessToken, new CookieOptions
                    {
                        HttpOnly = true, 
                        Expires = DateTimeOffset.Now.AddHours(1), 
                        IsEssential = true 
                    });

                    Response.Cookies.Append("RefreshToken", token.refreshToken, new CookieOptions
                    {
                        HttpOnly = true,
                        Expires = DateTimeOffset.Now.AddHours(24),
                        IsEssential = true
                    });

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Користувач не знайдений");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (!string.IsNullOrEmpty(Request.Cookies["AccessToken"]))
            {
                return RedirectToAction(nameof(Profile));
            }

            var request = new RegisterUser();

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser model)
        {
            if (!string.IsNullOrEmpty(Request.Cookies["AccessToken"]))
            {
                return RedirectToAction(nameof(Profile));
            }

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/register", model);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                var errorResponse = JsonSerializer.Deserialize<RegisterErrorResponse>(responseContent);

                foreach (var error in errorResponse.errors.SelectMany(x => x.Value))
                {
                    ModelState.AddModelError("", error);
                }

                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (!string.IsNullOrEmpty(Request.Cookies["AccessToken"]))
            {
                Response.Cookies.Delete("AccessToken");
                Response.Cookies.Delete("RefreshToken");

                return RedirectToAction("Index", "Home");
            }

            return BadRequest();
        }
    }
}
