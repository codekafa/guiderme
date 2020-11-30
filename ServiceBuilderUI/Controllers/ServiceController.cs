using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Views.Service;

namespace ServiceBuilderUI.Controllers
{
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

        [Route("serive-detail/{service_id}")]
        public IActionResult ServiceDetail(long service_id)
        {
            var list = _serviceService.GetServiceDetail(service_id);
            return View(list);
        }

    }
}
