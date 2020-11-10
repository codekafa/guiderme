using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using ViewModel.Views;
using static Common.Helpers.Enum;

namespace Business.Service
{
    public class FileService : IFileService
    {

        IHostingEnvironment _env;
        public FileService(IHostingEnvironment env)
        {
            _env = env;
        }
        public CommonResult SaveImage(IFormFile file, FileTypes fileType)
        {

            string path = "images/" + fileType.ToString() + "/";
            string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var myUniqueFileName = Convert.ToString(Guid.NewGuid());
            var FileExtension = Path.GetExtension(fileName);
            string newFileName = myUniqueFileName + FileExtension;

            fileName = Path.Combine(_env.WebRootPath, path) + $@"\{newFileName}";
            path = path + newFileName;
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            return new CommonResult { IsSuccess = true, Data = path };

        }
    }
}
