using Business.Service.Infrastructure;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;

namespace Business.Service
{



    public class GalleryService : IGalleryService
    {
        IUnitOfWork _uow;
        public GalleryService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public CommonResult GetUrlWithContentType(string type)
        {
            CommonResult result = new CommonResult();
            var item = _uow.GalleryRepository.Get(x => x.ContentType == type);

            if (item != null)
            {
                result.IsSuccess = true;
                result.Data = item.PhotoUrl;
            }
            else
            {
                result.IsSuccess = false;
                result.Data = "";
            }

            return result;

        }
    }
}
