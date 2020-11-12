using System;

namespace ViewModel.Views.User
{
    public class UserListModel : BaseParamModel
    {
        public long ID { get; set; }
        public DateTime  CreateDate { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string ProfilePhoto { get; set; }
        public bool IsMailActivated { get; set; }
        public bool IsMobileActivated { get; set; }
    }
}
