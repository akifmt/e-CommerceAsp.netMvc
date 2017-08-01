using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Entities.Concrete
{
    [Table("Adresler")]
    public class Adres : IEntity
    {
        public int Id { get; set; }
        public string AdresAdi { get; set; }
        public string Ulke { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string AdresDetay { get; set; }

        public int ProfilId { get; set; }
        [ForeignKey("ProfilId")]
        public Profil Profil { get; set; }

    }
}
