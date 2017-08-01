using eCommerce.Business.Abstract;
using eCommerce.DataAccess.Abstract;
using eCommerce.DataAccess.Concrete;
using eCommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Business.Concrete
{
    public class ProfilManager : IProfilService
    {

        private IProfilDAL _profilDAL;

        public ProfilManager():this(new EFProfilDAL())
        {

        }

        public ProfilManager(IProfilDAL profilDAL)
        {
            _profilDAL = profilDAL;
        }

        public void Add(Profil profil)
        {
            _profilDAL.Add(profil);
        }

        public void Delete(Profil profil)
        {
            _profilDAL.Delete(profil);
        }

        public void AdresSil(int ProfilId, int AdresId)
        {
            _profilDAL.AdresSil(ProfilId, AdresId);
        }

        public List<Profil> GetAll()
        {
            EFProfilDAL profilDAL = new EFProfilDAL();
            return profilDAL.GetList();
        }
        
        public Profil GetById(int profilId)
        {
            return _profilDAL.Get(p => p.ProfilId == profilId, p => p.Adresler);
        }

        public void Update(Profil profil)
        {
            _profilDAL.Update(profil);
        }

       
    }
}
