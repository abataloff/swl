using APIClient.v0;
using Microsoft.AspNetCore.Mvc;
using SWLWeb.Models;

namespace SWLWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly Client _apiClient;
        public AccountController(Client apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            _apiClient.LoginByEmail(model.Email);
            return Ok();
        }
    }
}