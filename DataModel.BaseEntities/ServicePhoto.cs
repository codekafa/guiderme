using DataModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.BaseEntities
{
    public class ServicePhoto : BaseEntity
    {
        public string PhotoUrl { get; set; }
        public Service Service { get; set; }
    }
}
