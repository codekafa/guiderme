using Data.BaseContext;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure;

namespace Repository.ConCreate
{
    public class RequestBidRepository : EFEntityRepositoryBase<RequestBid>, IRequestBidRepository
    {
        public RequestBidRepository(ServiceBuilderContext dbContext) : base(dbContext)
        {
        }
    }
}
