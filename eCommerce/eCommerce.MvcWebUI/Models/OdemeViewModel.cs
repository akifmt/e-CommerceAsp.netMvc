using eCommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.MvcWebUI.Models
{
    public class OdemeViewModel
    {
        public Profil Profil { get; set; }

        public int? SelectedAdresId { get; set; }
        public List<Adres> Adresler { get; set; }
        
        public string Ulke { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string AdresDetay { get; set; }

        public Siparis Siparis { get; set; }

    }
}