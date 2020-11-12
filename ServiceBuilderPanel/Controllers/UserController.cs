using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Views;
using ViewModel.Views.User;

namespace ServiceBuilderPanel.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult List(int? page_id)
        {
            var search = new UserSearchModel { TakeRow = 20, PageIndex = 0 };

            if (page_id.HasValue)
                search.PageIndex = page_id.Value;

            var list = _userService.GetUserList(search);
            var count = _userService.GetUserListCount(search);
            ViewBag.Count = count;
            ViewBag.Select = search.PageIndex;
            return View(list);
        }
        [HttpPost]
        public IActionResult List(UserSearchModel search)
        {
            search.TakeRow = 20;
            var list = _userService.GetUserList(search);
            var count = _userService.GetUserListCount(search);
            ViewBag.Count = count;
            ViewBag.Select = search.PageIndex;
            ViewBag.Email = search.Email;
            ViewBag.IsMail = search.IsMailActivated;
            ViewBag.IsMobile = search.IsMobileActivated;
            return View(list);
        }

        public IActionResult UserDetail(long? user_id)
        {
            AddOrEditUserModel user = new AddOrEditUserModel();

            if (user_id.HasValue)
                user = _userService.GetUserViewModel(user_id.Value);

            if (user == null)
                user = new AddOrEditUserModel();

            return View(user);
        }

        [HttpPost]
        public IActionResult UserDetail(AddOrEditUserModel user)
        {
            CommonResult result = _userService.AddOrEditUserForAdmin(user);
            ViewBag.Result = result;

            if (result.IsSuccess)
            {
                var userdb = result.Data as User;
                user.ID = userdb.ID;
                user.PhotoUrl = userdb.ProfilePhoto;
            }
            return View(user);
        }

    }
}
