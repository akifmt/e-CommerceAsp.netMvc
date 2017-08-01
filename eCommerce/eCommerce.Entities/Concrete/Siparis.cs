using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Entities.Concrete
{
    [Table("Siparisler")]
    public class Siparis : IEntity
    {
        public Siparis()
        {
            SiparisUrunler = new HashSet<SiparisUrun>();
        }
        public int SiparisId { get; set; }

        public int ProfilId { get; set; }
        [ForeignKey("ProfilId")]
        public virtual Profil Profil { get; set; }

        public bool OdendiMi { get; set; }
        
        public DateTime SiparisTarihi { get; set; }
        
        public string Ulke { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string AdresDetay { get; set; }

        public virtual ICollection<SiparisUrun> SiparisUrunler { get; set; }

        public decimal ToplamOdeme
        {
            get
            {
                return SiparisUrunler.Sum(x => x.UrunFiyati * x.UrunMiktar);
            }
        }


    }
}
