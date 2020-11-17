using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ServiceBuilderPanel.Models;
using ViewModel.Views;
using ViewModel.Views.Service;

namespace ServiceBuilderPanel.Controllers
{
    [AuthorizeCustom]
    public class ServiceController : Controller
    {
        IServiceService _serviceService;
        IContentService _contentService;
        public ServiceController(IServiceService serviceService, IContentService contentService)
        {
            _serviceService = serviceService;
            _contentService = contentService;
        }
        public IActionResult List(long? category_id = null)
        {
            ServiceSearchModel search = new ServiceSearchModel();
            search.ServiceCategoryID = category_id;
            ViewBag.Countries = _contentService.GetCountries();
            ViewBag.Categories = _contentService.GetCategoryList();
            return View(search);
        }


        [HttpPost]
        public IActionResult GetServiceList(ServiceSearchModel search)
        {
            var result = _serviceService.GetServiceList(search);
            return PartialView(result);
        }

        public IActionResult ServiceDetail(long service_id)
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCities(long country_id)
        {
            var list = _contentService.GetCities(country_id);
            return Json(list);
        }
    }
}
