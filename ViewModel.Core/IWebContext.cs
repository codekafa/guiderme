using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Core
{
    public interface IWebContext
    {
        string UserID { get; set; }
        string ChannelID { get; set; }
        string IsActivedUser { get; set; }
        string UserRoles { get; set; }
    }
}
