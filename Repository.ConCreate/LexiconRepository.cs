using Data.BaseContext;
using DataModel.BaseEntities;
using Repository.Base;
using Repository.Infrastructure;

namespace Repository.ConCreate
{
    public class LexiconRepository : EFEntityRepositoryBase<Lexicon>, ILexiconRepository
    {

        public LexiconRepository(ServiceBuilderContext _dbContext) : base(_dbContext)
        { }

    }
}
