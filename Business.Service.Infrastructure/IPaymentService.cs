using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Views;
using ViewModel.Views.Payment;

namespace Business.Service.Infrastructure
{
    public interface IPaymentService
    {
        CommonResult AddNewOrderPaymentRequest(AddNewOrderPaymentRequestModel requestModel);

        CommonResult GetOrderRequestList(OrderRequestPaymentSearchModel search);

        CommonResult ApproveOrderRequest(long order_reqeust_id);

        CommonResult UpdateUserBalance(long user_id, decimal topup);

        CommonResult RejectOrderRequest(long order_reqeust_id, string desc);
    }
}
