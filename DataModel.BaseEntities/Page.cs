﻿using DataModel.Infrastructure;
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
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public bool IsPage { get; set; }
        public int PageCode { get; set; }
    }
}
