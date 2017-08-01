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
    [Table("Profiller")]
    public class Profil : IEntity
    {
        public Profil()
        {
            Adresler = new HashSet<Adres>();
            Sepetler = new HashSet<Sepet>();
            Siparisler = new HashSet<Siparis>();
        }

        [Key]
        public int ProfilId { get; set; }

        [Display(Name = "Adresler")]
        public virtual ICollection<Adres> Adresler { get; set; }
        
        [Display(Name = "Sepetler")]
        public virtual ICollection<Sepet> Sepetler { get; set; }

        [Display(Name = "Siparisler")]
        public virtual ICollection<Siparis> Siparisler { get; set; }

        [Required]
        [MaxLength(11)]
        [Display(Name = "TC Kimlik Numarası")]
        public string TCKimlikNo { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Ad")]
        public string Ad { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Soyad")]
        public string Soyad { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Doğum Tarihi")]
        public DateTime DogumTarihi { get; set; }

        [MaxLength(10)]
        [MinLength(10)]
        [Display(Name = "Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }

        [NotMapped]
        [Display(Name = "Profil Bilgi")]
        public string ProfilBilgi
        {
            get
            {
                return Ad + " " + Soyad + " (" + TCKimlikNo + ")";
            }
        }

    }
}
