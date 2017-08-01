using eCommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Business.Abstract
{
    public interface IUrunService
    {
        List<Urun> GetAll();
        List<Urun> GetByKategori(int KategoriId);
        void Add(Urun urun);
        void Update(Urun urun);
        void Delete(Urun urun);
        Urun GetById(int urunId);
    }
}
