using DataModel.Infrastructure;
using System;

namespace DataModel.BaseEntities
{
    public class Notification : BaseEntity
    {
        public long UserID { get; set; }
        public bool IsRead { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }
}
