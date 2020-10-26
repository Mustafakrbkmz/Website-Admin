using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Website.Entity
{
    public class Etiket
    {
        public int EtiketId { get; set; }
        [DisplayName("Etiket Adı")]
        [Required]
        public string Adi { get; set; }
        [Required]
        public string Dil { get; set; }


    }
}
