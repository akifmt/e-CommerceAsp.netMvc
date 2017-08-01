using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Entities.Concrete
{
    [Table("UrunImage")]
    public class UrunImage :IEntity
    {
        public int UrunImageId { get; set; }
        public string UrunImageUrl { get; set; }

        public int UrunId { get; set; }
        [ForeignKey("UrunId")]
        public virtual Urun Urun { get; set; }
    }
}
