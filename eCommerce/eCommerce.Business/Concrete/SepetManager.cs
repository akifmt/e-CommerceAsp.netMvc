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
    public class SepetManager : ISepetService
    {
        private ISepetDAL _sepetDAL;

        public SepetManager() : this(new EFSepetDAL())
        {

        }

        public SepetManager(ISepetDAL sepetDAL)
        {
            _sepetDAL = sepetDAL;
        }

        public void Add(Sepet sepet)
        {
            _sepetDAL.Add(sepet);
        }

        public void AddUrunToSepet(int sepetId, SepetUrun sepetUrun)
        {
            _sepetDAL.AddUrunToSepet(sepetId, sepetUrun);
        }

        public void RemoveUrunFromSepet(int sepetId, int sepeturunId)
        {
            _sepetDAL.RemoveUrunFromSepet(sepetId, sepeturunId);
        }

        public void Delete(Sepet sepet)
        {
            _sepetDAL.Delete(sepet);
        }

        public List<Sepet> GetAll()
        {
            return _sepetDAL.GetList();
        }

        public Sepet GetById(int Id)
        {
            return _sepetDAL.Get(p => p.SepetId == Id);
        }

        public Sepet GetByProfilId(int ProfilId)
        {
            Sepet sepet = _sepetDAL.GetList(p => p.Profil.ProfilId == ProfilId, p => p.SepetUrun).LastOrDefault();
            if (sepet == null)
            {
                return new Sepet();
            }
            sepet.SepetUrun = _sepetDAL.GetListSepetUrun(p => p.SepetId == sepet.SepetId);
            return sepet;
        }

        public void Update(Sepet sepet)
        {
            _sepetDAL.Update(sepet);
        }
        
    }

}