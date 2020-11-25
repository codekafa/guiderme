using DataModel.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;
using ViewModel.Views.Content;
using ViewModel.Views.Content.ServiceCategory;

namespace Business.Service.Infrastructure
{
    public interface IContentService
    {
        CommonResult GetCategoryList();

        CommonResult GetParentCategoryList();
        CommonResult GetCategory(long category_id);

        CommonResult AddCategory(ServiceCategory item);

        CommonResult UpdateCategory(ServiceCategory item);

        CommonResult RemoveCategory(ServiceCategory item);

        CommonResult GetCategoryPropertyList(long category_id);

        CommonResult AddCategoryProperty(ServiceCategoryProperty item);

        CommonResult UpdateCategoryProperty(ServiceCategoryProperty item);

        CommonResult RemoveCategoryProperty(long item_id);

        CommonResult GetCountries();

        CommonResult GetCities(long country_id);

        CommonResult AddOrEditCategory(AddOrEditCategoryModel category);


        CommonResult GetCategoryList(CategorySearchModel search);


        List<CategoryAutoCompleteModel> GetCategoryAutoCompleteList(string keys);

    }
}
