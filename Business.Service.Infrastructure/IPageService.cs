using DataModel.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;

namespace Business.Service.Infrastructure
{
    public interface IPageService
    {

        CommonResult GetPages();
        CommonResult GetPage(long page_id);

        CommonResult UpdatePage(Page pageModel);

    }
}
