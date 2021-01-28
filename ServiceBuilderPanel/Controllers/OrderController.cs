using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ViewModel.Views.Payment;
using static Common.Helpers.Enum;

namespace ServiceBuilderPanel.Controllers
{
    public class OrderController : Controller
    {

        IPaymentService _paymentService;
        public OrderController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult PartialGetOrders(OrderRequestPaymentSearchModel search)
        {
            search.TakeRow = 20;
            var result = _paymentService.GetOrderRequestList(search);
            return PartialView(result);
        }

        public IActionResult OrderDetail(long order_id)
        {
            OrderRequestPaymentSearchModel search = new OrderRequestPaymentSearchModel();
            search.TakeRow = 20;
            search.p0 = order_id;
            var result = _paymentService.GetOrderRequestList(search);
            return View(result);
        }



        public JsonResult ApproveOrderPayment(long order_request_id)
        {
            var result = _paymentService.ApproveOrderRequest(order_request_id);
            return Json(result);
        }

        public JsonResult RejectOrderPayment(long order_request_id,string description)
        {
            var result = _paymentService.RejectOrderRequest(order_request_id, description);
            return Json(result);
        }

    }
}
