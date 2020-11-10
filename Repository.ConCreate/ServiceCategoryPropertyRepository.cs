using Data.BaseContext;
using DataModel.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Infrastructure;

namespace Repository.ConCreate
{
    public class ServiceCategoryPropertyRepository : EFEntityRepositoryBase<ServiceCategoryProperty>, IServiceCategoryPropertyRepository
    {
        public ServiceCategoryPropertyRepository(ServiceBuilderContext _dbContext) : base(_dbContext)
        {

        }
    }
}
