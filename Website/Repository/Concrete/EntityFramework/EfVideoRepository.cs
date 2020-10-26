using Website.Entity;
using Website.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Repository.Concrete.EntityFramework
{
    public class EfVideoRepository : EfGenericRepository<Video>, IVideoRepository
    {
        public EfVideoRepository(WebsiteContext context) : base(context)
        {
        }
    }
}
