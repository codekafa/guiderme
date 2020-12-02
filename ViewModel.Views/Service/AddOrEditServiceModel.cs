using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Service
{
    public class AddOrEditServiceModel
    {

        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public long ServiceStartYear { get; set; }
        public long CountryID { get; set; }
        public long CityID { get; set; }
        public bool IsActive { get; set; }
        public long ServiceCategoryID { get; set; }
        public long UserID { get; set; }
        public string Photo { get; set; }

        public List<string >ServiceImages { get; set; }
        public IFormFile MainPhoto { get; set; }
        public List<IFormFile> ServicePhotos { get; set; }


    }
}
