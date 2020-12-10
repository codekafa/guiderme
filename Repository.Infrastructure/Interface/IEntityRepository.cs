using DataModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Infrastructure.Interface
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T Add(T entity);

        Task<T> AddASync(T entity);
        T Update(T entity);

        Task<T> UpdateASync(T entity);
        void Delete(T entity);

        void DeleteASync(T entity);
    }
}
