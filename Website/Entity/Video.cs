using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Website.Entity
{
    public class Video
    {
        public int Id { get; set; }
        [DisplayName("Video Adı")]
        [Required]
        public string Adi { get; set; }
        public string Link { get; set; } // Siteye eklenecek videolar youtube kanalımız üzerinden eklenip link ile siteden paylaşılır.
    }
}
