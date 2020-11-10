using Data.BaseContext;
using DataModel.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Infrastructure;

namespace Repository.ConCreate
{
    public class PageRepository : EFEntityRepositoryBase<Page>, IPageRepository
    {
        public PageRepository(ServiceBuilderContext _dbContext) : base(_dbContext)
        {

        }
    }
}
