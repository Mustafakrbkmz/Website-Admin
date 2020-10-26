using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Website.Entity
{
    public class Slider
    {
        public int Id { get; set; }
        [DisplayName("Resim Adı")]
        [Required]
        public string Resim { get; set; }
        public string Aciklama1 { get; set; }
        public string Aciklama2 { get; set; }
        public string Aciklama3 { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
    }
}
