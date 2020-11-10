using Data.BaseContext;
using DataModel.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Infrastructure;

namespace Repository.ConCreate
{
    public class ServiceRepository : EFEntityRepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(ServiceBuilderContext _dbContext) : base(_dbContext)
        {

        }
    }
}
