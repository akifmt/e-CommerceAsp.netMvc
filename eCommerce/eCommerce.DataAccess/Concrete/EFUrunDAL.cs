using eCommerce.Core.DataAccess.EntityFramework;
using eCommerce.DataAccess.Abstract;
using eCommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DataAccess.Concrete
{
    public class EFUrunDAL : EFEntityRepositoryBase<Urun, eCommerceContext>, IUrunDAL
    {
        public override List<Urun> GetList<TInclude>(Expression<Func<Urun, bool>> filter = null, Expression<Func<Urun, TInclude>> IncludeTableEx = null)
        {
            using (var context = new eCommerceContext())
            {
                return filter == null
                    ? context.Set<Urun>().Include(x => x.UrunImages).Include(IncludeTableEx).ToList()
                    : context.Set<Urun>().Where(filter).Include(x => x.UrunImages).Include(IncludeTableEx).ToList();
            }
        }
        
        public override Urun Get<TInclude>(Expression<Func<Urun, bool>> filter, Expression<Func<Urun, TInclude>> IncludeTableEx = null)
        {
            using (var context = new eCommerceContext())
            {
                return context.Set<Urun>().Include(IncludeTableEx).Include(x=>x.UrunImages).SingleOrDefault(filter);
            }
        }
    }
}
