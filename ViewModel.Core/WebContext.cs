using System.Collections.Generic;

namespace ViewModel.Core
{
    public class WebContext
    {
        public string UserID { get; set; }
        public string ChannelID { get; set; }
        public string IsActivedUser { get; set; }
        public List<int> UserRoles { get; set; }

    }
}
