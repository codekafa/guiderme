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
        public long CountryID { get; set; }
        public long CityID { get; set; }
        public bool IsPublish { get; set; }

        public string Description { get; set; }
        public DateTime? FinishDate { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
