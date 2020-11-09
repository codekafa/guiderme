using Data.BaseContext;
using DataModel.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Infrastructure;

namespace Repository.ConCreate
{
    public class UserAddressRepository : EFEntityRepositoryBase<UserAddress>, IUserAddressRepository
    {
        public UserAddressRepository(ServiceBuilderContext _dbContext) : base(_dbContext)
        { }
    }
}
