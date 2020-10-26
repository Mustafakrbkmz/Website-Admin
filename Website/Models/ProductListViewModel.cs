using Website.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Website
{
    public class ProductListViewModel
    {
        public IQueryable<Urun> Uruns { get; set; }
        public IQueryable<UrunGrup> UrunGrups { get; set; }
    }
}