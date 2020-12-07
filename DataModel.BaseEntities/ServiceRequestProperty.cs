using DataModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.BaseEntities
{
    public class ServiceRequestProperty : BaseEntity
    {
        public long ServiceRequestID { get; set; }
        public long ServiceCategoryPropertyID { get; set; }
        public long UserID { get; set; }
        public string Value { get; set; }
    }
}
