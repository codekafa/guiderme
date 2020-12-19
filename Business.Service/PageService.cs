
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

        IUnitOfWork _uow;
        public PageService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }


        public CommonResult GetPages()
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            var pages = _uow.PageRepository.GetList(x => x.IsActive == true);
            result.Data = pages;
            return result;
        }

        public CommonResult GetPage(long page_id)
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
           var page = _uow.PageRepository.Get(x => x.ID == page_id);
            result.Data = page;
            return result;
        }

        public CommonResult GetPageByCode(long page_code)
        {
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            var page = _uow.PageRepository.Get(x => x.PageCode == page_code);
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

                var updateResult = _uow.PageRepository.Update(pageModel);
                _uow.SaveChanges();
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
