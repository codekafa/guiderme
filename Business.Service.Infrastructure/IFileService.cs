using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;
using static Common.Helpers.Enum;

namespace Business.Service.Infrastructure
{
    public interface IFileService
    {
        public CommonResult SaveImage(IFormFile file, FileTypes fileType);
    }
}
