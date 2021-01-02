using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServiceBuilderUI.Controllers
{
    public class PaymentController : Controller
    {

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
    }


}
