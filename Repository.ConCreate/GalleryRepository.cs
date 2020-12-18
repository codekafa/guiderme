using Data.BaseContext;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure;

namespace Repository.ConCreate
{
    public class GalleryRepository : EFEntityRepositoryBase<Gallery>, IGalleryRepository
    {
        public GalleryRepository(ServiceBuilderContext dbContext) : base(dbContext)
        {
        }
    }
}
