using eCommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Business.Abstract
{
    public interface IProfilService
    {
        List<Profil> GetAll();
        void Add(Profil profil);
        void Update(Profil profil);
        void Delete(Profil profil);
        void AdresSil(int ProfilId, int AdresId);
        Profil GetById(int profilId);
    }
}
