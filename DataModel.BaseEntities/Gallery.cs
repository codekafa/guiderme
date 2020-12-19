using DataModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.BaseEntities
{
    public class Gallery : BaseEntity
    {
        public string PhotoUrl { get; set; }
        public string ContentType { get; set; }
    }
}
