using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eCommerce.Entities.Concrete;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eCommerce.MvcWebUI.Entities
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            Profil = new HashSet<Profil>();
        }

        public virtual ICollection<Profil> Profil { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
        
        
    }
}