using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.User
{
    public class CurrentUserModel
    {
        public long ID { get; set; }

        public int UserType  { get; set; }
        public string ProfilePhoto { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsMobileActivation { get; set; }

        public bool IsMailActivation { get; set; }

        public string  FullName { get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
