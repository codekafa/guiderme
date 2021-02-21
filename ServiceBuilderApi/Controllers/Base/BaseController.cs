using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service.Common;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Core;

namespace GuiderMeApi.Controllers
{
    [ApiController]
    public class BaseController : Controller
    {
        public IWebContext CurrentUser { get { return IOC.resolve<IWebContext>(); } }

        public long CurrentUserID { get { return Convert.ToInt64(CurrentUser.UserID); } }
    }
}
