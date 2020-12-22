using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;

namespace Business.Service.Infrastructure
{
    public interface IGalleryService
    {
        CommonResult GetUrlWithContentType(string type);

        CommonResult GetGalleryPhotos();

        CommonResult AddNewGallery(IFormFile photo);

        CommonResult GenerateUriFormat(int width, int height, long gallery_id);
    }
}
