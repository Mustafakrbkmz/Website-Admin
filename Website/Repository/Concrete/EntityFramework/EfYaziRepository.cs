using Website.Entity;
using Website.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Repository.Concrete.EntityFramework
{
    public class EfYaziRepository : EfGenericRepository<Yazi>, IYaziRepository
    {
        public EfYaziRepository(WebsiteContext context) : base(context)
        {
        }
    }
}
