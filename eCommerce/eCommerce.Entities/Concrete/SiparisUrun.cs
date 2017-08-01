using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Entities.Concrete
{
    [Table("SiparisUrun")]
    public class SiparisUrun : IEntity
    {
        public int SiparisUrunId { get; set; }
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int UrunMiktar { get; set; }
        public decimal UrunFiyati { get; set; }

    }
}
