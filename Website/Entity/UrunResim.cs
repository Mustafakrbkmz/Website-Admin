using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Website.Entity
{
    public class UrunResim
    {
        public int Id { get; set; }
        [DisplayName("Resim Adı")]
        [Required]
        public string Adi { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;

        //public int UrunId { get; set; }
        //public virtual Urun Urun { get; set; }
    }
}
