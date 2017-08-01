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
    public class EFSepetDAL : EFEntityRepositoryBase<Sepet, eCommerceContext>, ISepetDAL
    {
        public void AddUrunToSepet(int sepetId, SepetUrun sepetUrun)
        {
            using (var context = new eCommerceContext())
            {
                var entity = context.Sepetler.Find(sepetId);
                var sepetUrunIndb = entity.SepetUrun.Where(x => x.Urun.Id == sepetUrun.Urun.Id).FirstOrDefault();
                if (sepetUrunIndb == null)
                {
                    entity.SepetUrun.Add(sepetUrun);
                    var updatedEntity = context.Entry(entity);
                    updatedEntity.State = EntityState.Modified;
                    context.Entry<Urun>(sepetUrun.Urun).State = EntityState.Unchanged;
                    context.Entry<Kategori>(sepetUrun.Urun.Kategori).State = EntityState.Unchanged;
                    foreach (var item in sepetUrun.Urun.UrunImages)
                    {
                        context.Entry<UrunImage>(item).State = EntityState.Unchanged;
                    }
                    
                }
                else
                {
                    sepetUrunIndb.Miktar += 1;
                }
                
                context.SaveChanges();
            }
        }

        public void RemoveUrunFromSepet(int sepetId, int sepeturunId)
        {
            using (var context = new eCommerceContext())
            {
                var entity = context.SepetUrun.Where(x => x.SepetId == sepetId & x.Id == sepeturunId).FirstOrDefault();
                context.SepetUrun.Remove(entity);
                context.SaveChanges();
            }
        }

        public List<Sepet> GetList(Expression<Func<Sepet, bool>> filter = null, Expression<Func<Sepet, SepetUrun>> IncludeTableExp1 = null)
        {
            using (var context = new eCommerceContext())
            {
                return context.Set<Sepet>().Where(filter).Include(x => x.SepetUrun).Include(x =>x).ToList();
            }
        }

        public List<SepetUrun> GetListSepetUrun(Expression<Func<SepetUrun, bool>> filter = null)
        {
            using (var context = new eCommerceContext())
            {
                List<SepetUrun> sepetUrun = context.Set<SepetUrun>().Where(filter).Include(x => x.Urun).Include(x =>x.Urun.UrunImages).ToList();
                return sepetUrun;
            }
        }

    }
}
