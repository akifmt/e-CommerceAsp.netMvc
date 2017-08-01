using eCommerce.Business.Abstract;
using eCommerce.DataAccess.Abstract;
using eCommerce.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Entities.Concrete;

namespace eCommerce.Business.Concrete
{
    public class UrunManager : IUrunService
    {
        private IUrunDAL _urunDAL;

        public UrunManager() : this(new EFUrunDAL())
        {

        }

        public UrunManager(EFUrunDAL urunDAL)
        {
            _urunDAL = urunDAL;
        }

        public void Add(Urun urun)
        {
            _urunDAL.Add(urun);
        }

        public void Delete(Urun urun)
        {
            _urunDAL.Delete(urun);
        }

        public List<Urun> GetAll()
        {
            return _urunDAL.GetList(null, x => x.Kategori);
        }

        public Urun GetById(int urunId)
        {
            return _urunDAL.Get(p => p.Id == urunId, x => x.Kategori);
        }

        public List<Urun> GetByKategori(int KategoriId)
        {
            return _urunDAL.GetList(x => x.KategoriId == KategoriId, x => x.Kategori);
        }
        public void Update(Urun urun)
        {
            _urunDAL.Update(urun);
        }
    }
}
