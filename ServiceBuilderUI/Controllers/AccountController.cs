using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Authentication;
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
        IServiceService _serviceService;
        public AccountController(IUserService userService, IServiceService serviceService)
        {
            _userService = userService;
            _serviceService = serviceService;
        }

        [Route("my-profile")]
        public IActionResult MyProfile()
        {
            var userResult = _userService.GetUserViewModel(CurrentUserId.Value);
            return View(userResult);
        }

        [HttpPost]
        public async Task<CommonResult> UpdateProfileAsync(AddOrEditUserModel user)
        {
            user.ID = CurrentUserId.Value;
            var updateResult = _userService.UpdateUserForUI(user);

            if (updateResult.ActionCode == "1")
            {
                await HttpContext.SignOutAsync();
            }

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
            var list = _serviceService.GetServiceList(new ViewModel.Views.Service.ServiceSearchModel { UserID = CurrentUserId.Value , TakeRow = 100, PageIndex= 0 });
            return View(list);
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
