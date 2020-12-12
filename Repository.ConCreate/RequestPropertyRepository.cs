using Data.BaseContext;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure;

namespace Repository.ConCreate
{
    public class RequestPropertyRepository : EFEntityRepositoryBase<RequestProperty>, IRequestPropertyRepository
    {
        public RequestPropertyRepository(ServiceBuilderContext dbContext) : base(dbContext)
        {
        }
    }
}
