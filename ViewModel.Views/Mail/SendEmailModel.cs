using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views.Mail
{
    public class SendEmailModel:BaseParamModel
    {

        public SendEmailModel()
        {
            To = new List<string>();
        }

        public List<string> To { get; set; }

        public string ToSingle { get; set; }
        public string Subject { get; set; }

        public string Body { get; set; }

        public bool IsHtml { get; set; }

        public List<byte[]> Attacments { get; set; }

    }

}
