using System;

namespace ViewModel.Views.Payment
{
    public class OrderPaymentRequestListModel
    {
        public long OrderRequestID { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get { return Amount + (Amount * (Discount / 100)); } }
        public string DocumentUrl { get; set; }
        public long UserID { get; set; }
    }

}
