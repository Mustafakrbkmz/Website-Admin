using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Website.Entity
{
    public class Kategori
    {
        public int Id { get; set; }
        [DisplayName("Kategori Adı")]
        [Required]
        public string Adi { get; set; }
        [Required]
        public string Dil { get; set; } //en,tr,de gibi





    }
}
