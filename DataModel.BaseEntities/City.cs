using System;
using System.Collections.Generic;
using System.Text;
using DataModel.Infrastructure;

namespace DataModel.BaseEntities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public long CountryID { get; set; }
        public Country Country { get; set; }
    }
}
