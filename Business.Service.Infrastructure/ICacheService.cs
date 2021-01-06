using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Service.Infrastructure
{
   public  interface ICacheService
    {
        public void Clear();

        public T Get<T>(string key);

         bool IsSet(string key);

         void Remove(string key);

         void Set(string key, object data, int cacheTimeM);
    }
}
