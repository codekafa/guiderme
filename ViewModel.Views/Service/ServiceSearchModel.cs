using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Service
{
    public class ServiceSearchModel : BaseParamModel
    {

        public long? ServiceID { get; set; }
        public long? UserID { get; set; }

        public long? CountryID { get; set; }

        public long? CityID { get; set; }

        public long? ServiceCategoryID { get; set; }

    }
}
