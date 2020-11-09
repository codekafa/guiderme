using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Infrastructure
{
    public class BaseEntity : IEntity
    {
        public long ID { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
