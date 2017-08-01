using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        T Get<R>(Expression<Func<T, bool>> filter = null, Expression<Func<T, R>> IncludeTableExp = null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        List<T> GetList<R>(Expression<Func<T, bool>> filter = null, Expression<Func<T, R>> IncludeTableExp = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
