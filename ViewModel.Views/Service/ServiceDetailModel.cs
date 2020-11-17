using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Service
{
    public class ServiceDetailModel : BaseParamModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ServiceCategory { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public long? ServiceStartYear { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public List<string> Photos { get; set; }


    }
}
