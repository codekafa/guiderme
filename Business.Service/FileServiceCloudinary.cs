using Business.Service.Infrastructure;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;
using static Common.Helpers.Enum;

namespace Business.Service
{
    public class FileServiceCloudinary : IFileService
    {
        IHostingEnvironment _env;

        AppSettings _appSettings;
        public FileServiceCloudinary(IHostingEnvironment env, IOptions<AppSettings> appSettings)
        {
            _env = env;
            _appSettings = appSettings.Value;
        }

        public CommonResult SaveImage(IFormFile file, FileTypes fileType)
        {
            Account account = new Account(_appSettings.CloudinarySettings.CloudName,
                                              _appSettings.CloudinarySettings.ApiKey,
                                             _appSettings.CloudinarySettings.ApiSecret);

            Cloudinary cloudinary = new Cloudinary(account);

            string fileName = Guid.NewGuid().ToString().Replace("-", "");

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, file.OpenReadStream()),
                PublicId = fileName
            };

            switch (fileType)
            {
                case FileTypes.ServiceCategoryFiles:
                    break;
                case FileTypes.ProfileFiles:
                    uploadParams.Folder = "profile";
                    break;
                case FileTypes.ServiceFiles:
                    uploadParams.Folder = "service";
                    break;
                case FileTypes.Gallery:
                    uploadParams.Folder = "gallery";
                    break;
                case FileTypes.OrderDocument:
                    uploadParams.Folder = "orderDocument";
                    break;
                default:
                    break;
            }

            var uploadResult = cloudinary.Upload(uploadParams);

            if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                return new CommonResult { IsSuccess = true, Data = uploadResult.SecureUrl.AbsoluteUri };
            else
                return new CommonResult { IsSuccess = false};

        }
    }
}
