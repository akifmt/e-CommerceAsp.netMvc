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
    public class KategoriManager : IKategoriService
    {

        private IKategoriDAL _kategoriDAL;

        public KategoriManager() : this(new EFKategoriDAL())
        {

        }

        public KategoriManager(IKategoriDAL kategoriDAL)
        {
            _kategoriDAL = kategoriDAL;
        }

        public void Add(Kategori kategori)
        {
            _kategoriDAL.Add(kategori);
        }

        public void Delete(Kategori kategori)
        {
            _kategoriDAL.Delete(kategori);
        }

        public void Update(Kategori kategori)
        {
            _kategoriDAL.Update(kategori);
        }

        public List<Kategori> GetAll()
        {
            return _kategoriDAL.GetList();
        }

        public Kategori GetById(int kategoriId)
        {
            return _kategoriDAL.Get(x => x.Id == kategoriId);
        }
    }
}
