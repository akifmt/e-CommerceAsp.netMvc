using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Entities.Concrete
{
    [Table("Kategoriler")]
    public class Kategori : IEntity
    {
        public Kategori()
        {
            Urunler = new HashSet<Urun>();
        }
        
        public int Id { get; set; }
        public string KategoriAdi { get; set; }

        public virtual ICollection<Urun> Urunler { get; set; }
    }
}
