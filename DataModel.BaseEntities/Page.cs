using DataModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.BaseEntities
{
    public class Page : BaseEntity
    {
        public string PageName { get; set; }
        public string PageDescription { get; set; }
        public string Url { get; set; }
        public string Content { get; set; }
    }
}
