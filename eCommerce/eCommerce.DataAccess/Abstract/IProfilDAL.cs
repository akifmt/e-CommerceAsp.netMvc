using eCommerce.Core.DataAccess;
using eCommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DataAccess.Abstract
{
    public interface IProfilDAL : IEntityRepository<Profil>
    {
        void AdresSil(int ProfilId, int AdresId);
    }
}
