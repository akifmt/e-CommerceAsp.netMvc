using eCommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Business.Abstract
{
    public interface IKategoriService
    {
        List<Kategori> GetAll();
        void Add(Kategori kategori);
        void Update(Kategori kategori);
        void Delete(Kategori kategori);
        Kategori GetById(int kategoriId);
    }
}
