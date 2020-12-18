using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Views.Content;

namespace ServiceBuilderPanel.Controllers
{
    public class LexiconController : Controller
    {
        IContentService _contentService;
        public LexiconController(IContentService contentService)
        {      
            _contentService = contentService;
        }
        public IActionResult List()
        {
            var search = new LexiconSearchModel();
            return View(search);
        }

        [HttpPost]
        public IActionResult GetLexiconList(LexiconSearchModel search)
        {
            var result = _contentService.GetLexiconList(search);
            return PartialView(result);
        }
    }
}
