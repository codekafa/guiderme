using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;
using ViewModel.Views.Request;
using ViewModel.Views.Service;

namespace Business.Service.Infrastructure
{
    public interface IRequestService
    {
        CommonResult AddNewRequest(NewRequestModel request);
        CommonResult GetMyRequestList(RequestSearchModel search);
        AddOrEditRequestModel GetBookingDetailForEdit(long value);
        CommonResult AddOrEditRequest(AddOrEditRequestModel request);
        CommonResult RemoveRequest(long booking_id, long value);
    }
}
