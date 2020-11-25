using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ServiceBuilderUI.Models;
using ViewModel.Views.Content.ServiceCategory;

namespace ServiceBuilderUI.Controllers
{
    public class ContentController : Controller
    {
        IContentService _contentService;
        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public JsonResult AutoComplateCategroy(string query)
        {

            var result =  _contentService.GetCategoryAutoCompleteList(query);
            return Json(result);
        }

    }
}
