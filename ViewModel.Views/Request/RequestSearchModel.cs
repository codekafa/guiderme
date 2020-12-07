using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Request
{
    public class RequestSearchModel : BaseParamModel
    {
        public long? UserID { get; set; }
        public long? ServiceCategoryID { get; set; }

        public bool IsPublish { get; set; }
    }
}
