using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Website.Entity
{
    public class Blog
    {
        public int Id { get; set; }
        [DisplayName("Başlık")]
        [Required]
        public string Baslik { get; set; }
        [DisplayName("İçerik")]
        [Required]
        public string Icerik { get; set; }
        public string OneCikanGorsel { get; set; }  //Default görsel olsun.
        public string Yazar { get; set; }
        [Required]
        public string Dil { get; set; } //en,tr,de gibi
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;


        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual List<Etiket> Etiketler { get; set; }

        //KategoriId ve EtiketId gelecek
    }
}
