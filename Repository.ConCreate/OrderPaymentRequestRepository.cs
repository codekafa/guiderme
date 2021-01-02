using Data.BaseContext;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure;

namespace Repository.ConCreate
{
    public class OrderPaymentRequestRepository : EFEntityRepositoryBase<OrderPaymentRequest>, IOrderPaymentRequestRepository
    {
        public OrderPaymentRequestRepository(ServiceBuilderContext dbContext) : base(dbContext)
        {
        }
    }
}


