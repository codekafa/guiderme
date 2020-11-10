using Data.BaseContext;
using DataModel.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Infrastructure;

namespace Repository.ConCreate
{
    public class ServiceCategoryRepository : EFEntityRepositoryBase<ServiceCategory>, IServiceCategoryRepository
    {
        public ServiceCategoryRepository(ServiceBuilderContext _dbContext) : base(_dbContext)
        {

        }
    }
}
