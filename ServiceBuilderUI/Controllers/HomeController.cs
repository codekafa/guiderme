using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceBuilderUI.Models;
using ViewModel.Views.Content.ServiceCategory;
using ViewModel.Views.Service;

namespace ServiceBuilderUI.Controllers
{
    public class HomeController : BaseController
    {
        IContentService _contentService;
        IServiceService _serviceService;
        public HomeController(IContentService contentService, IServiceService serviceService)
        {
            _contentService = contentService;
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("main-page")]
        public IActionResult MainPage()
        {
            return View("Index");
        }

        [Route("about-us")]
        public IActionResult AboutUs()
        {
            return View();
        }

        [Route("processing-of-personel-data")]
        public IActionResult ProcessingOfPersonelData()
        {
            return View();
        }

        [Route("privacy-policy")]
        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        [Route("terms-of-use")]
        public IActionResult TermsOfUse()
        {
            return View();
        }

        [Route("contact-us")]
        public IActionResult Contact()
        {
            return View();
        }
        [Route("faq")]
        public IActionResult FAQ()
        {
            return View();
        }

        [Route("categories")]
        public IActionResult Categories()
        {
            var categoriesResult = _contentService.GetCategoryList(new CategorySearchModel { PageIndex = 0, TakeRow = 100 });
            return View(categoriesResult);
        }

        [Route("category/{categoryuri}")]
        public IActionResult ServiceListByCategory(string categoryuri)
        {
            var serviceResult = _serviceService.GetServiceList(new ServiceSearchModel { TakeRow = 100, PageIndex = 0, CategoryUri = categoryuri });
            return View(serviceResult);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
