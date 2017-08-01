using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Entities.Concrete
{
    [Table("Urunler")]
    public class Urun : IEntity
    {
        public Urun()
        {
            UrunImages = new HashSet<UrunImage>();
        }

        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public string UrunAciklama { get; set; }
        public decimal UrunFiyati { get; set; }

        public int KategoriId { get; set; }
        [ForeignKey("KategoriId")]
        public virtual Kategori Kategori { get; set; }


        public virtual ICollection<UrunImage> UrunImages { get; set; }

    }
}
