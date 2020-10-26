using Website.Entity;
using System.Linq;

namespace Website
{
    public class BlogUpdateViewModel
    {
        public Blog Blog { get; set; }
        public IQueryable<Kategori> BlogKategori { get; set; }
    }
}