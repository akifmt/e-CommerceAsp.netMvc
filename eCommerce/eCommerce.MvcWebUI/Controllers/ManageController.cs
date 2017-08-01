using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using eCommerce.MvcWebUI.Models;
using System.Data.Entity;
using eCommerce.Entities.Concrete;
using eCommerce.MvcWebUI.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using eCommerce.Business.Concrete;
using System.Collections.Generic;

namespace eCommerce.MvcWebUI.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        private ProfilManager _profilManager;
        
        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
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

            return View(userProfil);
        }

        [HttpPost]
        public ActionResult Index(Profil model)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.FindByName(User.Identity.Name);

                Profil guncellenecekProfil = user.Profil.LastOrDefault();
                guncellenecekProfil.Ad = model.Ad;
                guncellenecekProfil.DogumTarihi = model.DogumTarihi;
                guncellenecekProfil.Soyad = model.Soyad;
                guncellenecekProfil.TCKimlikNo = model.TCKimlikNo;
                guncellenecekProfil.Telefon = model.Telefon;

                UserManager.Update(user);
            }

            return View(model);
        }

        public ActionResult Adres()
        {
            var user = UserManager.FindByName(User.Identity.Name);
            Profil userProfil = user.Profil.LastOrDefault();
            List<Adres> adresler = userProfil.Adresler.ToList();
            return View(adresler);
        }
        public ActionResult AdresEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdresEkle(Adres model)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.FindByName(User.Identity.Name);
                var userProfil = user.Profil.LastOrDefault();
                Adres yeniAdres = new Adres
                {
                    AdresAdi = model.AdresAdi,
                    AdresDetay = model.AdresDetay,
                    Il = model.Il,
                    Ilce = model.Ilce,
                    Ulke = model.Ulke
                };

                userProfil.Adresler.Add(yeniAdres);

                IdentityResult res = UserManager.Update(user);
                if (res.Succeeded)
                {
                    TempData["AdresSonuc"] = "Adres Ekleme Başarılı.";
                    return RedirectToAction("Adres", "Manage");
                }
            }

            return View(model);
        }

        public ActionResult AdresSil(int id)
        {
            var user = UserManager.FindByName(User.Identity.Name);
            var userProfilId = user.Profil.LastOrDefault().ProfilId;
            ProfilManager.AdresSil(userProfilId, id);

            TempData["AdresSonuc"] = "Adres Silindi.";
            return RedirectToAction("Adres", "Manage");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        #endregion
    }
}