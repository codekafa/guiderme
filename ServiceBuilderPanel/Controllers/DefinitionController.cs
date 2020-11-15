using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Microsoft.AspNetCore.Mvc;
using ServiceBuilderPanel.Models;
using ViewModel.Views;
using ViewModel.Views.Content;
using ViewModel.Views.Content.ServiceCategory;

namespace ServiceBuilderPanel.Controllers
{
    [AuthorizeCustom]
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
            AddOrEditCategoryModel result = new AddOrEditCategoryModel();
            var commonResult = _cService.GetCategory(category_id);
            var category = commonResult.Data as ServiceCategory;
            result.ID = category.ID;
            result.Name = category.Name;
            result.Url = category.Url;
            result.PhotoUrl = category.CategoryPhoto;
            result.ParentCategoryID = category.ParentServiceCategoryID;
            ViewBag.Category = result;

            var propertyListResult = _cService.GetCategoryPropertyList(category_id);
            ViewBag.CategroyProperties = propertyListResult.Data;
            return View();
        }

        [HttpPost]
        public IActionResult UpdateCategoryProperty(ServiceCategoryProperty prop)
        {
            var result = _cService.UpdateCategoryProperty(prop);
            return Json(result);
        }
        [HttpPost]
        public IActionResult AddCategoryProperty(ServiceCategoryProperty prop)
        {
            var result = _cService.AddCategoryProperty(prop);
            return Json(result);
        }

        [HttpPost]
        public IActionResult RemoveCategoryProperty(long property_id)
        {

            var result = _cService.RemoveCategoryProperty(property_id);
            return Json(result);

        }

    }
}
