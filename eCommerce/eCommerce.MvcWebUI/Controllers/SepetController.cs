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

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using eCommerce.MvcWebUI.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eCommerce.MvcWebUI.Controllers
{
    [Authorize]
    public class SepetController : Controller
    {
        private SepetManager _sepetManager;
        private UrunManager _urunManager;
        private ApplicationUserManager _userManager;

        public SepetController()
        {
        }
        public SepetController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
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
        

        public ActionResult Index()
        {
            var user = UserManager.FindByName(User.Identity.Name);
            Profil userProfil = user.Profil.LastOrDefault();
            Sepet userSepet = userProfil.Sepetler.LastOrDefault();

            if (userSepet != null)
            {
                return View(userSepet);
            }

            return View(new Sepet());
        }
        

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sepet sepet = SepetManager.GetById((int)id);
            if (sepet == null)
            {
                return HttpNotFound();
            }
            return View(sepet);
        }
        

        public ActionResult Create()
        {
            return View();
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sepet sepet)
        {
            if (ModelState.IsValid)
            {
                SepetManager.Add(sepet);
                return RedirectToAction("Index");
            }

            return View(sepet);
        }
        

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sepet sepet = SepetManager.GetById((int)id);
            if (sepet == null)
            {
                return HttpNotFound();
            }
            return View(sepet);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] Sepet sepet)
        {
            if (ModelState.IsValid)
            {
                SepetManager.Update(sepet);
                return RedirectToAction("Index");
            }
            return View(sepet);
        }
        

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sepet sepet = SepetManager.GetById((int)id);
            if (sepet == null)
            {
                return HttpNotFound();
            }
            return View(sepet);
        }
        

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sepet sepet = SepetManager.GetById(id);
            SepetManager.Delete(sepet);
            return RedirectToAction("Index");
        }


        public ActionResult SepeteUrunEkle(int urunId)
        {
            Urun sepeteEklenecekUrun = UrunManager.GetById(urunId);

            var user = UserManager.FindByName(User.Identity.Name);
            Profil userProfil = user.Profil.LastOrDefault();
            Sepet userSepet = SepetManager.GetByProfilId(userProfil.ProfilId);

            if (userSepet.SepetUrun.Count == 0)
            {
                userSepet.ProfilId = userProfil.ProfilId;
                SepetManager.Add(userSepet);
            }
            SepetUrun sepetUrun = new SepetUrun { SepetId = userSepet.SepetId, Urun = sepeteEklenecekUrun, Miktar = 1 };
            SepetManager.AddUrunToSepet(userSepet.SepetId, sepetUrun);
            
            return RedirectToAction("Index", "Home");

        }

        public ActionResult SepettenUrunCikar(int urunId)
        {
            var user = UserManager.FindByName(User.Identity.Name);
            Profil userProfil = user.Profil.LastOrDefault();
            Sepet userSepet = SepetManager.GetByProfilId(userProfil.ProfilId);

            if (userSepet.SepetUrun.Count == 0)
            {
                RedirectToAction("Index", "Sepet");
            }
            else
            {
                SepetManager.RemoveUrunFromSepet(userSepet.SepetId, urunId);
            }


            return RedirectToAction("Index", "Sepet");

        }

        [AllowAnonymous]
        public ActionResult SepetPartial()
        {
            var user = UserManager.FindByName(User.Identity.Name);
            if (user == null)
            {
                return PartialView(new Sepet());
            }

            Profil userProfil = user.Profil.LastOrDefault();
            Sepet userSepet = SepetManager.GetByProfilId(userProfil.ProfilId);

            return PartialView(userSepet);
        }

    }


}


