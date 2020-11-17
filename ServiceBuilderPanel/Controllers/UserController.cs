using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service.Infrastructure;
using DataModel.BaseEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Views;
using ViewModel.Views.User;

namespace ServiceBuilderPanel.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult List()
        {
            var search = new UserSearchModel();
            return View(search);
        }


        public IActionResult GetUserList(UserSearchModel search)
        {
            var result = _userService.GetUserList(search);
            return PartialView(result);
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
