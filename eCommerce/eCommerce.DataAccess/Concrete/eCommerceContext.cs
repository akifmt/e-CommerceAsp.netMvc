using eCommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DataAccess.Concrete
{
    public class eCommerceContext : DbContext
    {
        public eCommerceContext() : base("myConnection")
        {
            if (Kategoriler.Count() == 0)
            {
                BaslangicVerileriEkle();
            }
        }


        public DbSet<Profil> Profiller { get; set; }
        public DbSet<Adres> Adresler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<UrunImage> UrunImages { get; set; }
        public DbSet<Sepet> Sepetler { get; set; }
        public DbSet<SepetUrun> SepetUrun { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisUrun> SiparisUrun { get; set; }

        private void BaslangicVerileriEkle()
        {
            Kategori kat1 = new Kategori { KategoriAdi = "Berjer’ler" };
            Kategori kat2 = new Kategori { KategoriAdi = "Koltuk Takımları" };
            Kategori kat3 = new Kategori { KategoriAdi = "Abajurlar" };
            Kategori kat4 = new Kategori { KategoriAdi = "Dekoratif Işıklar" };
            Kategori kat5 = new Kategori { KategoriAdi = "Ofis Sandalyeleri" };
            Kategori kat6 = new Kategori { KategoriAdi = "Avizeler" };
            Kategori kat7 = new Kategori { KategoriAdi = "Ev Dekor Ürünleri" };

            Kategoriler.Add(kat1);
            Kategoriler.Add(kat2);
            Kategoriler.Add(kat3);
            Kategoriler.Add(kat4);
            Kategoriler.Add(kat5);
            Kategoriler.Add(kat6);
            Kategoriler.Add(kat7);


            Urun urun1 = new Urun
            {
                UrunAdi = "Berjer Koltuk 1",
                UrunFiyati = 120.12m,
                UrunAciklama = "Poliüretan ve akrilik türevlerinden oluşan polyester içerikli kumaş kullanılmıştır.",
                Kategori = kat1
            };
            urun1.UrunImages.Add(new UrunImage { UrunImageUrl = "/Content/Images/berjer1.jpg" });
            urun1.UrunImages.Add(new UrunImage { UrunImageUrl = "/Content/Images/berjer2.jpg" });

            Urun urun2 = new Urun
            {
                UrunAdi = "Koltuk Takımı 1",
                UrunFiyati = 1100.99m,
                UrunAciklama = "Takım , 3+3+1'den oluşmaktadır. Poliüretan ve akrilik türevlerinden oluşan polyester içerikli kumaş kullanılmıştır.",
                Kategori = kat2
            };
            urun2.UrunImages.Add(new UrunImage { UrunImageUrl = "/Content/Images/kt1.jpg" });
            urun2.UrunImages.Add(new UrunImage { UrunImageUrl = "/Content/Images/kt2.jpg" });

            Urun urun3 = new Urun
            {
                UrunAdi = "Abajur 1",
                UrunFiyati = 90.99m,
                UrunAciklama = "Eskitme antik kaplama tekniği uygulanmıştır. Ampul fiyata dahil değildir.  ",
                Kategori = kat3
            };
            urun3.UrunImages.Add(new UrunImage { UrunImageUrl = "/Content/Images/a1.jpg" });
            urun3.UrunImages.Add(new UrunImage { UrunImageUrl = "/Content/Images/a2.jpg" });

            Urun urun4 = new Urun
            {
                UrunAdi = "Dekoratif Işık 1",
                UrunFiyati = 255.99m,
                UrunAciklama = "Paslanmaz, dökülmez, soyulmaz ve pürüzsüz antistatik toz tutmayan yüzeye sahiptir. Ürünümüz montajlı gönderilmektedir. ",
                Kategori = kat4
            };
            urun4.UrunImages.Add(new UrunImage { UrunImageUrl = "/Content/Images/di1.jpg" });
            urun4.UrunImages.Add(new UrunImage { UrunImageUrl = "/Content/Images/di2.jpg" });

            Urun urun5 = new Urun
            {
                UrunAdi = "Ofis Sandalye 1",
                UrunFiyati = 155.99m,
                UrunAciklama = "Paslanmaz, dökülmez, soyulmaz ve pürüzsüz antistatik toz tutmayan yüzeye sahiptir. Ürünümüz montajlı gönderilmektedir. ",
                Kategori = kat5
            };
            urun5.UrunImages.Add(new UrunImage { UrunImageUrl = "/Content/Images/os1.jpg" });
            urun5.UrunImages.Add(new UrunImage { UrunImageUrl = "/Content/Images/os2.jpg" });
            
            Urun urun6 = new Urun
            {
                UrunAdi = "Avize 1",
                UrunFiyati = 175.99m,
                UrunAciklama = "Metal,Cam. Ürünümüz montajlı gönderilmektedir. ",
                Kategori = kat6
            };
            urun6.UrunImages.Add(new UrunImage { UrunImageUrl = "/Content/Images/av1.jpg" });
            urun6.UrunImages.Add(new UrunImage { UrunImageUrl = "/Content/Images/av2.png" });

            Urun urun7 = new Urun
            {
                UrunAdi = "Ev Dekor 1",
                UrunFiyati = 475.25m,
                UrunAciklama = "Polyester malzemeden üretilmiştir.",
                Kategori = kat7
            };
            urun7.UrunImages.Add(new UrunImage { UrunImageUrl = "/Content/Images/evdekor1.jpg" });
            urun7.UrunImages.Add(new UrunImage { UrunImageUrl = "/Content/Images/evdekor2.jpg" });

            Urunler.Add(urun1);
            Urunler.Add(urun2);
            Urunler.Add(urun3);
            Urunler.Add(urun4);
            Urunler.Add(urun5);
            Urunler.Add(urun6);
            Urunler.Add(urun7);

            this.SaveChanges();
        }
    }



}
