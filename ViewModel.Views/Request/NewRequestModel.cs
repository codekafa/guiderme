using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Request
{
    public class NewRequestModel : BaseParamModel
    {
        public long UserId { get; set; }

        public long CategoryId { get; set; }

        public long CountryId { get; set; }

        public long CityId { get; set; }

        public string   Description { get; set; }

        public List<RequestPorpertyModel> Properties { get; set; }

        public bool IsPublish { get; set; }

    }
}
