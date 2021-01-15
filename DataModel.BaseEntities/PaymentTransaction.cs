using DataModel.Infrastructure;

namespace DataModel.BaseEntities
{
    public class PaymentTransaction: BaseEntity
    {
        public int TransactionType { get; set; }

        public decimal PaymentTotal { get; set; }

        public decimal PaymentTaxTotal { get; set; }

        public long UserID { get; set; }

        public int Status { get; set; }

        public int ProcessType { get; set; }
    }
}
