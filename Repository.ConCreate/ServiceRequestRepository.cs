using Data.BaseContext;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ConCreate
{
    public class ServiceRequestRepository  :  EFEntityRepositoryBase<ServiceRequest>, IServiceRequestsRepository
    {
        public ServiceRequestRepository(ServiceBuilderContext _dbContext) : base(_dbContext)
        {

        }
    }
}
