using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ServiceBuilderPanel.Models;
using ViewModel.Views;

namespace ServiceBuilderPanel.Controllers
{
    [AuthorizeCustom]
    public class GalleryController : Controller
    {
        IGalleryService _galleryService;
        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }
        public IActionResult List()
        {

            var list = _galleryService.GetGalleryPhotos();
            return View(list);
        }

        [HttpPost]
        public IActionResult GalleryUpload()
        {
            var file = Request.Form.Files["Photo"];
            _galleryService.AddNewGallery(file);
            return RedirectToAction("List", "Gallery");
        }


        public CommonResult GenerateUri(int Width, int Heigth, long gallery_id)
        {
            var result = _galleryService.GenerateUriFormat(Width, Heigth, gallery_id);
            return result;
        }

    }
}
