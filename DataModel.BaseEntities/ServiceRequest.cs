using System;
using System.Collections.Generic;
using System.Text;
using DataModel.Infrastructure;

namespace DataModel.BaseEntities
{
    public class ServiceRequest : BaseEntity
    {
        public long UserID { get; set; }
        public long ServiceCategoryID { get; set; }
        public int ContactType { get; set; }

    }
}
