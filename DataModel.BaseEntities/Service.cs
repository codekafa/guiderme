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

        public ServiceCategory ServiceCategory { get; set; }
        public User User { get; set; }

    }
}
