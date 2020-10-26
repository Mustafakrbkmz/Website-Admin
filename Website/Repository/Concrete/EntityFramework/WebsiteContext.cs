using Website.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Repository.Concrete.EntityFramework
{
    public class WebsiteContext : DbContext
    {
        public WebsiteContext(DbContextOptions<WebsiteContext> options)
            : base(options)
        {

        }


        public DbSet<Urun> Urunler { get; set; }
        public DbSet<UrunResim> UrunResimler { get; set; }
        public DbSet<UrunGrup> UrunGruplar { get; set; }
        public DbSet<Blog> Bloglar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Resim> Resimler { get; set; }
        public DbSet<Video> Videolar { get; set; }
        public DbSet<Etiket> Etiketler { get; set; }
        public DbSet<Yazi> Yazilar { get; set; }
        public DbSet<Slider> Sliderlar { get; set; }
        public DbSet<SSS> SSSler { get; set; }
        public DbSet<Ayar> Ayarlar { get; set; }
    }
}
