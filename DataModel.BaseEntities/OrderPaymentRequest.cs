using DataModel.Infrastructure;

namespace DataModel.BaseEntities
{
    public  class OrderPaymentRequest : BaseEntity
    {
        public decimal RequestPaymentTotal { get; set; }
        public decimal? RequestPaymentDiscount { get; set; }
        public string RequestDocumentUrl { get; set; }
        public string RequestOrderNumber { get; set; }
        public long UserID { get; set; }
        public long? PaymentTransactionID { get; set; }
        public int Status { get; set; }
    }
}
