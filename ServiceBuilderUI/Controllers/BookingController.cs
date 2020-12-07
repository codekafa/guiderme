using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ServiceBuilderUI.Models;
using System.Collections.Generic;
using ViewModel.Views;
using ViewModel.Views.Request;
using ViewModel.Views.Service;

namespace ServiceBuilderUI.Controllers
{
    [AuthorizeCustom]
    public class BookingController : BaseController
    {
        IRequestService _requestService;
        public BookingController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        public IActionResult _GetRequestList(RequestSearchModel search)
        {
            CommonResult list = _requestService.GetMyRequestList(search);
            return View(list);
        }

        [Route("booking-detail")]
        public IActionResult RequestDetail(long? booking_id)
        {
            AddOrEditRequestModel result = null;

            if (booking_id.HasValue)
            {
                result = _requestService.GetBookingDetailForEdit(booking_id.Value);
            }

            if (result == null)
            {
                result = new AddOrEditRequestModel();
            }

            result.UserID = CurrentUserId.Value;

            return View(result);
        }

        [HttpPost]
        public CommonResult CreateNewRequest(NewRequestModel request)
        {
            CommonResult result = new CommonResult();
            request.UserId = CurrentUserId.Value;
            result = _requestService.AddNewRequest(request);
            return result;

        }

        public CommonResult RemoveMyRequest(long booking_id)
        {
            CommonResult result = new CommonResult();
            result = _requestService.RemoveRequest(booking_id, CurrentUserId.Value);
            return result;
        }

    }
}
