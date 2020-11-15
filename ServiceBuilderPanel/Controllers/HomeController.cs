using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceBuilderPanel.Models;

namespace ServiceBuilderPanel.Controllers
{
    [AuthorizeCustom]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
