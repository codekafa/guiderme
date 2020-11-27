using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ServiceBuilderUI.Models;
using ViewModel.Views;
using ViewModel.Views.Security;
using ViewModel.Views.User;

namespace ServiceBuilderUI.Controllers
{
    [AuthorizeCustom]
    public class AccountController : BaseController
    {
        IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("my-profile")]
        public IActionResult MyProfile()
        {
            var userResult = _userService.GetUserViewModel(CurrentUserId.Value);
            return View(userResult);
        }

        [HttpPost]
        public CommonResult UpdateProfile(AddOrEditUserModel user)
        {
            user.ID = CurrentUserId.Value;
            var updateResult = _userService.UpdateUserForUI(user);
            return updateResult;
        }

        [Route("my-bookings")]
        public IActionResult MyBookings()
        {
            return View();
        }

        [Route("my-services")]
        public IActionResult MyServices()
        {
            return View();
        }

        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }


        [Route("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        
        }
        [HttpPost]
        public CommonResult ChangePassword(ChangePasswordModel pass)
        {
            pass.CurrentUserId = CurrentUserId.Value;
            var updateResult = _userService.ChangePassword(pass);
            return updateResult;
        }

        public PartialViewResult _GetUserMenu(string menu)
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
