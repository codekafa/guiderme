using DataModel.BaseEntities;
using Repository.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Base
{
    public interface ICountryRepository : IEntityRepository<Country>
    {
    }
}
