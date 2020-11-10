using DataModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.BaseEntities
{
    public class ServiceCategoryProperty : BaseEntity
    {
        public string Name { get; set; }

        public long ServiceCategoryID { get; set; }
        public ServiceCategory ServiceCategory { get; set; }
    }
}
