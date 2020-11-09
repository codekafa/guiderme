using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helpers
{
    public static class Enum
    {
        public enum LexiconTypes
        {
            Dictionary = 1,
            Alert = 2
        }

        public enum UserTypes
        {
            Servicer = 1,
            Customer = 2,
            Admin = 3,
            ServicerEndEmployer = 4
        }


        public enum OTPTypes
        {
            RegisterOTP = 1,
            EmailOTP =2
        }
    }
}
