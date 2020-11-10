using Data.BaseContext;
using DataModel.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Infrastructure;

namespace Repository.ConCreate
{
    public class ExceptionLogRepository : EFEntityRepositoryBase<ExceptionLog>, IExceptionLogRepository
    {
        public ExceptionLogRepository(ServiceBuilderContext _dbContext) : base(_dbContext)
        {

        }
    }
}
