using Data.BaseContext;
using DataModel.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Infrastructure;

namespace Repository.ConCreate
{
    public class ExceptionRepository : EFEntityRepositoryBase<ExceptionLog>, IExceptionLogRepository
    {
        public ExceptionRepository(ServiceBuilderContext _dbContext) : base(_dbContext)
        {

        }
    }
}
