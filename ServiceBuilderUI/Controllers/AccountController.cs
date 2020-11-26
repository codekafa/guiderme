using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceBuilderUI.Models;

namespace ServiceBuilderUI.Controllers
{
    [AuthorizeCustom]
    public class AccountController : Controller
    {
        [Route("my-profile")]
        public IActionResult MyProfile()
        {
            return View();
        }

        [Route("my-bookings")]
        public IActionResult MyBookings()
        {
            return View();
        }

        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
        public PartialViewResult _GetUserMenu(string  menu)
        {

            switch (menu)
            {
                case "dashboard":
                    ViewBag.DashboardActive = "active";
                    break;
                case "profile":
                    ViewBag.ProfileActive = "active";
                    break;
                case "booking":
                    ViewBag.BookingActive = "active";
                    break;
                case "service":
                    ViewBag.ServiceActive = "active";
                    break;
                case "bid":
                    ViewBag.BidActive = "active";
                    break;
                default:
                    ViewBag.DashboardActive = "active";
                    break;
            }

            
            return PartialView();
        }
    }
}
