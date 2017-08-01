using eCommerce.Core.DataAccess.EntityFramework;
using eCommerce.DataAccess.Abstract;
using eCommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DataAccess.Concrete
{
    public class EFProfilDAL : EFEntityRepositoryBase<Profil, eCommerceContext>, IProfilDAL
    {
        public void AdresSil(int ProfilId, int AdresId)
        {
            using (var context = new eCommerceContext())
            {
                var entity = context.Adresler.Where(x => x.ProfilId == ProfilId & x.Id == AdresId).FirstOrDefault();
                context.Adresler.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
