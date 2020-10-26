using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Website.Entity
{
    public class SSS
    {
        public int Id { get; set; }
        [DisplayName("Soru")]
        [Required]
        public string Soru { get; set; }
        [DisplayName("Cevap")]
        [Required]
        public string Cevap { get; set; }
        [Required]
        public string Dil { get; set; } //en,tr,de gibi
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;

    }
}
