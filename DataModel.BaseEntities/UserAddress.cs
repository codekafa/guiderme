using DataModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.BaseEntities
{
    public class UserAddress : BaseEntity
    {
        public int AddressType { get; set; }

        public string ZoneNumber { get; set; }

        public string StreetNumber { get; set; }
        public string BuildingNumber { get; set; }

        public string UnitNumber { get; set; }

        public string Description { get; set; }

        public User User { get; set; }
    }
}
