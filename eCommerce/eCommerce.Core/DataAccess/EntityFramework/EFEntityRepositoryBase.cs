using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace eCommerce.Core.DataAccess.EntityFramework
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public virtual TEntity Get<TInclude>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TInclude>> IncludeTableEx = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Include(IncludeTableEx).SingleOrDefault(filter);
            }
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public virtual List<TEntity> GetList<TInclude>(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, TInclude>> IncludeTableEx = null )
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().Include(IncludeTableEx).ToList()
                    : context.Set<TEntity>().Where(filter).Include(IncludeTableEx).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
    
}
