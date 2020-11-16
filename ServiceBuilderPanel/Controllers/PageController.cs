using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Microsoft.AspNetCore.Mvc;
using ServiceBuilderPanel.Models;

namespace ServiceBuilderPanel.Controllers
{
    [AuthorizeCustom]
    public class PageController : Controller
    {
        IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }
        public IActionResult GetPage(long page_id)
        {
            var result = _pageService.GetPage(page_id);
            return View(result);
        }

        [HttpPost]
        public IActionResult GetPage(Page pageModal)
        {
            var result = _pageService.UpdatePage(pageModal);
            return View(result);
        }
    }
}
