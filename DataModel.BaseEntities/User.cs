using DataModel.Infrastructure;
using System.Collections.Generic;

namespace DataModel.BaseEntities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int UserType { get; set; }
        public string ProfilePhoto { get; set; }
        public bool IsMailActivated { get; set; }
        public bool IsMobileActivated { get; set; }

        public decimal Balance { get; set; }
        public List<UserAddress> UserAddresses { get; set; }
    }
}
