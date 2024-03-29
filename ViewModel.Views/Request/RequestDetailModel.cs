﻿
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Request
{
    public class RequestDetailModel
    {
        public long UserID { get; set; }

        public string CategoryName { get; set; }

        public string CategoryPhoto { get; set; }

        public string CountryName { get; set; }

        public string CityName { get; set; }
        public string Description { get; set; }
        public long CountryID { get; set; }

        public long ServiceCategoryID { get; set; }
        public long CityID { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public bool IsPublish { get; set; }

        public long ID { get; set; }

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

        public List<RequestPorpertyModel> Properties { get; set; }

        public List<RequestBidListModel> Bids { get; set; }
    }
}
