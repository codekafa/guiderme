using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Service
{
    public class AddOrEditServiceModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public long? ServiceStartYear { get; set; }
        public long? CountryID { get; set; }
        public long? CityID { get; set; }
        public bool IsActive { get; set; }
        public long Country { get; set; }
        public long City { get; set; }
        public long ServiceCategoryID { get; set; }
        public long UserID { get; set; }
        public IFormFile MainPhoto { get; set; }
        public List<IFormFile> ServicePhotos { get; set; }


    }
}
