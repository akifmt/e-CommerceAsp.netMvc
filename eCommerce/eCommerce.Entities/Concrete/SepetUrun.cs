using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Entities.Concrete
{
    [Table("SepetUrun")]
    public class SepetUrun : IEntity
    {
        public int Id { get; set; }

        public int SepetId { get; set; }
        [ForeignKey("SepetId")]
        public virtual Sepet Sepet { get; set; }

        public virtual Urun Urun{ get; set; }
        public int Miktar { get; set; }
    }
}
