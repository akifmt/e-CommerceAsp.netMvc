using eCommerce.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Entities.Concrete;
using eCommerce.DataAccess.Abstract;
using eCommerce.DataAccess.Concrete;

namespace eCommerce.Business.Concrete
{
    public class SiparisManager : ISiparisService
    {
        private ISiparisDAL _siparisDAL;

        public SiparisManager() : this(new EFSiparisDAL())
        {

        }

        public SiparisManager(EFSiparisDAL siparisDAL)
        {
            _siparisDAL = siparisDAL;
        }

        public void Add(Siparis Siparis)
        {
            _siparisDAL.Add(Siparis);
        }

        public void Delete(Siparis Siparis)
        {
            _siparisDAL.Delete(Siparis);
        }

        public void DeleteWithSiparisUrun(Siparis Siparis)
        {
            _siparisDAL.DeleteWithSiparisUrun(Siparis);
        }

        public void Update(Siparis Siparis)
        {
            _siparisDAL.Update(Siparis);
        }

        public List<Siparis> GetAll()
        {
            return _siparisDAL.GetList(null, x => x.Profil);
        }

        public Siparis GetById(int SiparisId)
        {
            return _siparisDAL.Get(p => p.SiparisId == SiparisId, x => x.Profil);
        }
        
        public List<Siparis> GetByProfil(int ProfilId)
        {
            return _siparisDAL.GetList(x => x.ProfilId == ProfilId, x => x.Profil);
        }

        public List<Siparis> GetByProfilWithSiparisUrun(int ProfilId)
        {
            return _siparisDAL.GetListWithSiparisUrun(x => x.ProfilId == ProfilId);
        }

        public List<Siparis> GetByProfilWithSiparisUrunOdenmedi(int ProfilId)
        {
            return _siparisDAL.GetListWithSiparisUrunOdenmedi(x => x.ProfilId == ProfilId);
        }

        public List<Siparis> GetByProfilWithSiparisUrunOdendi(int ProfilId)
        {
            return _siparisDAL.GetListWithSiparisUrunOdendi(x => x.ProfilId == ProfilId);
        }
    }
}
