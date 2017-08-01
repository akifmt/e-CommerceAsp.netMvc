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
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using eCommerce.MvcWebUI.Models;

namespace eCommerce.MvcWebUI.Controllers
{
    [Authorize]
    public class SiparisController : Controller
    {
        private SepetManager _sepetManager;
        private SiparisManager _siparisManager;
        private ApplicationUserManager _userManager;
        private ProfilManager _profilManager;

        public SiparisController()
        {
        }

        public SiparisController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        
        public SiparisManager SiparisManager
        {
            get
            {
                return _siparisManager ?? new SiparisManager();
            }
            private set
            {
                _siparisManager = value;
            }
        }
        public SepetManager SepetManager
        {
            get
            {
                return _sepetManager ?? new SepetManager();
            }
            private set
            {
                _sepetManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ProfilManager ProfilManager
        {
            get
            {
                return _profilManager ?? new ProfilManager();
            }
            private set
            {
                _profilManager = value;
            }
        }
        
        public ActionResult Index()
        {
            var user = UserManager.FindByName(User.Identity.Name);
            Profil userProfil = user.Profil.LastOrDefault();

            var aktifSiparisler = SiparisManager.GetByProfilWithSiparisUrunOdenmedi(userProfil.ProfilId);

            return View(aktifSiparisler);
        }

        public ActionResult Gecmis()
        {
            var user = UserManager.FindByName(User.Identity.Name);
            Profil userProfil = user.Profil.LastOrDefault();

            var gecmisSiparisler = SiparisManager.GetByProfilWithSiparisUrunOdendi(userProfil.ProfilId);

            return View(gecmisSiparisler);
        }

        
        public ActionResult Create()
        {
            var user = UserManager.FindByName(User.Identity.Name);
            Profil userProfil = user.Profil.LastOrDefault();

            List<SepetUrun> sepetUrunler = SepetManager.GetByProfilId(userProfil.ProfilId).SepetUrun.ToList();
            List<SiparisUrun> siparisUrunler = new List<SiparisUrun>();
            foreach (var item in sepetUrunler)
            {
                SiparisUrun su = new SiparisUrun
                {
                    UrunId = item.Urun.Id,
                    UrunAdi = item.Urun.UrunAdi,
                    UrunFiyati = item.Urun.UrunFiyati,
                    UrunMiktar = item.Miktar
                };
                siparisUrunler.Add(su);
            }

            Siparis yeniSiparis = new Siparis
            {
                ProfilId = userProfil.ProfilId,
                SiparisUrunler = siparisUrunler
            };

            sipUrunler = siparisUrunler;

            return View(yeniSiparis);
        }

        public static List<SiparisUrun> sipUrunler;
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Siparis siparis)
        {
            var user = UserManager.FindByName(User.Identity.Name);
            Profil userProfil = user.Profil.LastOrDefault();
            
            if (ModelState.IsValid)
            {
                siparis.SiparisUrunler = sipUrunler;
                siparis.SiparisTarihi = DateTime.Now;
                SepetManager.Add(new Sepet { ProfilId = userProfil.ProfilId });

                SiparisManager.Add(siparis);
                return RedirectToAction("Index");
            }
            
            return View(siparis);
        }
        
       

        public ActionResult Delete(int? id)
        {
            Siparis siparis = SiparisManager.GetById((int)id);
            SiparisManager.DeleteWithSiparisUrun(siparis);
            return RedirectToAction("Index");
        }

        public ActionResult OdemeYap(int id)
        {
            var user = UserManager.FindByName(User.Identity.Name);
            Profil userProfil = user.Profil.LastOrDefault();
            List<Adres> adresler = userProfil.Adresler.ToList();

            List<Siparis> siparisler = SiparisManager.GetByProfilWithSiparisUrun(userProfil.ProfilId);
            Siparis siparis = siparisler.Where(x => x.SiparisId == id).FirstOrDefault();


            OdemeViewModel odemeViewModel = new OdemeViewModel
            {
                Profil = userProfil,
                Adresler = adresler,
                Siparis = siparis
            };

            return View(odemeViewModel);
        }

        [HttpPost]
        public ActionResult OdemeYap(OdemeViewModel odemeViewModel)
        {
            var user = UserManager.FindByName(User.Identity.Name);
            Profil userProfil = user.Profil.LastOrDefault();
            List<Adres> adresler = userProfil.Adresler.ToList();
            List<Siparis> siparisler = SiparisManager.GetByProfilWithSiparisUrun(userProfil.ProfilId);

            Siparis siparis = siparisler.Where(x => x.SiparisId == odemeViewModel.Siparis.SiparisId).FirstOrDefault();

            if (odemeViewModel.SelectedAdresId == null)
            {
                ModelState.AddModelError("", "Adres Seçilmedi");
                
                odemeViewModel = new OdemeViewModel
                {
                    Profil = userProfil,
                    Adresler = adresler,
                    Siparis = siparis
                };
                return View(odemeViewModel);
            }

            Adres adres = userProfil.Adresler.Where(x=>x.Id == odemeViewModel.SelectedAdresId).FirstOrDefault();
            
            siparis.OdendiMi = true;
            siparis.Il = adres.Il;
            siparis.Ilce = adres.Ilce;
            siparis.Ulke = adres.Ulke;
            siparis.AdresDetay = adres.AdresDetay;
            SiparisManager.Update(siparis);
            
            return RedirectToAction("Index","Siparis");
        }
       
    }
}
