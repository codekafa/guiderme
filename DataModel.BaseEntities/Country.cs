using System;
using System.Collections.Generic;
using System.Text;
using DataModel.Infrastructure;

namespace DataModel.BaseEntities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }
}
