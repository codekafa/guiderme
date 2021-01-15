using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Views;
using ViewModel.Views.Request;
using ViewModel.Views.Service;

namespace Business.Service.Infrastructure
{
    public interface IRequestService
    {
        CommonResult AddNewRequest(NewRequestModel request);
        CommonResult AddNewRequestWitoutTransaction(NewRequestModel request);
        CommonResult GetMyRequestList(RequestSearchModel search);
        RequestDetailModel GetBookingDetailForView(long request_id, long currentUserId);
        CommonResult AddOrEditRequest(AddOrEditRequestModel request);
        CommonResult RemoveRequest(long booking_id, long value);
        CommonResult GetMyRequestHistoryList(RequestSearchModel search);
        CommonResult AvaibleRequests(BaseParamModel search);
        Task<CommonResult> PublishWaitingRequests(long userId);

        CommonResult GetBookingDetailByRelationID(long booking_id, long currentUserId);
    }
}
