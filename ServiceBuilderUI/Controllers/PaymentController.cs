using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ServiceBuilderUI.Models;
using ViewModel.Views.Payment;

namespace ServiceBuilderUI.Controllers
{
    [AuthorizeCustom]
    public class PaymentController : BaseController
    {

        IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [Route("payment")]
        public IActionResult Payment()
        {
            return View();
        }

        [Route("order-payment")]
        public IActionResult OrderPayment()
        {
            return View();
        }

        [Route("credit-payment")]
        public IActionResult CreditPayment()
        {
            return View();
        }

        [Route("my-payment-transactions")]
        public IActionResult PaymentTransactions()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddNewOrderPaymentRequest(AddNewOrderPaymentRequestModel requestModel)
        {
            requestModel.UserID = CurrentUserId.Value;
            var result = _paymentService.AddNewOrderPaymentRequest(requestModel);
            return Json(result);
        }


    }


}
