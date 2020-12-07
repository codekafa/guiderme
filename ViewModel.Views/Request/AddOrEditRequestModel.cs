using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Request
{
    public class AddOrEditRequestModel 
    {
        public long ID { get; set; }
        public long UserID { get; set; }

        public string CategoryName { get; set; }

        public long ServiceCategoryID { get; set; }

        public long CountryID { get; set; }

        public string Description { get; set; }
        public long CityID { get; set; }

    }
}
