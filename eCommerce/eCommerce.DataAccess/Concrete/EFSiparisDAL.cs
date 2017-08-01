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
    public class EFSiparisDAL : EFEntityRepositoryBase<Siparis, eCommerceContext>, ISiparisDAL
    {
        public List<Siparis> GetListWithSiparisUrun(Expression<Func<Siparis, bool>> filter = null)
        {
            using (var context = new eCommerceContext())
            {
                return context.Set<Siparis>().Where(filter).Include(x => x.Profil).Include(x => x.SiparisUrunler).ToList();
            }
        }

        public List<Siparis> GetListWithSiparisUrunOdenmedi(Expression<Func<Siparis, bool>> filter = null)
        {
            using (var context = new eCommerceContext())
            {
                return context.Set<Siparis>().Where(filter).Where(x=>x.OdendiMi == false).Include(x => x.Profil).Include(x => x.SiparisUrunler).OrderByDescending(x => x.SiparisTarihi).ToList();
            }
        }

        public List<Siparis> GetListWithSiparisUrunOdendi(Expression<Func<Siparis, bool>> filter = null)
        {
            using (var context = new eCommerceContext())
            {
                return context.Set<Siparis>().Where(filter).Where(x => x.OdendiMi == true).Include(x => x.Profil).Include(x => x.SiparisUrunler).OrderByDescending(x => x.SiparisTarihi).ToList();
            }
        }

        public void DeleteWithSiparisUrun(Siparis Siparis)
        {
            using (var context = new eCommerceContext())
            {
                var deletedEntity = context.Siparisler.Include(x=>x.SiparisUrunler).Where(x=>x.SiparisId == Siparis.SiparisId).FirstOrDefault();
                context.Siparisler.Remove(deletedEntity);
                context.SaveChanges();
            }
        }
    }
}
