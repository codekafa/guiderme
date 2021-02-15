using System.Collections.Generic;

namespace ViewModel.Core
{
    public class WebContext : IWebContext
    {
        public string UserID { get; set; }
        public string ChannelID { get; set; }
        public string IsActivedUser { get; set; }
        public string UserRoles { get; set; }

    }
}
