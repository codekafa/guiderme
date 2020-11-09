using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Core
{
    public class TokenResponseModel
    {
        public string  Token { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
