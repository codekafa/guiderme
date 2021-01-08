using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Service.Common
{
    public class IOC
    {
        public static IServiceProvider CurrentProvider { get;  set; }

        public static T resolve<T>()
        {
            var type = typeof(T);
            return (T)CurrentProvider.GetService(type);
        }
    }
}
