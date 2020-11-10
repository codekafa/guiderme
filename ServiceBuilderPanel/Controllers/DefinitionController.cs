using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Views;
using ViewModel.Views.Content;
using ViewModel.Views.Content.ServiceCategory;

namespace ServiceBuilderPanel.Controllers
{
    public class DefinitionController : Controller
    {
        IContentService _cService;
        public DefinitionController(IContentService cService)
        {
            _cService = cService;
        }
        public IActionResult Categories()
        {
            var list = _cService.GetCategoryList();
            return View(list);
        }
        public IActionResult CategoryDetail(long? category_id)
        {
            AddOrEditCategoryModel result = new AddOrEditCategoryModel();
            if (category_id.HasValue)
            {
                var commonResult = _cService.GetCategory(category_id.Value);
                var category = commonResult.Data as ServiceCategory;
                result.ID = category.ID;
                result.Name = category.Name;
                result.Url = category.Url;
                result.PhotoUrl = category.CategoryPhoto;
                result.ParentCategoryID = category.ParentServiceCategoryID;
            }

            ViewData["ParentCategories"] = _cService.GetParentCategoryList().Data as List<CategoryListModel>;

            return View(result);
        }
        [HttpPost]
        public IActionResult CategoryDetail(AddOrEditCategoryModel category)
        {
            var result = _cService.AddOrEditCategory(category);
            ViewBag.Result = result;

            ViewData["ParentCategories"] = _cService.GetParentCategoryList().Data as List<CategoryListModel>;
            return View(category);
        }
        public IActionResult CategoryProperties(long category_id)
        {
            var list = _cService.GetCategoryPropertyList(category_id);
            return View(list);
        }

    }
}
