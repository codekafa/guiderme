using DataModel.BaseEntities;
using Repository.Infrastructure.Interface;

namespace Repository.Base
{
    public interface IPaymentTransactionRepository : IEntityRepository<PaymentTransaction>
    {
    }
}
