using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceBuilderPanel.Models;
using ViewModel.Views.Security;

namespace ServiceBuilderPanel.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ISecurityService _securityService;
        public AccountController(ILogger<AccountController> logger, ISecurityService securityService)
        {
            _logger = logger;
            _securityService = securityService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserModel user)
        {

            var loginResult = _securityService.GetLoginUser(user);

            if (loginResult.IsSuccess)
            {
                var userModel = loginResult.Data as User;
                var claims = new List<Claim>
                                    {
                                        new Claim(ClaimTypes.Name, userModel.Email),
                                        new Claim(ClaimTypes.NameIdentifier,userModel.ID.ToString())
                                    };

                var userIdentity = new ClaimsIdentity(claims, "Cookies");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
