using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Request
{
    public class RequestListModel
    {
        public long UserID { get; set; }

        public string CategoryName { get; set; }

        public string CategoryPhoto { get; set; }

        public string CountryName { get; set; }

        public string CityName { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public bool IsPublish { get; set; }

        public long ID { get; set; }

        public int BidCount { get; set; }
        public string GetFileNameFromUrl()
        {
            if (!string.IsNullOrWhiteSpace(CategoryPhoto))
            {
                Uri uri = new Uri(CategoryPhoto);
                return System.IO.Path.GetFileName(uri.LocalPath);
            }
            else
            {
                return "";
            }
        }
    }
}
