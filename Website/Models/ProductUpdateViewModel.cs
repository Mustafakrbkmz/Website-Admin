using Website.Entity;
using System.Collections.Generic;
using Website.Repository.Concrete;
using System.Linq;

namespace Website.Models
{
    public class ProductUpdateViewModel
    {
        public Urun Urun { get; set; }
        public IQueryable<UrunGrup> UrunGrups { get; set; }
    }
}