using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Http;
using Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;
using static Common.Helpers.Enum;

namespace Business.Service
{



    public class GalleryService : IGalleryService
    {
        IUnitOfWork _uow;
        IFileService _fileService;
        public GalleryService(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _uow = unitOfWork;
            _fileService = fileService;
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

        public CommonResult GetGalleryPhotos()
        {
            CommonResult result = new CommonResult();
            var list = _uow.GalleryRepository.GetList(x => x.IsActive == true);
            result.IsSuccess = true;
            result.Data = list;
            return result;

        }


        public CommonResult AddNewGallery(IFormFile photo)
        {
            CommonResult result = new CommonResult();

            if (photo == null)
            {
                return result;
            }

            result = _fileService.SaveImage(photo, FileTypes.Gallery);

            if (result.IsSuccess)
            {
                string url = result.Data.ToString();
                Uri uri = new Uri(url);
                string fileName = System.IO.Path.GetFileName(uri.LocalPath);
                _uow.GalleryRepository.Add(new DataModel.BaseEntities.Gallery { ContentType = "_gallery", IsActive = true, PhotoName = fileName, PhotoUrl = url });
                _uow.SaveChanges();
                return new CommonResult(true, "");
            }
            else
            {
                return result;
            }
        }

        public CommonResult GenerateUriFormat(int width, int height, long gallery_id)
        {
            var galleyItem = _uow.GalleryRepository.Get(x => x.ID == gallery_id);
            string name = galleyItem.PhotoName;
            CommonResult result = new CommonResult();
            result.IsSuccess = true;
            string url = "https://res.cloudinary.com/servicebuilder/image/upload/w_" + width + ",h_" + height + "/" + name;
            result.Data = url;
            return result;
        }
    }
}
