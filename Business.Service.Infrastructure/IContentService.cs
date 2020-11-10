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

        CommonResult RemoveICategoryProperty(ServiceCategoryProperty item);

        CommonResult AddOrEditCategory(AddOrEditCategoryModel category);

    }
}
