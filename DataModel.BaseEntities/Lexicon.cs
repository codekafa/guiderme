using DataModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.BaseEntities
{
    public class Lexicon : BaseEntity
    {

        public string KeyValue { get; set; }
        public string TextValue { get; set; }
        public string LaunguageCode { get; set; }
        public int Type { get; set; }

        public int PageCode { get; set; }

    }
}
