
using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;

namespace Business.Service
{
    public class PageService : IPageService
    {

        IPageRepository _pageRepo;

        public PageService(IPageRepository pageRepo)
        {
            _pageRepo = pageRepo;
        }

        public CommonResult GetPage(long page_id)
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
           var page = _pageRepo.Get(x => x.ID == page_id);
            result.Data = page;
            return result;
        }

        public CommonResult UpdatePage(Page pageModel)
        {
            CommonResult result = new CommonResult();
            try
            {
                pageModel.IsActive = true;

                if (!string.IsNullOrWhiteSpace(pageModel.Content))
                {
                    pageModel.Content = pageModel.Content.Replace("\"", "\'");
                }

                var updateResult = _pageRepo.Update(pageModel);
                result.IsSuccess = true;
                result.Data = updateResult;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
