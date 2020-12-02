using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ServiceBuilderUI.Models;
using ViewModel.Views;
using ViewModel.Views.Service;

namespace ServiceBuilderUI.Controllers
{
    [AuthorizeCustom]
    public class ServiceController : BaseController
    {
        IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        public IActionResult _GetServiceList(ServiceSearchModel search)
        {
            var list = _serviceService.GetServiceList(search);
            return View(list);
        }

        [Route("service-detail")]
        public IActionResult ServiceDetail(long? service_id)
        {
            AddOrEditServiceModel result = null;

            if (service_id.HasValue)
            {
                result = _serviceService.GetServiceDetailForEdit(service_id.Value);
            }

            if (result == null)
            {
                result = new AddOrEditServiceModel();
            }

            result.UserID = CurrentUserId.Value;

            return View(result);
        }

        [HttpPost]
        public CommonResult AddOrEditService(AddOrEditServiceModel request)
        {
            CommonResult result = new CommonResult();
            result = _serviceService.AddOrEditService(request);
            return result;

        }

    }
}
