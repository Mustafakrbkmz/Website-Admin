using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Website.Entity
{
    public class Resim // Bu sınıfın olması gerekli mi bak.
    {
        public int Id { get; set; }
        [DisplayName("Resim Adı")]

        [Required]
        public string Adi { get; set; }
        public string ResimYolu { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
    }
}
