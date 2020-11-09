using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceBuilderPanel.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var id = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                 .Select(c => c.Value).SingleOrDefault();

            return View();
        }
    }
}
