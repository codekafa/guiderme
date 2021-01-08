using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceBuilderUI.Models;
using ViewModel.Views;
using ViewModel.Views.Contact;
using ViewModel.Views.Content.ServiceCategory;
using ViewModel.Views.Service;

namespace ServiceBuilderUI.Controllers
{
    public class HomeController : BaseController
    {
        IContentService _contentService;
        IServiceService _serviceService;
        IMailService _mailService;
        ILexiconService _lexiconService;
        IExceptionManager _exceptionManager;
        public HomeController(IContentService contentService, IServiceService serviceService, IMailService mailService, ILexiconService lexiconService, IExceptionManager exceptionManager)
        {
            _contentService = contentService;
            _serviceService = serviceService;
            _mailService = mailService;
            _lexiconService = lexiconService;
            _exceptionManager = exceptionManager;
        }

        public IActionResult Index()
        {
            ViewBag.HideBreadCrumb = true;
            return View();
        }
        [Route("main-page")]
        public IActionResult MainPage()
        {
            ViewBag.HideBreadCrumb = true;
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


        public CommonResult SendContact(NewContactModel contact)
        {
            string body = "<br>";
            body += "First Name: " + contact.FirstName + "</br></br>";
            body += "Last Name: " + contact.LastName + "</br></br>";
            body += "Email: " + contact.Email + "</br></br>";
            body += "Phone: " + contact.Phone + "</br></br>";
            body += "Message: " + contact.Message + "</br></br>";
            var model = new ViewModel.Views.Mail.SendEmailModel { Body = body, IsHtml = true, Subject = "New Contact Form" };
            model.To.Add(_lexiconService.GetTextValue("_email_address", 5));
           return  _mailService.Send(model);
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
        public IActionResult Error(long exp_id)
        {
            var exp = _exceptionManager.GetException(exp_id);
            return View(exp);
        }
    }
}
