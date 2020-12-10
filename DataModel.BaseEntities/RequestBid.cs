using System;
using System.Collections.Generic;
using System.Text;
using DataModel.Infrastructure;

namespace DataModel.BaseEntities
{
    public class RequestBid : BaseEntity
    { 
        public long ServiceCategoryID { get; set; }
        public long ServiceRequestID { get; set; }
        public long ServiceID { get; set; }
        public long BidUserID { get; set; }
        public decimal BidCost { get; set; }
        public DateTime? ViewDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public DateTime? StartDate { get; set; }

        public decimal ServiceCost { get; set; }
    }
}
