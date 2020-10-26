using Website.Entity;
using Website.Repository.Abstract;
using Website.Repository.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Repository.Concrete.EntityFramework
{
    public class EfBlogRepository : EfGenericRepository<Blog>, IBlogRepository
    {
        public EfBlogRepository(WebsiteContext context) : base(context)
        {

        }

    }
}
