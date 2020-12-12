using Data.BaseContext;
using DataModel.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Repository.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Infrastructure
{
    public class EFEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {

        protected readonly ServiceBuilderContext _dbContext;

        public EFEntityRepositoryBase(ServiceBuilderContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Add(TEntity entity)
        {
            var addEnttiy = _dbContext.Entry(entity);
            addEnttiy.State = EntityState.Added;
            //_dbContext.SaveChanges();
            return addEnttiy.Entity;
        }

        public Task<TEntity> AddASync(TEntity entity)
        {
            Task<TEntity> result = Task.Run(() =>
           {
               var addEnttiy = _dbContext.Entry(entity);
               addEnttiy.State = EntityState.Added;
               var result = _dbContext.SaveChangesAsync();
               return addEnttiy.Entity;
           });
            return result;
        }

        public void Delete(TEntity entity)
        {
            var addEnttiy = _dbContext.Entry(entity);
            addEnttiy.State = EntityState.Deleted;
            //_dbContext.SaveChanges();

        }

        public void DeleteASync(TEntity entity)
        {
            Task.Run(() =>
           {
               var addEnttiy = _dbContext.Entry(entity);
               addEnttiy.State = EntityState.Deleted;
               //_dbContext.SaveChanges();
           });
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _dbContext.Set<TEntity>().Where(filter).FirstOrDefault();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _dbContext.Set<TEntity>().ToList() : _dbContext.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity Update(TEntity entity)
        {
            var updateEntity = _dbContext.Entry(entity);
            updateEntity.State = EntityState.Modified;
            //_dbContext.SaveChanges();
            return updateEntity.Entity;
        }

        public Task<TEntity> UpdateASync(TEntity entity)
        {
            Task<TEntity> result = Task.Run(() =>
            {
                var updateEntity = _dbContext.Entry(entity);
                updateEntity.State = EntityState.Modified;
                //_dbContext.SaveChanges();
                return updateEntity.Entity;
            });
            return result;
        }
    }
}
