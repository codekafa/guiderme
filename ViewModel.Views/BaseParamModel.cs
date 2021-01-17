using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views
{
    public class BaseParamModel
    {

        public int TakeRow { get; set; }
        public int PageIndex { get; set; }
        public string CultureCode { get; set; }
        public string Token { get; set; }
        public long CurrentUserId { get; set; }
        public object p0 { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
