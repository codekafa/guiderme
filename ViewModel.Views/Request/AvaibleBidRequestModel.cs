using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Request
{
    public class AvaibleBidRequestModel
    {

        public long RequestID { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int RequestStatus { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string CategoryName { get; set; }
        public long? RequestBidID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public string Email { get; set; }
        public List<RequestPorpertyModel> Properties { get; set; }

        public List<RequestBidListModel> Bids { get; set; }

    }
}
