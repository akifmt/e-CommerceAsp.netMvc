using eCommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Business.Abstract
{
    public interface ISiparisService
    {
        List<Siparis> GetAll();
        List<Siparis> GetByProfil(int ProfilId);
        List<Siparis> GetByProfilWithSiparisUrun(int ProfilId);
        void Add(Siparis Siparis);
        void Update(Siparis Siparis);
        void Delete(Siparis Siparis);
        void DeleteWithSiparisUrun(Siparis Siparis);
        Siparis GetById(int Siparis);
    }
    
}
