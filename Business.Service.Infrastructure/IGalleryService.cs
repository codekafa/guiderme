using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;

namespace Business.Service.Infrastructure
{
    public interface IGalleryService
    {
        CommonResult GetUrlWithContentType(string type);
    }
}
