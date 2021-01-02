using Data.BaseContext;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ConCreate
{
    public class PaymentTransactionRepository : EFEntityRepositoryBase<PaymentTransaction>, IPaymentTransactionRepository
    {
        public PaymentTransactionRepository(ServiceBuilderContext _dbContext) : base(_dbContext)
        {

        }
    }
}
