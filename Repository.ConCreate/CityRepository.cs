using Data.BaseContext;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure;

namespace Repository.ConCreate
{
    public class CityRepository : EFEntityRepositoryBase<City>, ICityRepository
    {
        public CityRepository(ServiceBuilderContext dbContext) : base(dbContext)
        {
        }
    }
}
