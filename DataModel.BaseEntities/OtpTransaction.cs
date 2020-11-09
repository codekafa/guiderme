using DataModel.Infrastructure;
using System;

namespace DataModel.BaseEntities
{
    public class OtpTransaction : BaseEntity
    {
        public int OTPType { get; set; }
        public string OTPCode { get; set; }
        public bool IsUsed { get; set; }
        public DateTime ExpireDate { get; set; }

        public User User { get; set; }
    }
}
