using Website.Entity;
using Website.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Repository.Concrete.EntityFramework
{
    public class EfEtiketRepository : EfGenericRepository<Etiket>, IEtiketRepository
    {
        public EfEtiketRepository(WebsiteContext context) : base(context)
        {
        }
    }
}
