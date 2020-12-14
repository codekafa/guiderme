using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Request
{
    public class AvaibleRequestListModel
    {
        public long ID { get; set; }
        public long RequestID { get; set; }
        public string ServiceName { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string RequestUserName { get; set; }
        public DateTime FinishDate { get; set; }

    }
}
