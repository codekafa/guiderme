using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceBuilderPanel.Controllers
{
    public class UserController : Controller
    {
        public IActionResult List()
        {
            return View();
        }

        public IActionResult UserDetail(long user_id)
        {
            return View();
        }

    }
}
