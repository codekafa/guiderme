using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Notification
{
    public class NotificationListModel
    {
        public string Url { get; set; }
        public long ID { get; set; }
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsRead { get; set; }
    }
}
