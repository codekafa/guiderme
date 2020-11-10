using Data.BaseContext;
using DataModel.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Infrastructure;

namespace Repository.ConCreate
{
    public class ServicePhotoRepository : EFEntityRepositoryBase<ServicePhoto>, IServicePhotoRepository
    {
        public ServicePhotoRepository(ServiceBuilderContext _dbContext) : base(_dbContext)
        {

        }
    }
}
