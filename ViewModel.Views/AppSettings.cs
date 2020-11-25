using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Views
{
    public class AppSettings
    {
        public Logging Logging { get; set; }

        public EmailSettings EmailSettings { get; set; }

        public CloudinarySettings CloudinarySettings { get; set; }
        public string Secret { get; set; }
        public string AllowedHosts { get; set; }

        public string DefaultConnection { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }

        public string Warning { get; set; }

        public string Error { get; set; }
    }

    public class EmailSettings
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public int SmtpPost { get; set; }
        public string SmtpAddress { get; set; }

    }

    public class CloudinarySettings
    {

        public string CloudName { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }

    }
}
