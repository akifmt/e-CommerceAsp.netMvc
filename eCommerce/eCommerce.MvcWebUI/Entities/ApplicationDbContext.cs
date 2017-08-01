using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using eCommerce.Entities.Concrete;

namespace eCommerce.MvcWebUI.Entities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("myConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Kullanicilar");
            modelBuilder.Entity<ApplicationUser>().Ignore(c => c.EmailConfirmed)
                                           .Ignore(c => c.PhoneNumber)
                                           .Ignore(c => c.PhoneNumberConfirmed)
                                           .Ignore(c => c.TwoFactorEnabled)
                                           .Ignore(c => c.LockoutEndDateUtc)
                                           .Ignore(c => c.LockoutEnabled)
                                           .Ignore(c => c.AccessFailedCount);

            modelBuilder.Entity<IdentityRole>().ToTable("Roller");
            modelBuilder.Entity<IdentityUserRole>().ToTable("KullaniciRol");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("KullaniciGiris");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("KullaniciYetki");

            
            
        }
        
    }
}