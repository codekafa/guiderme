using DataModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.BaseEntities
{
    public class Service : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public string Photo { get; set; }
        public long? ServiceStartYear { get; set; }
        public long? CountryID { get; set; }
        public long? CityID { get; set; }
        public long UserID { get; set; }
        public long ServiceCategoryID { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public ServiceCategory ServiceCategory { get; set; }
        public User User { get; set; }
        public List<ServicePhoto> ServicePhoto { get; set; }

    }
}
