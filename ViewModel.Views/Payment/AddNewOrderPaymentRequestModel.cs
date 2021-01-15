using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Payment
{
    public class AddNewOrderPaymentRequestModel
    {

        public decimal OrderAmount { get; set; }
        public IFormFile DocumentPhoto { get; set; }
        public long UserID { get; set; }
    }
}
