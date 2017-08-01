using eCommerce.Business.Concrete;
using eCommerce.Entities.Concrete;
using eCommerce.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {

        private UrunManager _urunManager;
        private KategoriManager _kategoriManager;
        
        public UrunManager UrunManager
        {
            get
            {
                return _urunManager ?? new UrunManager();
            }
            private set
            {
                _urunManager = value;
            }
        }
        
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

        public ActionResult Index(int? id)
        {
            ViewBag.Kategoriler = KategoriManager.GetAll();

            List<Urun> urunler;
            if (id != null)
            {
                urunler = UrunManager.GetByKategori((int)id);
            }
            else
            {
                urunler = UrunManager.GetAll();
            }
            
            return View(urunler);
        }
        
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}