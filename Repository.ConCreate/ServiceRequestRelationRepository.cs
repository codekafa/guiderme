using Data.BaseContext;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure;

namespace Repository.ConCreate
{
    public class ServiceRequestRelationRepository : EFEntityRepositoryBase<ServiceRequestRelation>, IServiceRequestRelationRepository
    {
        public ServiceRequestRelationRepository(ServiceBuilderContext dbContext) : base(dbContext)
        {
        }
    }
}
