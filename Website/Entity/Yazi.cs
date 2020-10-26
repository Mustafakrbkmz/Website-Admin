using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Website.Entity
{
    public class Yazi
    { //Hakkımızda,misyon,vizyon
        
        public int Id { get; set; }
        [DisplayName("Başlık")]
        [Required]
        public string Baslik { get; set; }
        [Required]
        public string Icerik { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
        [Required]
        public string Dil { get; set; } //en,tr,de gibi
        public string Yazar { get; set; } // Zorunlu değil.
    }
}
