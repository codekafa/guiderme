using Data.BaseContext;
using DataModel.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Infrastructure;

namespace Repository.ConCreate
{
    public class OtpTransactionRepository : EFEntityRepositoryBase<OtpTransaction>, IOtpTransactionRepository
    {
        public OtpTransactionRepository(ServiceBuilderContext _dbContext) : base(_dbContext)
        {

        }
    }
}
