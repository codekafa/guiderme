using Data.BaseContext;
using DataModel.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Infrastructure;

namespace Repository.ConCreate
{
    public class UserRepository : EFEntityRepositoryBase<User>, IUserRepository
    {
        public UserRepository(ServiceBuilderContext _dbContext) : base(_dbContext)
        {

        }
    }
}
