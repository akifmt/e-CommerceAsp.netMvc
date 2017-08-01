using eCommerce.Business.Concrete;
using eCommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.MvcWebUI.Models
{
    public class KategoriViewModel
    {
        public List<Kategori> Kategoriler
        {
            get
            {
                return KategoriManager.GetAll();
            }
        }

        private KategoriManager _kategoriManager;
        public KategoriManager KategoriManager
        {
            get
            {
                return _kategoriManager ?? new KategoriManager();
            }
            private set
            {
                _kategoriManager = value;
            }
        }


    }
}