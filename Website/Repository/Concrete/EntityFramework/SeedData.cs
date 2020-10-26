using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Repository.Concrete.EntityFramework
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            WebsiteContext context = app.ApplicationServices.GetRequiredService<WebsiteContext>();
            context.Database.Migrate();
            if (!context.UrunGruplar.Any())
            {
                context.UrunGruplar.AddRange(
                    new Website.Entity.UrunGrup() { Id = 1, Adi = "Kavanoz", Aciklama = "", Dil = "tr-TR" },
                    new Website.Entity.UrunGrup() { Id = 2, Adi = "Şişe", Aciklama = "", Dil = "tr-TR" },
                    new Website.Entity.UrunGrup() { Id = 3, Adi = "Sürahi", Aciklama = "", Dil = "tr-TR" }
                );
                context.SaveChanges();
            }
            if (!context.Urunler.Any())
            {
                context.Urunler.AddRange(
                    new Website.Entity.Urun() { Id = 1, Adi = "210 CC Yumurta Kavanoz", SiraNo = 1, Kodu = "K21001T1R0", DolumHacimi = 210, Boyu = 82, Capi = 74, Agirligi = 0, PaletSiraSayisi = 28, TavaUrunAdedi = 233, PaletIcAdedi = 6524, PaletYuksekligi = 2520, PaletAgirligi = 1, Aciklama = "", Dil = "tr-TR", OneCikanGorsel = @"~\Img\OneCikanGorsel\210_yumurta", UrunGrupId = 1, },
                    new Entity.Urun() { Id = 1, Adi = "300 CC Standart Kavanoz", SiraNo = 5, Kodu = "K21001T1R0", DolumHacimi = 300, Boyu = 90, Capi = 74, Agirligi = 0, PaletSiraSayisi = 28, TavaUrunAdedi = 233, PaletIcAdedi = 6524, PaletYuksekligi = 2520, PaletAgirligi = 1, Aciklama = "", Dil = "tr-TR", OneCikanGorsel = @"~\Img\OneCikanGorsel\210_yumurta", UrunGrupId = 1, },
                    new Entity.Urun() { Id = 1, Adi = "370 CC Standart Kavanoz", SiraNo = 10, Kodu = "K21001T1R0", DolumHacimi = 370, Boyu = 95, Capi = 74, Agirligi = 0, PaletSiraSayisi = 28, TavaUrunAdedi = 233, PaletIcAdedi = 6524, PaletYuksekligi = 2520, PaletAgirligi = 1, Aciklama = "", Dil = "tr-TR", OneCikanGorsel = @"~\Img\OneCikanGorsel\210_yumurta", UrunGrupId = 1, },
                    new Entity.Urun() { Id = 1, Adi = "500 CC Uzun Kavanoz", SiraNo = 15, Kodu = "K21001T1R0", DolumHacimi = 500, Boyu = 105, Capi = 74, Agirligi = 0, PaletSiraSayisi = 28, TavaUrunAdedi = 233, PaletIcAdedi = 6524, PaletYuksekligi = 2520, PaletAgirligi = 1, Aciklama = "", Dil = "tr-TR", OneCikanGorsel = @"~\Img\OneCikanGorsel\210_yumurta", UrunGrupId = 1, },
                    new Entity.Urun() { Id = 1, Adi = "770 CC Facet Kavanoz", SiraNo = 20, Kodu = "K21001T1R0", DolumHacimi = 770, Boyu = 93, Capi = 74, Agirligi = 0, PaletSiraSayisi = 28, TavaUrunAdedi = 233, PaletIcAdedi = 6524, PaletYuksekligi = 2520, PaletAgirligi = 1, Aciklama = "", Dil = "tr-TR", OneCikanGorsel = @"~\Img\OneCikanGorsel\210_yumurta", UrunGrupId = 1, },
                    new Entity.Urun() { Id = 1, Adi = "770 CC Standart Kavanoz", SiraNo = 25, Kodu = "K21001T1R0", DolumHacimi = 770, Boyu = 91, Capi = 74, Agirligi = 0, PaletSiraSayisi = 28, TavaUrunAdedi = 233, PaletIcAdedi = 6524, PaletYuksekligi = 2520, PaletAgirligi = 1, Aciklama = "", Dil = "tr-TR", OneCikanGorsel = @"~\Img\OneCikanGorsel\210_yumurta", UrunGrupId = 1, },
                    new Entity.Urun() { Id = 1, Adi = "770 CC Boğumlu Kavanoz", SiraNo = 30, Kodu = "K21001T1R0", DolumHacimi = 770, Boyu = 92, Capi = 74, Agirligi = 0, PaletSiraSayisi = 28, TavaUrunAdedi = 233, PaletIcAdedi = 6524, PaletYuksekligi = 2520, PaletAgirligi = 1, Aciklama = "", Dil = "tr-TR", OneCikanGorsel = @"~\Img\OneCikanGorsel\210_yumurta", UrunGrupId = 1, }


                    );
                context.SaveChanges();
            }
        }
    }
}
