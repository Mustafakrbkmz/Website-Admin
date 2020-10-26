using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Website.Entity
{
    public class Urun
    {
        public int Id { get; set; }
        [DisplayName("Ürün Adı")]
        public string Adi { get; set; }
        [DisplayName("Sıra")]
        public int SiraNo { get; set; } //listede sıralamak için
        [DisplayName("Ürün Kodu")]
        public string Kodu { get; set; } //K72001T1R0
        public int DolumHacimi { get; set; }
        public int SilmeHacimi { get; set; }
        public double Boyu { get; set; } //float olanları double yap
        public double Capi { get; set; }
        public double Agirligi { get; set; }
        public string KafaTipi { get; set; }
        public int PaletSiraSayisi { get; set; }
        public int TavaUrunAdedi { get; set; }
        public int PaletIcAdedi { get; set; }
        public int PaletYuksekligi { get; set; }
        public int PaletAgirligi { get; set; }
        public string Aciklama { get; set; }
        [Required]
        public string Dil { get; set; } //en,tr,de gibi
        public string Brosur { get; set; } // Çizimleri farklı bir sayfada ürün YerliMi şartı ile yerli ve ihraç ürünlere ait çizimleri listeleyebiliz.

        public string OneCikanGorsel { get; set; } = "~/Img/UrunGorsel/gorsel_hazirlaniyor.jpg";   // Zorunlu alan. Default görsel koy.

        public int UrunGrupId { get; set; }
        public virtual UrunGrup UrunGrup  { get; set; }
        public virtual List<UrunResim> UrunResimler { get; set; }
        //UrunResimId liste şeklinde gelicek. Birden fazla resim alacak.
       
    }
}
