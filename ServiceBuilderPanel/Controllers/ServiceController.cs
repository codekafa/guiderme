using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceBuilderPanel.Models;

namespace ServiceBuilderPanel.Controllers
{
    [AuthorizeCustom]
    public class ServiceController : Controller
    {
        public IActionResult List()
        {
            return View();
        }

        public IActionResult ServiceDetail(long service_id)
        {
            return View();
        }
    }
}
