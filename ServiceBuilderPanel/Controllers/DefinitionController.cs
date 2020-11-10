using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceBuilderPanel.Controllers
{
    public class DefinitionController : Controller
    {

        public DefinitionController()
        {

        }
        public IActionResult Categories()
        {

            return View();
        }

        public IActionResult CategoryProperties(long category_id)
        {
            return View();
        }

    }
}
