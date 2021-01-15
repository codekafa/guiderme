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
        public enum LoginTypes
        {
            Web = 1,
            Google = 2,
            Facebook = 3
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
            EmailOTP = 2
        }

        public enum FileTypes
        {
            ServiceCategoryFiles = 1,
            ProfileFiles = 2,
            ServiceFiles = 3,
            Gallery = 4,
            OrderDocument = 5
        }

        public enum OtpTypes
        {
            Sms = 1,
            Email = 2,
            ChangePassword = 3
        }

        public enum ServiceRequestRelationStatus
        {
            Waiting = 1,
            Bidded = 2,
            Rejected = 3
        }


        public enum OrderRequestStatus
        {
            Waiting = 1,
            Rejected = 2,
            Appleyed = 3
        }

        public enum PaymentTransactionStatus
        {
            Waiting = 1,
            Rejected = 2,
            Appleyed = 3
        }
        public enum PaymentTransactionTypes
        {
            Order = 1,
            Creadit = 2
        }
        public enum PaymentTransactionProcessType
        {
            Input = 1,
            OutPut = 2
        }
    }
}
