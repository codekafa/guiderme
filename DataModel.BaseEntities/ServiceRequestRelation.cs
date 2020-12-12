using System;
using System.Collections.Generic;
using System.Text;
using DataModel.Infrastructure;

namespace DataModel.BaseEntities
{
    public class ServiceRequestRelation : BaseEntity
    { 
        public long ServiceCategoryID { get; set; }
        public long ServiceRequestID { get; set; }
        public long ServiceID { get; set; }
        public long ServiceUserID { get; set; }
        public int Status { get; set; }
        public string RejectDescription { get; set; }
        public DateTime? ViewDate { get; set; }

    }
}
