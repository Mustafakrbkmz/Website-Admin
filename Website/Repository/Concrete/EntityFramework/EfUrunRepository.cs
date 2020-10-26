using Website.Entity;
using Website.Repository.Abstract;
using Website.Repository.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Repository.Concrete
{
    public class EfUrunRepository : EfGenericRepository<Urun>, IUrunRepository
    {
        public EfUrunRepository(WebsiteContext context) : base(context)
        {

        }

    }
}
