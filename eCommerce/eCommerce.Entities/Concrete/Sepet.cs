using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Entities.Concrete
{
    [Table("Sepetler")]
    public class Sepet :IEntity
    {
        public Sepet()
        {
            SepetUrun = new HashSet<SepetUrun>();
        }

        public int SepetId { get; set; }

        
        public int ProfilId { get; set; }
        [ForeignKey("ProfilId")]
        public virtual Profil Profil { get; set; }
        
        public virtual ICollection<SepetUrun> SepetUrun { get; set; }

        public decimal Toplam
        {
            get
            {
                return SepetUrun.Sum(c => c.Urun.UrunFiyati * c.Miktar);
            }
        }
    }
}
