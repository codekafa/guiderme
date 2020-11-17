using Data.BaseContext;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ConCreate
{
    public class CountryRepository : EFEntityRepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(ServiceBuilderContext dbContext) : base(dbContext)
        {
        }
    }
}
