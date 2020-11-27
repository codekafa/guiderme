using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceBuilderUI.Controllers
{
    public class TemplateController : BaseController
    {
        public IActionResult EmailOtp()
        {
            return View();
        }
    }
}
