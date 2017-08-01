using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eCommerce.Entities.Concrete;
using eCommerce.MvcWebUI.Entities;
using eCommerce.Business.Concrete;
using System.IO;

namespace eCommerce.MvcWebUI.Controllers
{
    [Authorize]
    public class UrunController : Controller
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
        
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = UrunManager.GetById((int)id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }


        // Alt kisim admin paneli icin hazirlanacak
        public ActionResult Index()
        {
            var uruns = UrunManager.GetAll();
            return View(uruns.ToList());
        }
        
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(KategoriManager.GetAll(), "Id", "KategoriAdi");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UrunAdi,UrunAciklama,UrunFiyati,KategoriId")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                
                UrunManager.Add(urun);
                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(KategoriManager.GetAll(), "Id", "KategoriAdi", urun.KategoriId);
            return View(urun);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = UrunManager.GetById((int)id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(KategoriManager.GetAll(), "Id", "KategoriAdi", urun.KategoriId);
            return View(urun);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UrunAdi,UrunAciklama,UrunFiyati,KategoriId")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                UrunManager.Update(urun);
                return RedirectToAction("Index");
            }
            ViewBag.KategoriId = new SelectList(KategoriManager.GetAll(), "Id", "KategoriAdi", urun.KategoriId);
            return View(urun);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = UrunManager.GetById((int)id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urun urun = UrunManager.GetById(id);
            UrunManager.Delete(urun);
            return RedirectToAction("Index");
        }
        
    }
}
