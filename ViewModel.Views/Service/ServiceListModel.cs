using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Service
{
    public class ServiceListModel : BaseParamModel
    {

        public int ID { get; set; }

        public string Phone { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ServiceCategory { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public long? ServiceStartYear { get; set; }
        public DateTime CreateDate { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public string Photo { get; set; }

        public string UserPhoto { get; set; }
        public string GetFileNameFromUrl()
        {
            if (!string.IsNullOrWhiteSpace(Photo))
            {
                Uri uri = new Uri(Photo);
                return System.IO.Path.GetFileName(uri.LocalPath);
            }
            else
            {
                return "";
            }
        }
        public string GetFileNameFromUserPhoto()
        {
            if (!string.IsNullOrWhiteSpace(UserPhoto))
            {
                Uri uri = new Uri(UserPhoto);
                return System.IO.Path.GetFileName(uri.LocalPath);
            }
            else
            {
                return "";
            }
        }
    }
}
