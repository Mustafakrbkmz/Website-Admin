using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Website.Entity
{
    public class UrunGrup
    {
        public int Id { get; set; }
        [DisplayName("Ürün Grup Adı")]
        [Required]
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        [Required]
        public string Dil { get; set; } //en,tr,de gibi

        //public virtual List<Urun> Urunler { get; set; }
    }
}
