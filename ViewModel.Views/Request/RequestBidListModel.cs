using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Request
{
    public class RequestBidListModel
    {
        public string GetFileNameFromUrl()
        {
            if (!string.IsNullOrWhiteSpace(ServicePhoto))
            {
                Uri uri = new Uri(ServicePhoto);
                return System.IO.Path.GetFileName(uri.LocalPath);
            }
            else
            {
                return "";
            }
        }
        public string ServicePhoto { get; set; }
        public string BidUserName { get; set; }
        public decimal ServiceCost { get; set; }
        public DateTime CreateDate { get; set; }

        public string ServiceName { get; set; }
        public long ServiceID { get; set; }
        public long      ID { get; set; }

    }
}
