using DataModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.BaseEntities
{
    public class Lexicon : BaseEntity
    {

        public string Key { get; set; }
        public string Value { get; set; }
        public string LaunguageCode { get; set; }
        public int Type { get; set; }

    }
}
